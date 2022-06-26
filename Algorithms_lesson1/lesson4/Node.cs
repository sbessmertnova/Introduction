﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
        public ParentLinkType? ParentLinkType
        {
            get
            {
                if (this.Parent == null)
                {
                    return null;
                }
                if (this.Parent.LeftNode == this)
                {
                    return lesson4.ParentLinkType.IsLeftChild;
                }
                else
                {
                    return lesson4.ParentLinkType.IsRightChild;
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
            if (SearchNode(tree, value) != null)
            {
                Console.WriteLine("This node already exist");
            }
            else
            {
                var root = SearchRoot(tree);
                AddNode(value, tree);
            }
        }

        public static void AddNode(int newValue, Node<int> tree)
        {
            if (newValue > tree.Value)
            {
                if (tree.RightNode == null)
                {
                    var newNode = new Node<int> { Value = newValue };
                    tree.RightNode = newNode;
                    newNode.Parent = tree;
                    return;
                }
                AddNode(newValue, tree.RightNode);
            }
            else
            {
                if (tree.LeftNode == null)
                {
                    var newNode = new Node<int> { Value = newValue };
                    tree.LeftNode = newNode;
                    newNode.Parent = tree;
                    return;
                }
                AddNode(newValue, tree.LeftNode);
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
                //var minNode = SearchMinNode(tempNode.RightNode);
                var minNode = SearchMinNode(tempNode.LeftNode);
                if (tempNode.ParentLinkType == lesson4.ParentLinkType.IsLeftChild)
                {
                    tempNode.Parent.LeftNode = minNode;
                }
                else
                {
                    tempNode.Parent.RightNode = minNode;
                }
                minNode.Parent = tempNode.Parent;
                minNode.RightNode = tempNode.RightNode;

                tempNode.Parent = null;
                tempNode.LeftNode = null;
                tempNode.RightNode = null;
            }
        }
        public static Node<int> SearchMinNode(Node<int> tree)
        {
            if (tree.LeftNode == null)
            {
                return tree;
            }

            return SearchMinNode(tree.LeftNode);
        }
        public static Node<int> SearchNode(Node<int> tree, int value)
        {
            //            switch (value.CompareTo(tree.Value))
            if (tree == null)
            {
                return null;
            }
            var comparison = tree.Value.CompareTo(value);
            Console.WriteLine($"Comparing node with value {tree.Value} with value {value}");
            switch (comparison)
            {
                case 0:
                    Console.WriteLine($"Value {value} found");
                        return tree;
                case 1:
                    Console.WriteLine($"Value {value} is less than node value {tree.Value}. Going to left node with value {tree.LeftNode?.Value}");
                    return SearchNode(tree.LeftNode, value);
                case -1:
                    Console.WriteLine($"Value {value} is more than node value {tree.Value}. Going to right node with value {tree.RightNode?.Value}");
                    return SearchNode(tree.RightNode, value);
                default: return null;
            }
        }

        public static Node<int> SearchNodeByWidth (List<Node<int>> tree, int value)
        {
            if (tree == null)
            {
                return null;
            }
            Console.WriteLine($"Searching value {value} in {string.Join(',', tree.Select(node => node.Value))}");
            var result = tree.FirstOrDefault(node => node.Value == value);
            if (result != null)
            {
                Console.WriteLine($"Value {value} found");
                return result;
            }
            var children = tree.Select(node => new List<Node<int>> { node.LeftNode, node.RightNode }).SelectMany(node=> node).Where(node=>node!=null).ToList();
            Console.WriteLine($"Value {value} not found. Searching in children");
            return SearchNodeByWidth(children, value);
        }
        public static Node<int> SearchNodeByWidth(Node<int> tree, int value) => SearchNodeByWidth(new List<Node<int>> { tree }, value);

        public static void RemoveTailNode(Node<int> tree)
        {
            switch (tree.ParentLinkType)
            {
                case lesson4.ParentLinkType.IsLeftChild:
                    tree.Parent.LeftNode = null;
                    break;
                case lesson4.ParentLinkType.IsRightChild:
                    tree.Parent.RightNode = null;
                    break;
                default:
                    throw new ArgumentOutOfRangeException("Cannot remove node without parents");
            }
            tree.Parent = null;
        }
        public static bool IsTail(Node<int> tree)
        {
            return tree.RightNode == null && tree.LeftNode == null;
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