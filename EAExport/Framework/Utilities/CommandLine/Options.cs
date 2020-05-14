﻿namespace HBAS.Utilities.CommandLine
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Linq;
    using System.Reflection;
    using System.Text;

    /// <summary>
    /// The style of command line options to use.
    /// </summary>
    public enum OptionsStyle
    {
        /// <summary>
        /// Windows style.
        /// </summary>
        Windows,

        /// <summary>
        /// Unix style.
        /// </summary>
        Unix
    }

    /// <summary>
    /// Object to parse the command line options and set the fields within the class provided in the constructor.
    /// </summary>
    /// <remarks>
    /// To parse command line options, create a new class of your choosing that should contain the results of
    /// command line parsing. You should define a set of properties and fields. It's those properties and fields
    /// which will be set by this class when parsing the command line.
    /// <para>The properties and fields may have any kind of visibility you need, e.g. <c>public</c>, <c>private</c>,
    /// <c>internal</c>, <c>internal protected</c> or <c>protected</c> when using C#. Even the <c>private</c> fields
    /// can be set through reflection.</para>
    /// <para>Instantiate your class and then pass the reference to the method <see cref="Parse(object, string[])"/> with
    /// the command line parameters provided by the main entry point.</para>
    /// <example>
    /// <code>
    /// using System;
    /// namespace CommandLineTest {
    ///   class Program {
    ///     static void Main(string[] args) {
    ///       CmdLineOptions myOptions = new CmdLineOptions();
    ///       Options.Parse(myOptions, args, OptionsStyle.Unix);
    ///     }
    ///   }
    /// }
    /// </code>
    /// </example>
    /// <para>The class <c>CmdLineOptions</c> needs to be defined by your project. Properties that should
    /// be set are decorated with the <see cref="OptionAttribute"/> attribute.</para>
    /// <example>
    /// <code>
    /// private class CmdLineOptions {
    ///   [Option('a', "along", false)]
    ///   public bool OptionA;
    ///
    ///   [Option('b', "blong", false)]
    ///   public bool OptionB;
    ///
    ///   [Option('c', "clong", false)]
    ///   public string OptionC;
    /// }
    /// </code>
    /// </example>
    /// <para>So if your program is given the option "-a", the property <c>CmdLineOptions.OptionA</c> is automatically
    /// set to <c>true</c>. The variable <c>OptionC</c> is set to the argument that follows, e.g. <c>-c mystring</c>.</para>
    /// <para>Properties with the type <c>boolean</c> may not have arguments and are always set to <c>true</c> when
    /// provided. All types except <c>boolean</c> types expect an argument.</para>
    /// <note type="note">This application can only parse the command line that comes from Windows. In particular,
    /// Windows removes any quoting which may result in unexpected behaviour. Such an example is <c>--foo="a,b",c</c>
    /// which results in a single argument <c>--foo=a,b,c</c> which is indistinguishable from the command line
    /// <c>--foo="a,b,c"</c> that also results in <c>--foo=a,b,c</c>. In this case, the user should use the single
    /// tick for quoting.</note>
    /// </remarks>
    public class Options
    {
        /// <summary>
        /// Parses the command line arguments writing to options.
        /// </summary>
        /// <param name="options">The options object to write to.</param>
        /// <param name="arguments">The argument list to parse.</param>
        /// <returns>An instance of this object.</returns>
        public static Options Parse(object options, string[] arguments)
        {
            Options cmdLine = new Options(options);
            cmdLine.ParseCommandLine(arguments);
            return cmdLine;
        }

        /// <summary>
        /// Parses the specified options.
        /// </summary>
        /// <param name="options">The options object to write to.</param>
        /// <param name="arguments">The argument list to parse.</param>
        /// <param name="style">The option style to use.</param>
        /// <returns>An instance of this object.</returns>
        public static Options Parse(object options, string[] arguments, OptionsStyle style)
        {
            Options cmdLine = new Options(options) {
                OptionsStyle = style
            };
            cmdLine.ParseCommandLine(arguments);
            return cmdLine;
        }

        private object m_Options;

        /// <summary>
        /// Initializes a new instance of the <see cref="Options"/> class using the Windows style.
        /// </summary>
        /// <param name="options">The object to receive the options for.</param>
        private Options(object options)
        {
            if (options == null) throw new ArgumentNullException("options");
            m_Options = options;
        }

        #region Inspecting and building command line options
        private class OptionData
        {
            public OptionData(OptionAttribute attribute, MemberInfo member)
            {
                if (attribute == null) throw new ArgumentNullException("attribute");
                if (!(member is PropertyInfo) && !(member is FieldInfo))
                    throw new ArgumentException("Not a property/field", "member");

                Attribute = attribute;
                Member = member;
            }

            public OptionAttribute Attribute { get; set; }
            public MemberInfo Member { get; set; }
            public bool Set { get; set; }

            public bool IsList
            {
                get
                {
                    if (Member == null) return false;
                    if ((Member is FieldInfo) && typeof(IList).IsAssignableFrom(((FieldInfo)Member).FieldType)) return true;
                    if ((Member is PropertyInfo) && typeof(IList).IsAssignableFrom(((PropertyInfo)Member).PropertyType)) return true;
                    return false;
                }
            }

            public IList GetList(object options)
            {
                FieldInfo fieldInfo = Member as FieldInfo;
                if (fieldInfo != null) return (IList)(fieldInfo.GetValue(options));

                PropertyInfo propertyInfo = Member as PropertyInfo;
                if (propertyInfo != null) return (IList)(propertyInfo.GetValue(options, null));

                return null;
            }

            public void SetValue(object options, string value)
            {
                FieldInfo field = Member as FieldInfo;
                if (field != null) {
                    field.SetValue(options, ChangeType(value, field.FieldType));
                    Set = true;
                    return;
                }

                PropertyInfo property = Member as PropertyInfo;
                if (property != null) {
                    property.SetValue(options, ChangeType(value, property.PropertyType), null);
                    Set = true;
                    return;
                }
            }

            public void SetValue(object options, bool value)
            {
                FieldInfo field = Member as FieldInfo;
                if (field != null) {
                    field.SetValue(options, value);
                    Set = true;
                    return;
                }

                PropertyInfo property = Member as PropertyInfo;
                if (property != null) {
                    property.SetValue(options, value, null);
                    Set = true;
                    return;
                }
            }

            public bool ExpectsValue
            {
                get
                {
                    if ((Member is FieldInfo) && ((FieldInfo)Member).FieldType == typeof(bool)) return false;
                    if ((Member is PropertyInfo) && ((PropertyInfo)Member).PropertyType == typeof(bool)) return false;
                    return true;
                }
            }
        }

        private Dictionary<string, OptionData> m_LongOptionList = new Dictionary<string, OptionData>();
        private Dictionary<char, OptionData> m_ShortOptionList = new Dictionary<char, OptionData>();
        private List<OptionData> m_OptionList = new List<OptionData>();
        private IList<string> m_Arguments;

        private void BuildOptionList(bool longOptionCaseInsensitive)
        {
            foreach (FieldInfo field in m_Options.GetType().GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public)) {
                ParseMember(field, longOptionCaseInsensitive);
            }

            foreach (PropertyInfo property in m_Options.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public)) {
                ParseMember(property, longOptionCaseInsensitive);
            }
        }

        private void ParseMember(MemberInfo memberInfo, bool longOptionCaseInsensitive)
        {
            OptionAttribute attribute = GetAttribute<OptionAttribute>(memberInfo);
            if (attribute != null) {
                CheckShortOption(attribute.ShortOption);
                CheckLongOption(attribute.LongOption);

                OptionData optionData = new OptionData(attribute, memberInfo);
                m_OptionList.Add(optionData);

                if (attribute.ShortOption != (char)0) {
                    m_ShortOptionList.Add(attribute.ShortOption, optionData);
                }
                if (attribute.LongOption != null) {
                    string longOption = longOptionCaseInsensitive
                        ? attribute.LongOption.ToLowerInvariant()
                        : attribute.LongOption;
                    m_LongOptionList.Add(longOption, optionData);
                }
                return;
            }

            OptionArgumentsAttribute argAttribute = GetAttribute<OptionArgumentsAttribute>(memberInfo);
            if (argAttribute != null) {
                if (m_Arguments != null)
                    throw new OptionException("OptionArgumentsAttribute assigned to multiple fields/properties");
                m_Arguments = GenerateArgumentList(memberInfo);
                m_ArgumentsReadOnly = m_Arguments;
            }
        }

        private IList<string> GenerateArgumentList(MemberInfo member)
        {
            FieldInfo field = member as FieldInfo;
            if (field != null) {
                if (typeof(IList<string>).IsAssignableFrom(field.FieldType)) {
                    return new GenericList<string>((IList<string>)field.GetValue(m_Options));
                }
                if (typeof(IList).IsAssignableFrom(field.FieldType)) {
                    return new GenericList<string>((IList)field.GetValue(m_Options));
                }
            }

            PropertyInfo property = member as PropertyInfo;
            if (property != null) {
                if (typeof(IList<string>).IsAssignableFrom(property.PropertyType)) {
                    return new GenericList<string>((IList<string>)property.GetValue(m_Options, null));
                }
                if (typeof(IList).IsAssignableFrom(property.PropertyType)) {
                    return new GenericList<string>((IList)property.GetValue(m_Options, null));
                }
            }

            return null;
        }

        [Conditional("DEBUG")]
        private void CheckShortOption(char shortOption)
        {
            if (shortOption == (char) 0) return;

            if (m_ShortOptionList.ContainsKey(shortOption)) {
                throw new OptionDuplicateException("Option '" + shortOption + "' was specified multiple times");
            }
            if (m_LongOptionList.ContainsKey(shortOption.ToString())) {
                throw new OptionDuplicateException("Option \"" + shortOption + "\" was specified multiple times");
            }
        }

        [Conditional("DEBUG")]
        private void CheckLongOption(string longOption)
        {
            if (longOption == null) return;

            if (m_LongOptionList.ContainsKey(longOption)) {
                throw new OptionDuplicateException("Option \"" + longOption + "\" was specified multiple times");
            }
            if (longOption.Length == 1) {
                if (m_ShortOptionList.ContainsKey(longOption[0])) {
                    throw new OptionDuplicateException("Option '" + longOption + "' was specified multiple times");
                }
            }
        }

        private static T GetAttribute<T>(ICustomAttributeProvider provider) where T : Attribute
        {
            return provider.GetCustomAttributes(typeof(T), false).OfType<T>().FirstOrDefault();
        }
        #endregion

        private OptionsStyle m_OptionsStyle;

        /// <summary>
        /// Gets or sets the options style to use when parsing the command line.
        /// </summary>
        /// <value>The options style to use when parsing the command line.</value>
        /// <exception cref="System.ArgumentException">Unknown Options Style;value</exception>
        public OptionsStyle OptionsStyle
        {
            get { return m_OptionsStyle; }
            internal set
            {
                if (!Enum.IsDefined(OptionsStyle.GetType(), value))
                    throw new ArgumentException("Unknown Options Style", "value");
                m_OptionsStyle = value;
            }
        }

        /// <summary>
        /// Parses the command line arguments.
        /// </summary>
        /// <param name="arguments">The command line arguments to parse.</param>
        /// <remarks>
        /// Parses the command line arguments provided, setting the fields in the object provided when
        /// this object was instantiated.
        /// </remarks>
        private void ParseCommandLine(string[] arguments)
        {
            OptionToken token;
            OptionToken lastToken = null;
            OptionToken lastOptionToken = null;
            IOptionParser parser;

            switch (m_OptionsStyle) {
            case OptionsStyle.Unix:
                parser = new UnixOptionParser(arguments);
                break;
            case OptionsStyle.Windows:
                parser = new WindowsOptionEnumerator(arguments);
                break;
            default:
                throw new InternalApplicationException("Unknown command style parser");
            }

            BuildOptionList(parser.LongOptionCaseInsensitive);
            IOptions options = m_Options as IOptions;
            if (m_Arguments == null) m_Arguments = new List<string>();

            try {
                do {
                    token = parser.GetToken(false);
                    if (token == null) continue;
                    switch (token.Token) {
                    case OptionTokenKind.ShortOption:
                    case OptionTokenKind.LongOption:
                        if (m_Arguments.Count > 0) {
                            string msg;
                            if (lastOptionToken != null) {
                                msg = string.Format("Unexpected option '{0}', perhaps too many arguments after '{1}'",
                                    token.ToString(parser), lastOptionToken.ToString(parser));
                            } else {
                                msg = string.Format("Unexpected option '{0}'", token.ToString(parser));
                            }
                            throw new OptionException(msg);
                        }
                        ParseOption(parser, token);
                        lastOptionToken = token;
                        break;
                    case OptionTokenKind.Argument:
                        ParseArgument(parser, token);
                        break;
                    case OptionTokenKind.Value:
                        if (lastToken != null) {
                            throw new OptionException("Unexpected value for option " +
                                lastToken.ToString(parser) +
                                " (argument " + token + ")");
                        }
                        throw new OptionException("Unexpected value " + token);
                    }
                    lastToken = token;
                } while (token != null);
            } catch (OptionUnknownException e) {
                if (options != null) options.InvalidOption(e.Option);
                throw;
            } catch (OptionMissingArgumentException e) {
                if (options != null) options.InvalidOption(e.Option);
                throw;
            } catch (OptionFormatException e) {
                if (options != null) options.InvalidOption(e.Option);
                throw;
            } catch (OptionException) {
                if (options != null) options.Usage();
                throw;
            }

            // Check that all mandatory options were provided
            StringBuilder sb = new StringBuilder();
            List<string> optionList = new List<string>();
            foreach (OptionData optionData in m_OptionList) {
                if (optionData.Attribute.Required && !optionData.Set) {
                    MissingOption(parser,
                        optionData.Attribute.ShortOption,
                        optionData.Attribute.LongOption,
                        sb, optionList);
                }
            }

            if (sb.Length > 0) {
                if (options != null) options.Missing(optionList);
                throw new OptionMissingException(sb.ToString());
            }

            if (options != null) options.Check();
        }

        private void MissingOption(IOptionParser parser, char shortOption, string longOption, StringBuilder message, ICollection<string> missing)
        {
            if (message.Length != 0) message.Append(", ");

            if (shortOption != (char) 0) {
                message.Append(parser.ShortOptionPrefix).Append(shortOption);
                if (missing != null) missing.Add(shortOption.ToString());
            } else if (longOption != null) {
                message.Append(parser.LongOptionCaseInsensitive).Append(longOption);
                if (missing != null) missing.Add(longOption);
            }
        }

        private void ParseOption(IOptionParser parser, OptionToken token)
        {
            switch (token.Token) {
            case OptionTokenKind.ShortOption:
                ParseShortOption(parser, token);
                break;
            case OptionTokenKind.LongOption:
                ParseLongOption(parser, token);
                break;
            }
        }

        private void ParseShortOption(IOptionParser parser, OptionToken token)
        {
            if (!m_ShortOptionList.TryGetValue(token.Value[0], out OptionData optionData))
                throw new OptionUnknownException(token.ToString(parser));

            ParseOptionParameter(parser, optionData, token);
        }

        private void ParseLongOption(IOptionParser parser, OptionToken token)
        {
            string option = parser.LongOptionCaseInsensitive ? token.Value.ToLowerInvariant() : token.Value;
            if (!m_LongOptionList.TryGetValue(option, out OptionData optionData))
                throw new OptionUnknownException(token.ToString(parser));

            ParseOptionParameter(parser, optionData, token);
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0060:Remove unused parameter", Justification = "Keep consistency in API groups")]
        private void ParseArgument(IOptionParser parser, OptionToken token)
        {
            m_Arguments.Add(token.Value);
        }

        private void ParseOptionParameter(IOptionParser parser, OptionData optionData, OptionToken token)
        {
            string argument = null;
            try {
                if (optionData.ExpectsValue) {
                    OptionToken argumentToken = parser.GetToken(true);
                    if (argumentToken == null) {
                        OptionDefaultAttribute defaultAttribute = null;
                        if (optionData.Member != null)
                            defaultAttribute = GetAttribute<OptionDefaultAttribute>(optionData.Member);
                        if (defaultAttribute == null)
                            throw new OptionMissingArgumentException(token.ToString(parser));
                        argument = defaultAttribute.DefaultValue;
                    } else {
                        argument = argumentToken.Value;
                    }
                    SetOption(parser, optionData, argument);
                } else {
                    // This is a boolean type. We can only set it to true.
                    SetBoolean(optionData, true);
                }

                optionData.Set = true;
            } catch (OptionException) {
                throw;
            } catch (System.Exception e) {
                if (argument == null) {
                    throw new OptionException("Error parsing option '" + token.ToString(parser) + "'");
                }
                throw new OptionFormatException(token.Value, "Wrong format '" + argument + "' given to option " + token.ToString(parser), e);
            }
        }

        private void SetOption(IOptionParser parser, OptionData optionData, string value)
        {
            if (optionData.IsList) {
                IList list = optionData.GetList(m_Options);
                SplitList(list, parser.ListSeparator, value);
                return;
            }

            if (optionData.Set) throw new OptionAssignedException(value);
            optionData.SetValue(m_Options, value);
        }

        private void SetBoolean(OptionData optionData, bool value)
        {
            optionData.SetValue(m_Options, value);
        }

        private void SplitList(IList list, char separationChar, string value)
        {
            StringBuilder sb = new StringBuilder();
            char quote = (char)0;
            int schar = 0;
            bool escape = false;
            bool quoted = false;

            for (int i = 0; i < value.Length; i++) {
                char c = value[i];
                if (escape) {
                    escape = false;

                    // We only escape quotes, else every other character is literal. This allows
                    // Windows paths to be given without having to escape each path character.
                    if (c == '\'' || c == '\"') continue;
                    sb.Append('\\');
                    continue;
                }
                if (c == '\\') {
                    // Copy from 'schar' to this character to cut out the
                    // escape character.
                    sb.Append(value.Substring(schar, i - schar));
                    escape = true;
                    schar = i + 1;
                    continue;
                }
                if (c == '\'' || c == '\"') {
                    if (quote == 0) {
                        // Begin a quote
                        schar = i + 1;
                        quote = value[i];
                        quoted = true;
                        continue;
                    }
                    if (quote == value[i]) {
                        // End of the quote
                        sb.Append(value.Substring(schar, i - schar));
                        schar = i + 1;
                        quote = (char)0;
                        continue;
                    }
                }
                if (c == separationChar && quote == (char)0) {
                    sb.Append(value.Substring(schar, i - schar));
                    list.Add(sb.ToString());
                    sb.Clear();
                    schar = i + 1;
                    quoted = false;
                    continue;
                }

                if (quote == (char)0 && quoted)
                    throw new OptionException("Invalid data after quoted list, expect '" + separationChar + "' only");
            }

            if (escape) sb.Append('\\');

            if (quote != (char)0) throw new OptionException("Missing quote in list");

            // Add the trailing option
            sb.Append(value.Substring(schar));
            list.Add(sb.ToString());
        }

        private static object ChangeType(string value, Type type)
        {
            TypeConverter converter = TypeDescriptor.GetConverter(type);
            return converter.ConvertFromInvariantString(value);
        }

        private IList<string> m_ArgumentsReadOnly;

        /// <summary>
        /// Gets the arguments that were not parsed as options.
        /// </summary>
        /// <value>The arguments not parsed as options.</value>
        public IList<string> Arguments
        {
            get
            {
                if (m_ArgumentsReadOnly == null) m_ArgumentsReadOnly = new ReadOnlyCollection<string>(m_Arguments);
                return m_ArgumentsReadOnly;
            }
        }
    }
}
