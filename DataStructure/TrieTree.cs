using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    public enum NodeType
    {
        COMPLETED,
        UNCOMPLETED
    }
    public class Node
    {
        const int ALPHABEST_SIZE = 26;
        internal char Word { get; set; }
        internal NodeType Type { get; set; }
        internal Node[] Children;
        public Node(char word, NodeType nodeType)
        {
            this.Word = word;
            this.Type = nodeType;
            this.Children = new Node[ALPHABEST_SIZE];
        }
    }
    public class Trie
    {
        const int ALPHABET_SIZE = 26;
        private Node Root;
        private HashSet<string> HashSet;
        public Trie()
        {
            Root = CreateNode(' ');
            HashSet = new HashSet<string>();
        }
        public Node CreateNode(char word)
        {
            var node = new Node(word, NodeType.UNCOMPLETED);
            return node;
        }
        public void Insert(string word)
        {
            Node temp = Root;
            foreach (char t in word)
            {
                if (null == temp.Children[this.CharToIndex(t)])
                {
                    temp.Children[this.CharToIndex(t)] = this.CreateNode(t);
                }
                temp = temp.Children[this.CharToIndex(t)];
            }
            temp.Type = NodeType.COMPLETED;
        }
        public Node Find(string word)
        {
            if (string.IsNullOrEmpty(word))
            {
                throw new AggregateException("word");
            }
            int i = 0;
            Node temp = Root;
            var words = new HashSet<string>();
            while (i < word.Length)
            {
                if (null == temp.Children[this.CharToIndex(word[i])])
                {
                    return null;
                }
                temp = temp.Children[this.CharToIndex(word[i++])];
            }
            if (temp != null && NodeType.COMPLETED == temp.Type)
            {
                HashSet = new HashSet<string> { word };
            }
            return temp;
        }
        public HashSet<string> FindSimilar(string word)
        {
            Node node = Find(word);
            DFS(word, node);
            return HashSet;
        }
        public void DFS(string prefix, Node node)
        {
            if(node == null)
            {
                Console.WriteLine("no result");
                return;
            }
            for (int i = 0; i < ALPHABET_SIZE; i++)
            {
                if (node.Children[i] != null)
                {
                    DFS(prefix + node.Children[i].Word, node.Children[i]);
                    if (NodeType.COMPLETED == node.Children[i].Type)
                    {
                        HashSet.Add(prefix + node.Children[i].Word);
                    }
                }
            }
        }
        private int CharToIndex(char ch)
        {
            return ch - 'a';
        }
    }
}
