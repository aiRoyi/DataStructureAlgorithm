using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.Contracts;
using System.Collections;

namespace DataStructure.LinearList
{
    public class MySequenceList<T>: IEnumerable
    {
        public int Capacity { get; set; }
        public int Length { get; private set; }
        public T[] elements;
        private static readonly int DefaultCapacity = 4096;
        private readonly int growSize = 1024;
        public bool AutoGrow { get; set; } 

        public MySequenceList()
        {          
            this.Capacity = DefaultCapacity;
            this.elements = new T[this.Capacity];
            this.Length = 0;
        }

        public MySequenceList(int capacity)
        {
            Contract.Requires(capacity > 0 && capacity < System.Int32.MaxValue);
            this.Capacity = capacity;
            this.elements = new T[this.Capacity];
            this.Length = 0;
        }

        public void ReSize(int capacity)
        {
            Contract.Requires(capacity >= 0);
            ResizeArray(capacity);
        }

        public MySequenceList(T[] array):this(DefaultCapacity)
        {
            Contract.Requires(array != null);
            InitSequenceList(array);
        }

        public MySequenceList(int capacity, T[] array):this(capacity)
        {
            Contract.Requires(array != null);
            InitSequenceList(array);
        }


        public void Insert(int index, T e)
        {

            if (Length == Capacity )
            {
                if (!AutoGrow)
                {
                    throw new OverflowException("Already reach max capacity");
                }
                else
                {
                    ResizeArray();
                }
            }

            if (index < 0 || index > Length)
            {
                throw new IndexOutOfRangeException("Index out of range");
            }
            if (index == Length)
            {
                elements[index] = e;
            }
            else
            {
                for (int i = Length - 1; i >= index; i--)
                {
                    elements[i + 1] = elements[i];
                }
                elements[index] = e;
            }
            this.Length++;
        }

        public void Set(int index, T e)
        {
            if (index < 0 || index > Length)
            {
                throw new IndexOutOfRangeException("Already reach max capacity");
            }
            elements[index] = e;
        }

        public T Get(int index)
        {
            if (index < 0 || index > Length)
            {
                throw new IndexOutOfRangeException("Already reach max capacity");
            }
            return elements[index] ;
        }

        public void Remove(int index)
        {
            if (index < 0 || index >= Length)
            {
                throw new IndexOutOfRangeException("Index out of range");
            }
            for (int i = index; i < Length; i++)
            {
                elements[i] = elements[i + 1];
            }
            this.Length--;
        }

        public T PopFront()
        {
            if(this.elements == null || this.Length <= 0)
            {
                return default(T);
            }
            var value = Get(0);
            Remove(0);
            return value;
        }

        public T PopBack()
        {
            if (this.elements == null || this.Length <= 0)
            {
                return default(T);
            }
            var value = Get(this.Length - 1);
            Remove(this.Length - 1);
            return value;
        }

        public void PushFront(T e)
        {
            this.Insert(0, e);
        }

        public void PushBack(T e)
        {
            this.Insert(this.Length, e);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.elements.GetEnumerator();
        }

        void InitSequenceList(T[] array)
        {
            if (array.Length <= this.Capacity)
            {
                Array.Copy(array, elements, array.Length);
                this.Length = array.Length;
            }
            else
            {
                if (AutoGrow)
                {
                    try
                    {
                        do
                        {
                            this.elements = new T[this.Capacity + growSize];
                            this.Capacity += growSize;
                            Array.Copy(array, elements, array.Length);
                            this.Length = array.Length;
                        } while (this.Capacity < array.Length);
                    }
                    catch (Exception)
                    {
                        throw new OutOfMemoryException("out of memory");
                    }
                }
                else
                {
                    throw new IndexOutOfRangeException("Index out of range");
                }
            }
        }

        void ResizeArray(int capacity)
        {
            try
            {
                var newElement = new T[capacity];
                if (this.Length > capacity)
                {
                    this.Length = capacity;
                }
                Array.Copy(this.elements, newElement, this.Length);
                this.Capacity = capacity;
                this.elements = newElement;
            }
            catch (Exception)
            {
                throw new OutOfMemoryException("out of memory");
            }
        }

        void ResizeArray()
        {
            ResizeArray(this.Capacity + growSize);
        }
    }
}
