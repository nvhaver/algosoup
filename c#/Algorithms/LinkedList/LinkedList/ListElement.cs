namespace DataStructures
{
    /// <summary>
    /// Double linked list element implementation.
    /// </summary>
    class ListElement<T>
    {
        public ListElement<T> Next { get; set; }
        public ListElement<T> Previous { get; set; }
        public T Value { get; }

        public ListElement(T value, ListElement<T> previous = null)
        {
            Value = value;
            Previous = previous;
        }

        public override string ToString()
        {
            var next = Next != null ? $" -> {Next}" : string.Empty;
            return $"[{Value}]{next}";
        }
    }
}
