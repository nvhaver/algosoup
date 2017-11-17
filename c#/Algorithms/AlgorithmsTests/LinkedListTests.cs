using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataStructures;

namespace AlgorithmsTests
{
    [TestClass]
    public class LinkedListTests
    {
        [TestMethod]
        public void LinkedListCountInitsAtZero()
        {
            var linkedList = new LinkedList<string>();
            Assert.AreEqual(linkedList.Count(), 0);
        }

        [TestMethod]
        public void LinkedListCountIncrementsCorrectlyOnAppend()
        {
            var linkedList = new LinkedList<int>();

            for(var i = 0;i < 10;i++)
                linkedList.Append(i);
            Assert.AreEqual(linkedList.Count(), 10);
        }

        [TestMethod]
        public void LinkedListContainsInserted()
        {
            var linkedList = new LinkedList<int>();
            linkedList.Append(1);
            Console.WriteLine(linkedList);

            Assert.IsTrue(linkedList.Contains(1));
        }

        [TestMethod]
        public void LinkedListPopRemovesLast()
        {
            var linkedList = new LinkedList<int>();
            linkedList.Append(1);
            linkedList.Append(2);
            linkedList.Append(1);
            linkedList.Append(3);

            Assert.AreEqual(linkedList.Count(), 4);

            var popped = linkedList.Pop();

            Assert.AreEqual(linkedList.Count(), 3);
            Assert.AreEqual(popped, 3);
        }
    }
}
