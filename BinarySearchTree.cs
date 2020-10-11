using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructures.Trees
{
    abstract class TreeNode<T> where T : IComparable<T>
    {
        public T Value{get; set;}
        public TreeNode(T initialValue)
        {
            this.Value = initialValue;
        }
    }

    public class BinarySearchTree<T> : IEnumerable<T> where T : IComparable<T>
    {
        public int Count {get; private set;}
        private class BinaryTreeNode : TreeNode<T>
        {
            public BinaryTreeNode RightChild;
            public BinaryTreeNode LeftChild;
            public BinaryTreeNode(T intialValue) : base(intialValue) 
            {
                this.RightChild = null;
                this.LeftChild = null;
            }
        }

        private BinaryTreeNode root;

        public BinarySearchTree(T initialValue)
        {
            this.root = new BinaryTreeNode(initialValue);
            this.Count = 1;
        }

        public BinarySearchTree() 
        {
            this.root = null;
            this.Count = 0;
        }

        public void Insert(T value)
        {
            if(this.root == null)
            {
                this.root = new BinaryTreeNode(value);
                this.Count++;
            }
            else
            {
                var currentNode = this.root;
                while(currentNode != null)
                {
                    if (value.CompareTo(currentNode.Value) >= 0)
                    {
                        if(currentNode.RightChild == null)
                        {
                            currentNode.RightChild = new BinaryTreeNode(value);
                            this.Count++;
                            break;
                        }
                        else
                        {
                            currentNode = currentNode.RightChild;
                        }
                    }
                    else if(value.CompareTo(currentNode.Value) < 0)
                    {
                        if(currentNode.LeftChild == null)
                        {
                            currentNode.LeftChild = new BinaryTreeNode(value);
                            this.Count++;
                            break;
                        }
                        else
                        {
                            currentNode = currentNode.LeftChild;
                        }
                    }
                }
            }
        }
   
        public bool Contains(T value)
        {
            if(this.root == null)
            {
                return false;
            }
            else
            {
                var currentNode = this.root;
                while(currentNode != null)
                {
                    if(value.CompareTo(currentNode.Value) > 0)
                    {
                        if(currentNode.RightChild == null)
                        {
                            return false;
                        }
                        else
                        {
                            currentNode = currentNode.RightChild;
                        }
                    }
                    else if(value.CompareTo(currentNode.Value) < 0)
                    {
                        if(currentNode.LeftChild == null)
                        {
                            return false;
                        }
                        else
                        {
                            currentNode = currentNode.LeftChild;
                        }
                    }
                    else if(value.CompareTo(currentNode.Value) == 0)
                    {
                        return true;
                    }
                }
                return false;
            }
        }
    
        public int GetHeight()
        {
            return 0 + Height(this.root);
        }

        private int Height(BinaryTreeNode node)
        {
            if(node == null)
            {
                return 0;
            }
            else
            {
                return 1 + Math.Max(Height(node.LeftChild), Height(node.RightChild));
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            Stack<BinaryTreeNode> stack = new Stack<BinaryTreeNode>();
            var currentNode = this.root;
            while(currentNode != null || stack.Count > 0)
            {
                while(currentNode != null)
                {
                    stack.Push(currentNode);
                    currentNode = currentNode.LeftChild;
                }
                currentNode = stack.Pop();
                yield return currentNode.Value;
                currentNode = currentNode.RightChild;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}