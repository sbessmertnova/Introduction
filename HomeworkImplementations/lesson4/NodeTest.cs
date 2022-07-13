using System;

namespace HomeworkImplementations.lesson4
{
    public class NodeTest
    {
        private const int newNodeValue = 15;
        private const int valueForSearch = 3;
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

            root.AddNode(root, newNodeValue);
            Console.WriteLine($"Проверка метода добавления. Дерево после добавления нового узла со значением {newNodeValue}");
            root.PreOrderTravers(root);

            root.RemoveNode(root, newNodeValue);
            Console.WriteLine($"Проверка метода удаления. Дерево после удаления хвостового узла со значением {newNodeValue}");
            root.PreOrderTravers(root);

            root.RemoveNode(root, node6.Value);
            Console.WriteLine($"Проверка метода удаления. Дерево после удаления узла из середины дерева со значением {node6.Value}");
            root.PreOrderTravers(root);

            root.AddNode(root, node6.Value);
            Console.WriteLine($"Возвращаем удаленный узел со значением {node6.Value}. " +
                $"Дерево после возвращения узла:");
            root.PreOrderTravers(root);

            var foundNode = Node<int>.SearchNode(root, valueForSearch);
            Console.WriteLine($"Проверка метода поиска. Найденный узел со значением {valueForSearch}:{Environment.NewLine}" +
                $"Value: {foundNode.Value} {Environment.NewLine}" +
                $"Left node value: {foundNode.LeftNode?.Value}{Environment.NewLine}" +
                $"Right node value: {foundNode.RightNode?.Value}){Environment.NewLine}");
        }
    }
}