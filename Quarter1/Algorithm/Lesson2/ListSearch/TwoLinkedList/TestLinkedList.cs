using System;

namespace GeekBrains.Learn.TwoLinkedList
{
    class TestLinkedList
    {
        public void StartTest()
        {
            LinkedList linkedList = new();

            linkedList.AddNode(321);
            linkedList.Print();

            linkedList.AddNode(77);
            linkedList.Print();

            linkedList.AddNode(100500);
            linkedList.Print();

            linkedList.AddNodeAfter(linkedList.FirstNode, 15);
            linkedList.Print();

            linkedList.AddNodeAfter(linkedList.LastNode, 18);
            linkedList.Print();

            linkedList.RemoveNode(3);
            linkedList.Print();

            var node = linkedList.FindNode(100500);
            if (node != null)
            {
                Console.WriteLine("Найден узел со значением 100500");
                linkedList.Print();

                linkedList.RemoveNode(node);
                linkedList.Print();
            }
            else
            {
                Console.WriteLine("Не найден узел со значением 100500");
                linkedList.Print();
            }

            try
            {
                linkedList.RemoveNode(125);
                linkedList.Print();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка при удалении узла с индексом 125. " + ex.Message);
            }

            node = new Node();
            try
            {
                linkedList.RemoveNode(node);
                linkedList.Print();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка при удалении узла, отсутствующего в списке. " + ex.Message);
            }

            linkedList.RemoveNode(1);
            linkedList.Print();

            linkedList.RemoveNode(1);
            linkedList.Print();

            linkedList.RemoveNode(1);
            linkedList.Print();

        }
    }
}
