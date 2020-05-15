namespace EAExport.Windows
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;
    using Native;

    public class TreeView : System.Windows.Forms.TreeView
    {
        private readonly bool m_OSVista;

        private Timer m_TreeViewScrollTimer;
        private int m_ScrollDirection;

        /// <summary>
        /// Initializes a new instance of the <see cref="TreeView" /> class.
        /// </summary>
        public TreeView()
        {
            if (Environment.OSVersion.Version >= new Version(6, 0)) {
                base.ShowLines = false;
                m_OSVista = true;
            } else {
                m_OSVista = false;
            }

            InitializeComponent();
        }

        private void InitializeComponent()
        {
            System.ComponentModel.IContainer components = new System.ComponentModel.Container();
            m_TreeViewScrollTimer = new Timer(components);
            m_TreeViewScrollTimer.Tick += m_TreeViewScrollTimer_Tick;
        }

        /// <summary>
        /// Gets or sets a value indicating whether lines are drawn between tree nodes in the tree view control.
        /// </summary>
        /// <returns>true if lines are drawn between tree nodes in the tree view control; otherwise, false. The default is true.</returns>
        public new bool ShowLines
        {
            get { return base.ShowLines; }
            set
            {
                if (m_OSVista && ExplorerStyle) return;
                base.ShowLines = value;
            }
        }

        /// <summary>
        /// Selects if we should use the Explorer Style. On Vista, this
        /// uses new functionality that is available. This property must
        /// be set before the control is created.
        /// </summary>
        public bool ExplorerStyle { get; set; }

        /// <summary>
        /// Overrides <see cref="P:System.Windows.Forms.Control.CreateParams" />.
        /// </summary>
        /// <returns>A <see cref="T:System.Windows.Forms.CreateParams" /> that contains the required creation parameters when the handle to the control is created.</returns>
        protected override CreateParams CreateParams
        {
            get
            {
                System.Windows.Forms.CreateParams cp = base.CreateParams;

                if (m_OSVista && ExplorerStyle) {
                    cp.Style |= Constants.TVS_NOHSCROLL; // lose the horizontal scrollbar
                }

                return cp;
            }
        }

        /// <summary>
        /// Overrides <see cref="M:System.Windows.Forms.Control.OnHandleCreated(System.EventArgs)" />.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnHandleCreated(System.EventArgs e)
        {
            base.OnHandleCreated(e);

            if (ExplorerStyle) {
                if (m_OSVista) {
                    // get style
                    int dw = (int)UnsafeNativeMethods.SendMessage(Handle, Msg.TVM_GETEXTENDEDSTYLE, IntPtr.Zero, IntPtr.Zero);
                    dw |= Constants.TVS_EX_AUTOHSCROLL;       // auto-scroll horizontally
                    dw |= Constants.TVS_EX_FADEINOUTEXPANDOS; // auto hide the +/- signs
                    dw |= Constants.TVS_EX_DOUBLEBUFFER;

                    // set style
                    UnsafeNativeMethods.SendMessage(Handle, Msg.TVM_SETEXTENDEDSTYLE, IntPtr.Zero, (IntPtr)dw);
                }

                try {
                    UnsafeNativeMethods.SetWindowTheme(Handle, "explorer", null);
                } catch (EntryPointNotFoundException) {
                    // Not all operating systems support this call, generally XP SP3 and later
                }
            }
        }

        /// <summary>
        /// Overrides <see cref="M:System.Windows.Forms.Control.WndProc(System.Windows.Forms.Message@)" />.
        /// </summary>
        /// <param name="m">The Windows <see cref="T:System.Windows.Forms.Message" /> to process.</param>
        protected override void WndProc(ref Message m)
        {
            // Ignore the 'background erase' message for the TreeView, that improves
            // the animation
            if (m_OSVista && m.Msg == 0x14) return;

            base.WndProc(ref m);
        }

        /// <summary>
        /// The last selected TreeNode, set by <c>SelectedNode</c> or by
        /// <c>HighlightedNode</c>
        /// </summary>
        private TreeNode m_SelectedNode;

        /// <summary>
        /// Gets or sets the tree node that is currently selected in the tree view control.
        /// </summary>
        /// <remarks>
        /// <para>If no TreeNode is currently selected, the SelectedNode property is
        /// null.</para>
        /// <para>When you set this property, the specified node is scrolled into view
        /// and any parent nodes are expanded so that the specified node is
        /// visible.</para>
        /// </remarks>
        public new TreeNode SelectedNode
        {
            get
            {
                return m_SelectedNode;
            }

            set
            {
                m_SelectedNode = value;
                base.SelectedNode = value;
            }
        }

        /// <summary>
        /// Gets or sets the tree node that is currently selected in the tree view control.
        /// </summary>
        /// <remarks>
        /// <para>Similar to the <c>SelectedNode</c> property, the specified node is
        /// selected, but it is not automatically scrolled to. Internally, this uses
        /// the TreeView control's <i>TVGN_DROPHILITE</i> feature</para>
        /// </remarks>
        public virtual TreeNode HighlightedNode
        {
            get
            {
                return m_SelectedNode;
            }

            set
            {
                m_SelectedNode = value;
                if (value != null) {
                    UnsafeNativeMethods.SendMessage(Handle, Msg.TVM_SELECTITEM, (IntPtr)Constants.TVGN_DROPHILITE, value.Handle);
                } else {
                    UnsafeNativeMethods.SendMessage(Handle, Msg.TVM_SELECTITEM, (IntPtr)Constants.TVGN_DROPHILITE, IntPtr.Zero);
                }
            }
        }

        /// <summary>
        /// Tells Visual Studio if this property never needs to be serialized
        /// </summary>
        /// <returns></returns>
        private bool ShouldSerializeHighlightedNode()
        {
            return false;
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.TreeView.AfterSelect" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.TreeViewEventArgs" /> that contains the event data.</param>
        protected override void OnAfterSelect(TreeViewEventArgs e)
        {
            m_SelectedNode = e.Node;
            base.OnAfterSelect(e);
        }

        /// <summary>
        /// Called after the user has edited a label
        /// </summary>
        /// <remarks>
        /// The standard TreeView control doesn't support sorting the TreeView
        /// after a label edit. You get infinite loops and other strange effects.
        /// This TreeView control will check the property "sorted", and if it is
        /// set, we'll reorganize the node in the tree for you. We don't attempt
        /// to resort the entire tree for performance, and to allow you to only
        /// sort what you want.
        /// <para>You must set <b>e.CancelEdit</b> to <b>true</b> if you don't
        /// want the node to be sorted!</para>
        /// </remarks>
        /// <param name="e"></param>
        protected override void OnAfterLabelEdit(NodeLabelEditEventArgs e)
        {
            base.OnAfterLabelEdit(e);
            if (!e.CancelEdit) {
                if (Sorted) {
                    m_AfterLabelEditNode = e.Node;
                    BeginInvoke(new InvokedMethod(ReSortAfterLabelEdit));
                }
            }
        }

        /// <summary>
        /// The node that was edited in "OnAfterLabelEdit" that needs to be resorted
        /// </summary>
        private TreeNode m_AfterLabelEditNode;

        /// <summary>
        /// The delegate for resorting
        /// </summary>
        private delegate void InvokedMethod();

        /// <summary>
        /// Invoked method to do a resort
        /// </summary>
        private void ReSortAfterLabelEdit()
        {
            ReSortNodes(m_AfterLabelEditNode);
            BeginInvoke(new InvokedMethod(ReSelectAfterLabelEdit));
        }

        /// <summary>
        /// Invoked method to reselect the edited node
        /// </summary>
        private void ReSelectAfterLabelEdit()
        {
            SelectedNode = m_AfterLabelEditNode;
            m_AfterLabelEditNode = null;
        }

        /// <summary>
        /// ReSort elements in the parent of <c>node</c>
        /// </summary>
        /// <remarks>
        /// Get the parent of this node and resort this node in the
        /// collection of nodes. We only operate on this node and we
        /// assume all nodes are already sorted except for this node
        /// </remarks>
        /// <param name="node">The node to sort</param>
        private void ReSortNodes(TreeNode node)
        {
            // We need to sort the node and rename it
            TreeNode parent = node.Parent;

            if (parent != null) {
                int newindex = -1;
                int curindex = -1;

                System.Globalization.CompareInfo comp =
                    System.Globalization.CultureInfo.CurrentCulture.CompareInfo;

                for (int i = 0; i < parent.Nodes.Count; i++) {
                    TreeNode tnode = parent.Nodes[i];

                    // We assume that the collection is already sorted
                    if (newindex == -1 &&
                        comp.Compare(node.Text, tnode.Text) < 0) {
                        newindex = i;
                    }
                    if (node == tnode) {
                        curindex = i;
                    }
                }

                if (curindex != -1) {
                    // We found the node we're editing.
                    if (newindex == -1) {
                        // This node is to be put at the end
                        newindex = parent.Nodes.Count - 1;
                    }

                    if (curindex < newindex) {
                        --newindex;
                    }

                    SelectedNode = null;
                    BeginUpdate();
                    parent.Nodes.RemoveAt(curindex);
                    parent.Nodes.Insert(newindex, node);
                    EndUpdate();
                }
            }
        }

        /// <summary>
        /// If we should enable Drag and Drop scrolling
        /// </summary>
        private bool m_DragDropScrolling;

        /// <summary>
        /// Turns on or off scrolling of the control when doing a Drag/Drop
        /// </summary>
        /// <remarks>
        /// Setting this property while the user is performing a drag/drop
        /// operation will stop scrolling.
        /// <para>Note, on Windows Vista, scrolling appears to be enabled
        /// regardless of this option. Enabling this makes for faster
        /// scrolling.</para>
        /// <para>On Windows XP SP3, scrolling isn't supported at all, unless
        /// you set this option.</para>
        /// </remarks>
        public virtual bool EnableDragDropScrolling
        {
            get
            {
                return m_DragDropScrolling;
            }
            set
            {
                if (m_DragDropScrolling != value) {
                    m_TreeViewScrollTimer.Enabled = false;
                    m_DragDropScrolling = value;
                }
            }
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.TreeView.ItemDrag" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.Windows.Forms.ItemDragEventArgs" /> that contains the event data.</param>
        protected override void OnItemDrag(ItemDragEventArgs e)
        {
            base.OnItemDrag(e);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.DragEnter" /> event.
        /// </summary>
        /// <param name="drgevent">A <see cref="T:System.Windows.Forms.DragEventArgs" /> that contains the event data.</param>
        protected override void OnDragEnter(DragEventArgs drgevent)
        {
            CheckScrolling(new Point(drgevent.X, drgevent.Y));
            base.OnDragEnter(drgevent);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.DragLeave" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnDragLeave(EventArgs e)
        {
            m_TreeViewScrollTimer.Enabled = false;
            base.OnDragLeave(e);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.DragOver" /> event.
        /// </summary>
        /// <param name="drgevent">A <see cref="T:System.Windows.Forms.DragEventArgs" /> that contains the event data.</param>
        protected override void OnDragOver(DragEventArgs drgevent)
        {
            CheckScrolling(new Point(drgevent.X, drgevent.Y));
            base.OnDragOver(drgevent);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.DragDrop" /> event.
        /// </summary>
        /// <param name="drgevent">A <see cref="T:System.Windows.Forms.DragEventArgs" /> that contains the event data.</param>
        protected override void OnDragDrop(DragEventArgs drgevent)
        {
            m_TreeViewScrollTimer.Enabled = false;
            base.OnDragDrop(drgevent);
        }

        private void CheckScrolling(Point cursor)
        {
            if (m_DragDropScrolling) {
                Point pos = PointToClient(cursor);
                if (pos.Y <= Font.Height / 2) {
                    m_ScrollDirection = Constants.SB_LINEUP;
                    m_TreeViewScrollTimer.Enabled = true;
                } else if (pos.Y >= ClientSize.Height - Font.Height / 2) {
                    m_ScrollDirection = Constants.SB_LINEDOWN;
                    m_TreeViewScrollTimer.Enabled = true;
                } else {
                    m_TreeViewScrollTimer.Enabled = false;
                }
            }
        }

        /// <summary>
        /// Executed when the timer expires for Drag and Drop scrolling
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void m_TreeViewScrollTimer_Tick(object sender, EventArgs e)
        {
            UnsafeNativeMethods.SendMessage(Handle, Msg.WM_VSCROLL, (IntPtr)m_ScrollDirection, IntPtr.Zero);
        }
    }
}
