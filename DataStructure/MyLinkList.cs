using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.Contracts;
namespace DataStructure.LinearList
{
    /// <summary>
    /// link list simple implement. 
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Node<T>
    {
        public Node<T> Next { get; set; }
        public T Data { get; set; }
    }

    public class MyLinkList<T>
    {
        private Node<T> head;        
        public int Length { get; private set; }

        public MyLinkList()
        {
            this.head = null;
            this.Length = 0;
        }

        public MyLinkList(Node<T> node)
        {
            this.head = node;
            this.Length = 1;
        }

        /// <summary>
        /// TODO: record tail to speed up insert last.
        /// </summary>
        /// <param name="data"></param>
        public void AddLast(T data)
        {
            var node = new Node<T>
            {
                Data = data,
                Next = null
            };

            if (head == null)
            {
                head = node;
            }
            else
            {
                Node<T> current = head;
                while(current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = node;
            }
            this.Length++;
        }

        public void AddLast(Node<T> node)
        {
            AddLast(node.Data);
        }

        public void AddFirst(T data)
        {
            var node = new Node<T>
            {
                Data = data,
                Next = null
            };
            Node<T> current = head;
            node.Next = current;
            head = node;            
            this.Length++;
        }

        public void AddFirst(Node<T> node)
        {
            AddFirst(node.Data);
        }

        public void RemoveAt(int index)
        {
            Contract.Requires(this.Length > 0);
            if(index < 0 || index >= Length)
            {
                throw new IndexOutOfRangeException("Index out of range");
            }
            var link = this.head;
            var prev = this.head;
            if (index == 0)
            {
                if(Length == 1)
                {
                    this.head = null;                   
                    this.Length = 0;
                }
                else
                {
                    this.head = head.Next;
                    this.Length--;
                }
            }
            else
            {
                int count = 0;
                while (link.Next != null && count < index)
                {
                    count++;
                    link = link.Next;
                    prev = link;
                }
                prev.Next = link.Next;
                link.Next = null;
                Length--;
            }
        }

        public Node<T> Get(int index)
        {
            Contract.Requires(this.Length > 0);
            if (index < 0 || index >= Length)
            {
                throw new IndexOutOfRangeException("Index out of range");
            }
            var link = this.head;
            int count = 0;
            while (link.Next != null && count < index)
            {
                count++;
                link = link.Next;
            }
            return link;
        }

        public T GetElement(int index)
        {
            Contract.Requires(this.Length > 0);
            if (index < 0 || index >= Length)
            {
                throw new IndexOutOfRangeException("Index out of range");
            }
            var link = this.head;
            int count = 0;
            while (link.Next != null && count < index)
            {
                count++;
                link = link.Next;
            }
            return link.Data;
        }
    }
}
