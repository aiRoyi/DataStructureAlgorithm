using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using DataStructure.LinearList;
namespace DataStructure.LinearList.Test
{
    public class MySequenceListTest
    {
        [Fact]
        public void InitSequenceList()
        {
            Assert.Throws<OverflowException>(()=> { new MySequenceList<int>(-1); });
            Assert.Throws<NullReferenceException>(() => { new MySequenceList<int>(null); });
        }

        [Fact]
        public void Resize()
        {
            var array = new MySequenceList<int>(new int[2] { 1, 2 });
            array.ReSize(2);
            Assert.Equal(array.Length, 2);
            Assert.Equal(array.Capacity, 2);

            array = new MySequenceList<int>(new int[2] { 1, 2 });
            array.ReSize(1);
            Assert.Equal(array.Length, 1);
            Assert.Equal(array.Capacity, 1);
            Assert.Equal(1, array.Get(0));
            Assert.Throws<OverflowException>(()=>array.Insert(array.Length, 5));
            array.AutoGrow = true;
            array.Insert(array.Length, 5);
            Assert.Equal(array.Length, 2);
            Assert.Equal(array.Capacity, 1025);
        }

        [Fact]
        public void InsertValue()
        {
            var array = new MySequenceList<int>(new int[2] { 1, 2 });
            Assert.Equal(array.Length, 2);
            Assert.Throws<IndexOutOfRangeException>(() => { array.Insert(-1, 2); });
            array.Insert(0, 5);
            Assert.Equal(array.Get(0), 5);
        }

        [Fact]
        public void RemoveValue()
        {
            var array = new MySequenceList<int>(new int[2] { 1, 2 });
            Assert.Equal(array.Length, 2);
            Assert.Throws<IndexOutOfRangeException>(() => { array.Remove(3); });
            Assert.Throws<IndexOutOfRangeException>(() => { array.Remove(-1); });
            array.Remove(0);
            Assert.Equal(array.Length, 1);
            Assert.Equal(array.Get(0), 2);
        }

        [Fact]
        public void PushPop()
        {
            var array = new MySequenceList<int>(1024);
            array.PushBack(1);
            array.PushBack(2);
            array.PushBack(3);
            Assert.Equal(1, array.PopFront());
            Assert.Equal(2, array.PopFront());
            Assert.Equal(3, array.PopFront());
            Assert.Equal(0, array.PopFront());
        }
    }
}
