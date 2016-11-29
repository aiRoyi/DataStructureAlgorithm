using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    public class BinaryTreeNode : IEnumerable
    {
        public BinaryTreeNode Parent { get; set; }
        public List<BinaryTreeNode> Children { get; private set; }
        public BinaryTreeNode()
        {
            Children = new List<BinaryTreeNode>();
        }

        public void AddChild(params BinaryTreeNode[] nodes)
        {
            for (int i = 0; i < nodes.Length; i++)
            {
                nodes[i].Parent = this;
                Children.Add(nodes[i]);
            }
        }
        public BinaryTreeNode GetParent(BinaryTreeNode node)
        {
            return node.Parent;
        }
        public List<BinaryTreeNode> GetBrothers()
        {
            if (this.Parent != null)
            {
                BinaryTreeNode[] childsOfParent = new BinaryTreeNode[Parent.Children.Count];
                this.Parent.Children.CopyTo(childsOfParent);
                List<BinaryTreeNode> childsOfParentList = childsOfParent.ToList();
                childsOfParentList.Remove(this);
                return childsOfParentList;
            }
            return null;
        }
        public IEnumerator GetEnumerator()
        {
            return new TreeEnum(this);
        }
    }
    public class TreeEnum : IEnumerator
    {
        private BinaryTreeNode rootNode;
        private BinaryTreeNode curNode;
        Queue<BinaryTreeNode> collection;
        public TreeEnum(BinaryTreeNode _collection)
        {
            rootNode = _collection;
            collection = new Queue<BinaryTreeNode>();
            FillQueue(_collection);
            curNode = rootNode;
        }
        public void FillQueue(BinaryTreeNode _collection)
        {
            collection.Enqueue(_collection);
            if (_collection.Children != null && _collection.Children.Count > 0)
            {
                foreach (BinaryTreeNode child in _collection.Children)
                {
                    FillQueue(child);
                }
            }
        }
        public BinaryTreeNode Current
        {
            get
            {
                return curNode;
            }
        }

        public bool MoveNext()
        {
            if (collection.Count > 0)
            {
                curNode = collection.Dequeue();
                return true;
            }
            else
                return false;
        }

        public void Reset()
        {
            collection = new Queue<BinaryTreeNode>();
            FillQueue(rootNode);
            curNode = rootNode;
        }
        object IEnumerator.Current
        {
            get { return Current; }
        }
    }
    public class BinaryTree
    {
        public BinaryTreeNode rootNode { get; set; }
        public List<BinaryTreeNode> treeNodes { get; private set; }
        public BinaryTree()
        {
            rootNode = new BinaryTreeNode();
            treeNodes = new List<BinaryTreeNode>();
        }
        public BinaryTreeNode GetRoot()
        {
            return rootNode;
        }
        public void Traverse()
        {

        }
    }
}
