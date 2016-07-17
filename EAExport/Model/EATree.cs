namespace EAExport.Model
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Text;

    /// <summary>
    /// A structure describing a single Requirement object in Enterprise Architect.
    /// </summary>
    [DebuggerDisplay("{Id} ({ParentId}): {Heading}")]
    public class EATree
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EATree"/> class.
        /// </summary>
        /// <param name="id">The identifier for the object.</param>
        /// <param name="heading">The heading of the object.</param>
        /// <param name="text">The text description of the object.</param>
        /// <param name="pos">The relative position of this object with other
        /// elements at this level.</param>
        public EATree(string id, string heading, string text, int pos)
            : this(null, id, heading, text, pos) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="EATree"/> class.
        /// </summary>
        /// <param name="parentId">The parent object identifier.</param>
        /// <param name="id">The identifier for the object.</param>
        /// <param name="heading">The heading of the object.</param>
        /// <param name="text">The text description of the object.</param>
        /// <param name="pos">The relative position of this object with other
        /// elements at this level.</param>
        public EATree(string parentId, string id, string heading, string text, int pos)
        {
            ParentId = parentId;
            Id = id;
            Heading = heading;
            Text = text;
            Pos = pos;
        }

        /// <summary>
        /// Gets the parent identifier for the object.
        /// </summary>
        /// <value>The parent identifier for the object.</value>
        public string ParentId { get; set; }

        /// <summary>
        /// Gets the identifier for the object.
        /// </summary>
        /// <value>The identifier for the object.</value>
        public string Id { get; private set; }

        /// <summary>
        /// Gets the heading of the object.
        /// </summary>
        /// <value>The heading of the object.</value>
        public string Heading { get; private set; }

        /// <summary>
        /// Gets the text description of the object.
        /// </summary>
        /// <value>The text description of the object.</value>
        public string Text { get; set; }

        /// <summary>
        /// Gets the relative position of this object with others at this level.
        /// </summary>
        /// <value>The relative position of this object.</value>
        public int Pos { get; set; }

        /// <summary>
        /// Gets or sets the alias for the object.
        /// </summary>
        /// <value>The alias for the object.</value>
        public string Alias { get; set; }

        /// <summary>
        /// Gets or sets the stereotype associated with the object.
        /// </summary>
        /// <value>The stereotype associated with the object.</value>
        public string Stereotype { get; set; }

        /// <summary>
        /// Gets or sets the author of the object.
        /// </summary>
        /// <value>The author of the object.</value>
        public string Author { get; set; }

        /// <summary>
        /// Gets or sets the version of the object.
        /// </summary>
        /// <value>The version of the object.</value>
        public string Version { get; set; }

        /// <summary>
        /// Gets or sets the status of the object.
        /// </summary>
        /// <value>The status of the object.</value>
        public string Status { get; set; }

        private readonly LinkedList<EATree> m_Children = new LinkedList<EATree>();

        /// <summary>
        /// Gets the children of this object.
        /// </summary>
        /// <value>The children of this object.</value>
        public ICollection<EATree> Children { get { return m_Children; } }

        /// <summary>
        /// Adds an element as a child to this element in sorted order.
        /// </summary>
        /// <param name="element">The element to add.</param>
        public void AddChild(EATree element)
        {
            if (m_Children.Count == 0) {
                m_Children.AddFirst(element);
                return;
            }

            LinkedListNode<EATree> node = m_Children.First;
            do {
                if (element.Pos < node.Value.Pos) {
                    m_Children.AddBefore(node, element);
                    return;
                }
                node = node.Next;
            } while (node != null);
            m_Children.AddLast(element);
        }
    }
}
