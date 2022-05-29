using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms_Homework2
{
    public class Node : ILinkedList
    {
        public int Value { get; set; }
        public Node NextNode { get; set; }
        public Node PrevNode { get; set; }

        public void AddNode(int value)
        {
            var nextItem = this.NextNode;
            var newNode = new Node { Value = value, PrevNode = this, NextNode = nextItem };
            this.NextNode = newNode;
            //newNode.NextNode = nextItem;


        }
        public void AddNodeAfter(Node node, int value)
        {
            var newNode = new Node { Value = value };
            var nextItem = node.NextNode;
            node.NextNode = newNode;
            newNode.NextNode = nextItem;
        }
        public Node FindNode(int searchValue)
        {
            if (Value == searchValue)
            {
                return this;
            }

            var findingNode = this;
            while(findingNode.NextNode != null)
            {
                if(findingNode.Value == searchValue)
                {
                    return findingNode;
                }
                findingNode = findingNode.NextNode;
            }
            return null;

            //if (this.NextNode != null)
            //{
            //    while (this.NextNode != null)
            //    {
            //        if (this.Value == searchValue)
            //        {
            //            return this;
            //        }
            //        this.NextNode.PrevNode = this.NextNode;
            //    }
            //    if (this.PrevNode != null)
            //    {
            //        while (this.PrevNode != null)
            //        {
            //            if (this.Value == searchValue)
            //            {
            //                return this;
            //            }
            //            this.PrevNode.NextNode = this.PrevNode;
            //        }
            //        return null;
            //    }
            //    return null;
            //}
            //else return null;
        }

        public int GetCount()
        {
            if(NextNode == null)
            {
                return 1;
            }

            var countNode = this;
            var count = 1;
            while(countNode.NextNode != null)
            {
                countNode = countNode.NextNode;
                count++;               
            }
            return count;

            //var temp = 1;
            //if (this.NextNode != null)
            //{
            //    while (this.NextNode != null)
            //    {
            //        temp++;
            //        this.NextNode = this.NextNode.NextNode;
            //    }
            //    if (this.PrevNode == null)
            //    {
            //        return temp;
            //    }
            //    else
            //    {
            //        temp++;
            //        this.PrevNode = this.PrevNode.PrevNode;
            //        return temp;
            //    }
            //}
            //else return 1;
        }

        public void RemoveNode(int index)
        {
            int currentIndex = 0;
            var currentNode = this;
            while (currentNode != null)
            {
                if (currentIndex == index - 1)
                {
                    RemoveNode(currentNode);
                }
                currentNode = currentNode.NextNode;
                currentIndex++;
            }
        }

        public void RemoveNode(Node node)
        {
            if (node.PrevNode != null)
            {
                node.PrevNode.NextNode = node.NextNode;
            }
            if(node.NextNode != null)
            {
                node.NextNode.PrevNode = node.PrevNode;
            }            
        }


        public static void Test()
        {
            var node1 = new Node { Value = 1, NextNode = null, PrevNode = null };
            node1.AddNode(5);
            node1.AddNode(3);
            node1.AddNode(2);
            var count = node1.GetCount();
            //1, 2, 3, 5

            var thirdnode = node1.FindNode(3);
            node1.AddNodeAfter(thirdnode, 3);

            //1,2,3,3,5

            node1.RemoveNode(2);
            node1.RemoveNode(thirdnode);
        }
    }
}
