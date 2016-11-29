using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
namespace DataStructure.LinearList.Test
{
    public class MyLinkListTest
    {
        [Fact]
        void RemoveNode()
        {
            MyLinkList<int> list = new MyLinkList<int>();
            list.AddLast(1);
            list.AddLast(2);
            list.AddLast(3);
            
            Assert.Throws<IndexOutOfRangeException>(() => list.RemoveAt(-1));
            Assert.Throws<IndexOutOfRangeException>(() => list.RemoveAt(3));
            Assert.Throws<IndexOutOfRangeException>(() => list.GetElement(-1));
            Assert.Throws<IndexOutOfRangeException>(() => list.GetElement(3));
            Assert.Equal(list.GetElement(0), 1);
            Assert.Equal(list.GetElement(1), 2);
            Assert.Equal(list.GetElement(2), 3);
            list.RemoveAt(0);
            Assert.Equal(list.GetElement(0), 2);
            list.RemoveAt(1);
            Assert.Equal(list.GetElement(0), 2);
        }
    }
}
