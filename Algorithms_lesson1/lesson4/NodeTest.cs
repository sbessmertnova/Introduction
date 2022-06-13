using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms_lesson1.lesson4
{
   public class NodeTest
    {
        private const int newNodeValue = 15;
        private const int valueForSearch = 6;
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
            node10.RightNode = node14;
            root.LeftNode = node3;
            node3.LeftNode = node1;
            node3.RightNode = node6;
            node6.LeftNode = node4;
            node6.RightNode = node7;

            root.PreOrderTravers(root);
           
            root.AddNode(root, newNodeValue);
            Console.WriteLine($"Проверка метода добавления. Дерево после добавления нового узла со значением {newNodeValue}");
            root.PreOrderTravers(root);
            
            root.RemoveNode(root, newNodeValue);
            Console.WriteLine($"Проверка метода удаления. Дерево после удаления хвостового узла со значением {newNodeValue}");
            root.PreOrderTravers(root);
            
            root.RemoveNode(root, node4.Value);
            Console.WriteLine($"Проверка метода удаления. Дерево после удаления узла из середины дерева со значением {node4.Value}");
            root.PreOrderTravers(root);
            
            root.AddNode(root, node4.Value);
            Console.WriteLine($"Возвращаем удаленный узел со значением {node4.Value}. " +
                $"Дерево после возвращения узла:");
            root.PreOrderTravers(root);

            var foundNode = Algorithms_lesson1.lesson4.Node<int>.SearchNode(root, valueForSearch);
            Console.WriteLine($"Проверка метода поиска. Найденный узел со значением {valueForSearch}:" +
                $"\nValue: {foundNode.Value}" +
                $"\nLeft node value: {foundNode.LeftNode.Value}" +
                $"\nRight node value: {foundNode.RightNode.Value})");
        }
    }
}
