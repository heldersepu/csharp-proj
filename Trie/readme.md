```JavaScript
    public class Trie
    {
        private class Dict<T> : Dictionary<char, T> {}
        private class Node
        {
            public Dict<Node> Leaves = new Dict<Node>();
        }
        private Node Root = new Node();
    
    
```
