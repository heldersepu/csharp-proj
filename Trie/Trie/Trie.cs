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
            Node next;
            var node = Root;
            foreach (var letter in word)
            {
                if (!node.Leaves.TryGetValue(letter, out next))
                    node.Leaves.Add(letter, next = new Node());
                node = next;
            }
        }

        /// <summary>
        /// Determines whether the Trie contains the specified word
        /// </summary>
        /// <param name="word">The word to find</param>
        /// <returns>true if the Trit contains the specified word; otherwise, false.</returns>
        public bool Contains(string word)
        {
            Node next;
            var node = Root;
            foreach (var letter in word)
            {
                if (!node.Leaves.TryGetValue(letter, out next))
                    return false;
                node = next;
            }
            return true;
        }
    }
}
