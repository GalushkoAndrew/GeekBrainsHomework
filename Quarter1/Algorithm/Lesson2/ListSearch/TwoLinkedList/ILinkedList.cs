namespace GeekBrains.Learn.TwoLinkedList
{
    /// <summary>
    /// Интерфейс связанного списка
    /// </summary>
    public interface ILinkedList
    {
        /// <summary>
        /// возвращает количество элементов в списке
        /// </summary>
        int GetCount();

        /// <summary>
        /// добавляет новый элемент списка
        /// </summary>
        void AddNode(int value);

        /// <summary>
        /// добавляет новый элемент списка после определённого элемента
        /// </summary>
        /// <param name="node">добавляемый узел</param>
        /// <param name="value">после какого элемента добавить узел</param>
        void AddNodeAfter(Node node, int value);

        /// <summary>
        /// удаляет элемент по порядковому номеру
        /// </summary>
        void RemoveNode(int index);

        /// <summary>
        /// удаляет указанный элемент
        /// </summary>
        void RemoveNode(Node node);

        /// <summary>
        /// ищет элемент по его значению
        /// </summary>
        Node FindNode(int searchValue);
    }
}
