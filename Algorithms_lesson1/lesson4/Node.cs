using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms_lesson1.lesson4
{
    public enum ParentLinkType
    {
        IsLeftChild,
        IsRightChild
    }
    public class Node<T>
    {
        public T Value { get; set; }
        public Node<T> LeftNode { get; set; }
        public Node<T> RightNode { get; set; }
        public Node<T> Parent { get; set; }
        public ParentLinkType? GetParentLinkType
        {
            get
            {
                if (this.Parent.LeftNode == null)
                {
                    return null;
                }
                if (this.Parent.LeftNode == this)
                {
                    return ParentLinkType.IsLeftChild;
                }
                else
                {
                    return ParentLinkType.IsRightChild;
                }
            }
        }

        public void PreOrderTravers(Node<T> root)
        {
            if (root != null)
            {
                Console.WriteLine($" {root.Value}");
                PreOrderTravers(root.LeftNode);
                PreOrderTravers(root.RightNode);
            }
        }
        public void AddNode(Node<int> tree, int value)
        {
            if (SearchNode(tree, value)!=null)
            {
                Console.WriteLine("This node already exist");
            }
            else
            {
                var root = SearchRoot(tree);
                SearchSpace(root.Value, tree);
            }
        }
        public static void SearchSpace(int rootValue, Node<int> tree)
        {
            if (tree.Value>rootValue)
            {
                if (tree.RightNode == null)
                {
                    var newNode = new Node<int> { Value = tree.Value };
                    tree.Parent.RightNode = newNode;
                }
                SearchSpace(tree.Value, tree.RightNode);
            }
            else
            {
                if (tree.LeftNode == null)
                {
                    var newNode = new Node<int> { Value = tree.Value };
                    tree.Parent.LeftNode = newNode;
                }
                SearchSpace(tree.Value, tree.LeftNode);
            }
        }
        public static Node<int> SearchRoot(Node<int> tree)
        {
            if (tree.Parent == null)
            {
                return tree;
            }
            else
            {
                return SearchRoot(tree.Parent);
            }      
        }
        public void RemoveNode(Node<int> tree, int value)
        {
            var tempNode = SearchNode(tree, value);
            if (IsTail(tempNode))
            {
                RemoveTailNode(tempNode);
            }
            else if (OnlyOneChild(tempNode))
            {
                var nodeToReplace = OnlyLeftChild(tempNode) ? tempNode.LeftNode : tempNode.RightNode;

                if (tempNode.Parent.RightNode == tempNode)
                {
                    tempNode.Parent.RightNode = nodeToReplace;
                }
                else
                {
                    tempNode.Parent.LeftNode = nodeToReplace;
                }
            }
            else
            {
                var minNode = SearchMinNode(tempNode.RightNode);
                if (tempNode.GetParentLinkType == ParentLinkType.IsLeftChild)
                {
                    tempNode.Parent.LeftNode = minNode;
                }
                else
                {
                    tempNode.Parent.RightNode = minNode;
                }
            }
        }
        public static Node<int> SearchMinNode(Node<int> tree)
        {
            if (tree.LeftNode==null)
            {
                return tree;
            }
            else
            {
                return SearchMinNode(tree);
            }
        }
        public static Node<int> SearchNode(Node<int> tree, int value)
        {
            switch (value.CompareTo(tree.Value))
            {
                case 0: return tree;
                case 1: return SearchNode(tree.LeftNode, value);
                case -1: return SearchNode(tree.RightNode, value);
                default: return null;
            }
        }
        public static void RemoveTailNode(Node<int>tree)
        {
            if (tree.Parent.LeftNode == tree)
            {
                tree.Parent.LeftNode = null;
            }
            else
            {
                tree.Parent.RightNode = null;
            }
        }
        public static bool IsTail(Node<int> tree)
        {
            return tree.RightNode == null&& tree.LeftNode == null;
        }
        public static bool OnlyLeftChild(Node<int> tree)
        {
            return tree.LeftNode != null && tree.RightNode == null;
        }
        public static bool OnlyRightChild(Node<int> tree)
        {
            return tree.LeftNode == null && tree.RightNode != null;
        }
        public static bool OnlyOneChild(Node<int> tree)
        {
            return OnlyLeftChild(tree) || OnlyRightChild(tree);
        }
    }
}
