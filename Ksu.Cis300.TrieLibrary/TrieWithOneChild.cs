/* TrieWithOneChild.cs     
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
    /// A node of a trie with one child.
    /// </summary>
    class TrieWithOneChild : ITrie
    {
        /// <summary>
        /// Field that indicates whether the trie contains the empty string.
        /// </summary>
        private bool _hasEmptyString;
        /// <summary>
        /// The only child of this trie.
        /// </summary>
        private ITrie _onlyChild;
        /// <summary>
        /// The label of the only child of this trie.
        /// </summary>
        private char _label;

        /// <summary>
        /// Adds the given string to the trie rooted at this node.
        /// </summary>
        /// <param name="s">The string to add.</param>
        public ITrie Add(string s)
        {
            if (s == "")
            {
                _hasEmptyString = true;
            }
            else
            {
                if(s[0]==_label)
                {
                    _onlyChild = _onlyChild.Add(s.Substring(1));
                }
                else
                {
                    return new TrieWithManyChildren(s,_hasEmptyString,_label,_onlyChild);
                }
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
                return _hasEmptyString;
            }
            else
            {
                if(s[0]==_label)
                {
                    return _onlyChild.Contains(s.Substring(1));
                }

                return false;

            }

        }

        /// <summary>
        /// Constructs the Trie with One Child.
        /// </summary>
        /// <param name="s">The string to be stored.</param>
        /// <param name="b">Whether the trie at the node has an empty string.</param>
        public TrieWithOneChild(string s, bool b)
        {
            if(s=="" || s[0]<'a' || s[0]>'z')
            {
                throw new ArgumentException();
            }

            _hasEmptyString = b;
            _label = s[0];
            _onlyChild = new TrieWithNoChildren().Add(s.Substring(1));
        }

    }
}
