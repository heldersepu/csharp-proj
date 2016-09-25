using System.Collections.Generic;

namespace Trie
{
    public class Trie
    {
        private class Dict<T> : Dictionary<char, T> {}
        private class Node
        {
            public Dict<Node> Leaves = new Dict<Node>();
        }
        private Node Root = new Node();


        /// <summary>
        /// Add a specified word to the Trie
        /// </summary>
        /// <param name="word">The word to add</param>
        public void Add(string word)
        {
            var node = Root;
            foreach (var letter in word)
            {
                if (!node.Leaves.ContainsKey(letter))
                    node.Leaves.Add(letter, new Node());
                node = node.Leaves[letter];
            }
        }

        /// <summary>
        /// Determines whether the Trie contains the specified word
        /// </summary>
        /// <param name="word">The word to find</param>
        /// <returns>true if the Trit contains the specified word; otherwise, false.</returns>
        public bool Contains(string word)
        {
            var node = Root;
            foreach (var letter in word)
            {
                if (!node.Leaves.ContainsKey(letter))
                    return false;
                node = node.Leaves[letter];
            }
            return true;
        }
    }
}
