// This file is used by Code Analysis to maintain SuppressMessage
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given
// a specific target and scoped to a namespace, type, member, etc.

using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "WinForm Naming Style")]
[assembly: SuppressMessage("Major Code Smell", "S1066:Collapsible \"if\" statements should be merged", Justification = "Doesn't improve read quality")]
[assembly: SuppressMessage("Minor Code Smell", "S3626:Jump statements should not be redundant", Justification = "Allows easier refactoring")]
[assembly: SuppressMessage("Minor Code Smell", "S4136:Method overloads should be grouped together", Justification = "Minor issue")]
