using Homework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkImplementations
{
    public class HomeworkImplementation : IHomework
    {
        public void Lesson1A()
        {
            lesson1.Lesson1.Task1();
        }

        public void Lesson1B()
        {
            lesson1.Lesson1.Task2();
        }

        public void Lesson1C()
        {
            lesson1.Lesson1.Task3();
        }

        public void Lesson2()
        {
            lesson2.Node.Test();
        }

        public void Lesson3()
        {
            lesson3.PointsLengthTests.Tests();
        }

        public void Lesson4()
        {
            lesson4.NodeTest.TestNode();
        }

        public void Lesson5()
        {
            lesson5.SearchNodeTests.TestNode();
        }

        public void Lesson7()
        {
            lesson7.QueenProblem.Test();
        }

        public void Lesson8()
        {
            lesson8.CountingSort.Output();
        }
    }
}
