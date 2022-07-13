using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkImplementations.lesson5
{
    public class SearchNodeTests
    {
        private const int valueForSearch = 14;
        public static void TestNode()
        {
            var root = new Node<int>
            {
                Value = 8
            };
            var node10 = new Node<int>
            {
                Value = 10
            };
            var node14 = new Node<int>
            {
                Value = 14
            };
            var node3 = new Node<int>
            {
                Value = 3
            };
            var node1 = new Node<int>
            {
                Value = 1
            };
            var node6 = new Node<int>
            {
                Value = 6
            };
            var node4 = new Node<int>
            {
                Value = 4
            };
            var node7 = new Node<int>
            {
                Value = 7
            };

            root.RightNode = node10;
            node10.Parent = root;

            node10.RightNode = node14;
            node14.Parent = node10;

            root.LeftNode = node3;
            node3.Parent = root;

            node3.LeftNode = node1;
            node1.Parent = node3;

            node3.RightNode = node6;
            node6.Parent = node3;

            node6.LeftNode = node4;
            node4.Parent = node6;

            node6.RightNode = node7;
            node7.Parent = node6;

            root.PreOrderTravers(root);
            var foundNode = Node<int>.SearchNode(root, valueForSearch);
            Console.WriteLine($"Проверка метода поиска в глубину. Найденный узел со значением {valueForSearch}:{Environment.NewLine}" +
                $"Value: {foundNode.Value} {Environment.NewLine}" +
                $"Left node value: {foundNode.LeftNode?.Value}{Environment.NewLine}" +
                $"Right node value: {foundNode.RightNode?.Value}){Environment.NewLine}");
            foundNode = Node<int>.SearchNodeByWidth(root, valueForSearch);
            Console.WriteLine($"Проверка метода поиска в ширину. Найденный узел со значением {valueForSearch}:{Environment.NewLine}" +
               $"Value: {foundNode.Value} {Environment.NewLine}" +
               $"Left node value: {foundNode.LeftNode?.Value}{Environment.NewLine}" +
               $"Right node value: {foundNode.RightNode?.Value}){Environment.NewLine}");
        }
    }
}
