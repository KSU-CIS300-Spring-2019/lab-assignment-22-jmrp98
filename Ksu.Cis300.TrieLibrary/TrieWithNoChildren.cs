/*TrieWithNoChildren.cs
 * Jose Mateus Raitz
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksu.Cis300.TrieLibrary
{
    /// <summary>
    /// A node of a trie with no children.
    /// </summary>
    public class TrieWithNoChildren : ITrie

    {
        /// <summary>
        /// Field that indicates wheter the the empty string us stored in the trie rooted at this node.
        /// </summary>
        private bool _emptyAtThisNode = false;

        /// <summary>
        /// Adds the given string to the trie rooted at this node.
        /// </summary>
        /// <param name="s">The string to add.</param>
        public ITrie Add(string s)
        {
            if (s == "")
            {
                _emptyAtThisNode = true;
            }
            else
            {
                return new TrieWithOneChild(s, _emptyAtThisNode);
            }
            return this;
        }

        /// <summary>
        /// Gets whether the trie rooted at this node contains the given string.
        /// </summary>
        /// <param name="s">The string to look up.</param>
        /// <returns>Whether the trie rooted at this node contains s.</returns>
        public bool Contains(string s)
        {
            if (s == "")
            {
                return _emptyAtThisNode;
            }
            return false;
        }
    }
}
