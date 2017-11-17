using System;
using System.Collections.Generic;

namespace DataStructures
{
    public class BinarySearchTree<T> where T : IComparable
    {
        private BinaryTreeNode<T> _root;

        public BinarySearchTree(T value)
        {
            _root = new BinaryTreeNode<T>(value);
        }

        public void Insert(T value)
        {
            InsertRecursive(value, _root);
        }

        private static void InsertRecursive(T value, BinaryTreeNode<T> tree)
        {
            if (value.CompareTo(tree.Value) <= 0)
            {
                if (tree.Left != null)
                {
                    InsertRecursive(value, tree.Left);
                }
                else
                {
                    tree.Left = new BinaryTreeNode<T>(value);
                }
            }
            else
            {
                if (tree.Right != null)
                {
                    InsertRecursive(value, tree.Right);
                }
                else
                {
                    tree.Right = new BinaryTreeNode<T>(value);
                }
            }
        }

        public void Remove(T value)
        {
            RemoveRecursive(value, _root, null);
        }

        private void RemoveRecursive(T value, BinaryTreeNode<T> node, BinaryTreeNode<T> parent)
        {
            var isRoot = parent == null;
            var compare = value.CompareTo(node.Value);

            if (compare < 0) RemoveRecursive(value, node.Left, node);
            else if (compare > 0) RemoveRecursive(value, node.Right, node);
            else
            {
                // This node is to be deleted.
                if(!isRoot) compare = node.Value.CompareTo(parent.Value);

                var LeftNull = node.Left == null;
                var RightNull = node.Right == null;

                if (!LeftNull && !RightNull)
                {
                    // Both exist, hard case: replace with highest left
                    var current = node.Left;
                    BinaryTreeNode<T> localParent = node;
                    while (current.Right != null)
                    {
                        localParent = current;
                        current = current.Right;
                    }
                    localParent.Right = current.Left;

                    current.Right = node.Right;
                    current.Left = node.Left;

                    if (isRoot) _root = current;
                }
                else if (!LeftNull)
                    if (isRoot)
                    {
                        _root = _root.Left;
                    }
                    else
                    {
                        // Left exists, so right doesn't 
                        if (compare <= 0)
                            parent.Left = node.Left;
                        else
                            parent.Right = node.Left;
                    }
                else if (!RightNull)
                    if (isRoot)
                    {
                        _root = _root.Right;
                    }
                    else
                    {
                        // Right exists, so left doesn't
                        if (compare <= 0)
                            parent.Left = node.Right;
                        else
                            parent.Right = node.Right;
                    }
                else
                {
                    if (isRoot) return; // Don't remove the last node in the tree
                    if (compare <= 0)
                        parent.Left = null;
                    else
                        parent.Right = null;
                }
            }
        }

        public int Depth()
        {
            return DepthRecursive(_root, 0);
        }

        private static int DepthRecursive(BinaryTreeNode<T> tree, int depth)
        {
            depth++;
            var depthLeft = tree.Left != null? DepthRecursive(tree.Left, depth) : 0;
            var depthRight = tree.Right != null? DepthRecursive(tree.Right, depth) : 0;

            var max = depthLeft >= depthRight ? depthLeft: depthRight;
            max = max >= depth? max: depth;

            return max;
        }

        public int Count()
        {
            return CountRecursive(_root);
        }

        private static int CountRecursive(BinaryTreeNode<T> tree)
        {
            var leftCount = tree.Left != null ? CountRecursive(tree.Left) : 0;
            var rightCount = tree.Right != null ? CountRecursive(tree.Right) : 0;

            return leftCount + rightCount + 1;
        }

        public List<T> toList()
        {
            var nodeList = new List<T>();
            toListRecursive(_root, nodeList);
            return nodeList;
        }

        private static void toListRecursive(BinaryTreeNode<T> node, ICollection<T> nodeList)
        {
            var leftNull = node.Left == null;
            var rightNull = node.Right == null;

            if (!leftNull) toListRecursive(node.Left, nodeList);

            nodeList.Add(node.Value);

            if (!rightNull) toListRecursive(node.Right, nodeList);
        }

        public List<T> LeafNodes()
        {
            var leafNodes = new List<T>();
            LeafNodesRecursive(_root, leafNodes);
            return leafNodes;
        }

        private static void LeafNodesRecursive(BinaryTreeNode<T> node, ICollection<T> leafNodes)
        {
            var leftNull = node.Left == null;
            var rightNull = node.Right == null;

            if (!leftNull) LeafNodesRecursive(node.Left, leafNodes);

            if (leftNull && rightNull) leafNodes.Add(node.Value);

            if (!rightNull) LeafNodesRecursive(node.Right, leafNodes);
        }

        public List<T> InternalNodes()
        {
            var internalNodes = new List<T>();
            InternalNodesRecursive(_root, internalNodes);
            return internalNodes;
        }

        private static void InternalNodesRecursive(BinaryTreeNode<T> node, ICollection<T> internalNodes)
        {
            var leftNotNull = node.Left != null;
            var rightNotNull = node.Right != null;

            if (leftNotNull) InternalNodesRecursive(node.Left, internalNodes);

            if (leftNotNull || rightNotNull) internalNodes.Add(node.Value);

            if (rightNotNull) InternalNodesRecursive(node.Right, internalNodes);
        }

        public override string ToString()
        {
            return _root.ToString();
        }
    }
}
