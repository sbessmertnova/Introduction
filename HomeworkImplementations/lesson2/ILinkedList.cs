using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkImplementations.lesson2
{
    public interface ILinkedList
    {
        public int GetCount(); // возвращает количество элементов в списке
        public void AddNode(int value); // добавляет новый элемент списка
        public void AddNodeAfter(Node node, int value); // добавляет новый элемент списка после определённого элемента
        public void RemoveNode(int index); // удаляет элемент по порядковому номеру
        public void RemoveNode(Node node); // удаляет указанный элемент
        public Node FindNode(int searchValue); // ищет элемент по его значению
    }
}
