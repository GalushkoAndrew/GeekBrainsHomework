namespace GeekBrains.Learn.TwoLinkedList
{
    /// <summary>
    /// Узел двусвязного списка
    /// </summary>
    public class Node
    {
        /// <summary>
        /// Значение узла
        /// </summary>
        public int Value { get; set; }

        /// <summary>
        /// Ссылка на следующий узел
        /// </summary>
        public Node NextNode { get; set; }

        /// <summary>
        /// Ссылка на предыдущий узел
        /// </summary>
        public Node PrevNode { get; set; }
    }
}
