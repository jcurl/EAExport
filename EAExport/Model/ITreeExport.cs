using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EAExport.Model
{
    /// <summary>
    /// A standard interface for exporting a tree to disk.
    /// </summary>
    public interface ITreeExport : IDisposable
    {
        /// <summary>
        /// Exports the tree.
        /// </summary>
        /// <param name="root">The root element.</param>
        /// <param name="includeRoot">if set to <c>true</c> the also export the root element, else
        /// if set to <c>false</c>, then the children are exported.</param>
        void ExportTree(EATree root, bool includeRoot);
    }
}
