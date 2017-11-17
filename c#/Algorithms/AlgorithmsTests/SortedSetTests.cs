using DataStructures;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgorithmsTests
{
    [TestClass]
    public class SortedSetTests
    {
        [TestMethod]
        public void SetCountNewSetIsZero()
        {
            var set = new SortedSet<int>();
            Assert.AreEqual(set.Count(), 0);
        }

        [TestMethod]
        public void SetCountIncreasesWithAdd()
        {
            var set = new SortedSet<int>();
            set.Insert(6);
            Assert.AreEqual(set.Count(), 1);
        }

        [TestMethod]
        public void SetCountDecreasesOnRemoveRoot()
        {
            var set = new SortedSet<int>();
            set.Insert(4);
            Assert.AreEqual(set.Count(), 1);
            set.Remove(4);
            Assert.AreEqual(set.Count(), 0);
        }


        [TestMethod]
        public void SetCountDecreasesOnRemoveInternal()
        {
            var set = new SortedSet<int>();
            set.Insert(4);
            set.Insert(6);
            Assert.AreEqual(set.Count(), 2);
            set.Remove(6);
            Assert.AreEqual(set.Count(), 1);
        }

        [TestMethod]
        public void SetInsertRetainsOrder()
        {
            var set = new SortedSet<int>();
            Assert.AreEqual(set.GetByIndex(0), default(int));
            set.Insert(3);
            Assert.AreEqual(set.GetByIndex(0), 3);
            set.Insert(2);
            Assert.AreEqual(set.GetByIndex(0), 2);
            Assert.AreEqual(set.GetByIndex(1), 3);
            set.Insert(5);
            Assert.AreEqual(set.GetByIndex(0), 2);
            Assert.AreEqual(set.GetByIndex(1), 3);
            Assert.AreEqual(set.GetByIndex(2), 5);
        }

        [TestMethod]
        public void SetFiltersDuplicates()
        {
            var set = new SortedSet<int>();
            set.Insert(5);
            Assert.AreEqual(set.Count(), 1);
            set.Insert(5);
            Assert.AreEqual(set.Count(), 1);
        }
    }
}
