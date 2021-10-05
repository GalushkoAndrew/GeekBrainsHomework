using System;

namespace GeekBrains.Learn.TwoLinkedList
{
    /// <summary>
    /// Связанный список
    /// </summary>
    public class LinkedList : ILinkedList
    {
        public void Print()
        {
            Node node = FirstNode;
            while (node != null)
            {
                Console.Write($"{ node.Value} - ");
                node = node.NextNode;
            }
            Console.WriteLine();
            Console.WriteLine(new string('-', 20));
        }

        /// <summary>
        /// первый узел списка
        /// </summary>
        public Node FirstNode { get; set; }

        /// <summary>
        /// последний узел списка
        /// </summary>
        public Node LastNode { get; set; }

        public void AddNode(int value)
        {
            if (LastNode == null)
            {
                FirstNode = new();
                LastNode = FirstNode;
            }
            else
            {
                Node node = new() { Value = value, PrevNode = LastNode };
                LastNode.NextNode = node;
                LastNode = node;
            }
        }

        public void AddNodeAfter(Node node, int value)
        {
            // проверка на существование узла в списке
            if (FindNode(node) == null)
            {
                throw new Exception("Узел не найден в списке");
            }

            Node newNode = new() { Value = value, PrevNode = node, NextNode = node.NextNode };
            if (node.NextNode != null)
            {
                node.NextNode.PrevNode = newNode;
            }

            node.NextNode = newNode;
            if (node == LastNode)
            {
                LastNode = newNode;
            }
        }

        public Node FindNode(int searchValue)
        {
            Node nodeSearch = FirstNode;

            while (nodeSearch != null)
            {
                if (nodeSearch.Value == searchValue)
                {
                    return nodeSearch;
                }

                nodeSearch = nodeSearch.NextNode;
            }

            return null;
        }

        public int GetCount()
        {
            Node nodeSearch = FirstNode;
            int count = 0;

            while (nodeSearch != null)
            {
                count++;
                nodeSearch = nodeSearch.NextNode;
            }

            return count;
        }

        public void RemoveNode(int index)
        {
            Node nodeSearch = GetNodeByIndex(index);
            if (nodeSearch == null)
            {
                throw new Exception("Узел не найден в списке");
            }

            RemoveCheckedNode(nodeSearch);
        }

        public void RemoveNode(Node node)
        {
            // проверка на существование узла в списке
            if (FindNode(node) == null)
            {
                throw new Exception("Узел не найден в списке");
            }

            RemoveCheckedNode(node);
        }

        /// <summary>
        /// Удаляет узел, существующий в списке
        /// </summary>
        private void RemoveCheckedNode(Node node)
        {
            if (node == LastNode && node == FirstNode)
            {
                LastNode = null;
                FirstNode = null;
            }
            else if (node == LastNode)
            {
                node.PrevNode.NextNode = null;
                LastNode = node.PrevNode;
            }
            else if (node == FirstNode)
            {
                node.NextNode.PrevNode = null;
                FirstNode = node.NextNode;
            }
            else
            {
                node.PrevNode.NextNode = node.NextNode;
                node.NextNode.PrevNode = node.PrevNode;
            }
        }

        /// <summary>
        /// Находит узел в списке по его индексу (начиная с 1)
        /// </summary>
        private Node GetNodeByIndex(int index)
        {
            if (index < 1)
            {
                return null;
            }

            Node nodeSearch = FirstNode;
            int count = 0;

            while (nodeSearch != null)
            {
                count++;
                if (count == index)
                {
                    return nodeSearch;
                }

                nodeSearch = nodeSearch.NextNode;
            }

            return null;
        }

        /// <summary>
        /// Находит узел в списке по ссылке на узел
        /// </summary>
        private Node FindNode(Node node)
        {
            Node nodeSearch = FirstNode;

            while (true)
            {
                if (nodeSearch == node || nodeSearch == null)
                {
                    break;
                }
                else
                {
                    nodeSearch = nodeSearch.NextNode;
                }
            }

            return nodeSearch;
        }
    }
}
