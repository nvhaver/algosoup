using System;
using DataStructures;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgorithmsTests
{
    [TestClass]
    public class BinarySearchTreeTests
    {
        
        [TestMethod]
        public void BSTDepthEmptyTreeIsOne()
        {
            var binaryTree = new BinarySearchTree<string>("root");

            Console.WriteLine(binaryTree.Depth());
            Assert.AreEqual(binaryTree.Depth(), 1);
        }

        [TestMethod]
        public void BSTDepthGrowsCorrectly()
        {
            var binaryTree = new BinarySearchTree<int>(6);

            for (var i = 0; i < 10; i++)
            {
                binaryTree.Insert(i);
            }

            Console.WriteLine(binaryTree.Depth());
            Assert.AreEqual(binaryTree.Depth(), 8);

        }

        [TestMethod]
        public void BSTCountIncreasesOnInsert()
        {
            var binaryTree = new BinarySearchTree<int>(5);
            Assert.AreEqual(binaryTree.Count(), 1);
            binaryTree.Insert(4);
            Assert.AreEqual(binaryTree.Count(), 2);
        }

        [TestMethod]
        public void BSTCountDecreasesOnRemoveLeaf()
        {
            var binaryTree = new BinarySearchTree<int>(5);
            binaryTree.Insert(4);
            Assert.AreEqual(binaryTree.Count(), 2);
            binaryTree.Remove(4);
            Assert.AreEqual(binaryTree.Count(), 1);
        }

        [TestMethod]
        public void BSTCountDecreasesOnRemoveRoot()
        {
            var binaryTree = new BinarySearchTree<int>(5);
            binaryTree.Insert(4);
            Assert.AreEqual(binaryTree.Count(), 2);
            binaryTree.Remove(5);
            Assert.AreEqual(binaryTree.Count(), 1);
        }

        [TestMethod]
        public void BSTCountDecreasesOnRemoveInternal()
        {
            var binaryTree = new BinarySearchTree<int>(5);
            binaryTree.Insert(3);
            binaryTree.Insert(4);
            Assert.AreEqual(binaryTree.Count(), 3);
            binaryTree.Remove(4);
            Assert.AreEqual(binaryTree.Count(), 2);
        }
    }
}
