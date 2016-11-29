using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    public class Program
    {
        public static void Main()
        {
            // Creates a trie tree object.
            var trie = new Trie();
            trie.Insert("word");
            trie.Insert("words");
            trie.Insert("world");
            trie.Insert("hello");
            trie.Insert("me");
            trie.Insert("a");
            var similarWords = trie.FindSimilar("b");
            foreach (var similarWord in similarWords)
            {
                Console.WriteLine("Similar word: {0}", similarWord);
            }
            Console.ReadLine();
        }
    }
}
