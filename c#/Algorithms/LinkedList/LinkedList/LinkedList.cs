namespace DataStructures
{
    public class LinkedList<T>
    {
        private ListElement<T> _root;
        private ListElement<T> _last;

        public LinkedList()
        {
            _root = null;
            _last = null;
        }

        public int Count()
        {
            if (_root == null) return 0;

            var current = _root;
            var count = 1;
            while (current.Next != null)
            {
                current = current.Next;
                count++;
            }
            return count;
        }

        /// <summary>
        /// Append an element to the end of the list.
        /// </summary>
        /// <param name="value"></param>
        public void Append(T value)
        {
            // Option 1: Follow the list elements' chain until the end. [O(n)]
            // Option 2: Keep track of the last element. [O(c)]
            if (_root == null)
            {
                _root = new ListElement<T>(value);
                _last = _root;
            }
            else
            {
                _last.Next = new ListElement<T>(value, _last);
                _last = _last.Next;
            }
        }

        /// <summary>
        /// Remove the last item of the list. Note that the root element cannot be removed. [O(c)]
        /// </summary>
        /// <returns></returns>
        public T Pop()
        {
            if (_root == null) return default(T);

            var value = _last.Value;
            if (_last.Previous == null) return value;
            _last = _last.Previous;
            _last.Next = null;
            return value;
        }

        /// <summary>
        /// Generic contains check which does not convert the elements to strings.
        /// Goes through the list at most once, could stop sooner [O(n/2) on average].
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Contains(T value)
        {
            if (_root == null) return false;
            if (value.Equals(_root.Value)) return true;

            var current = _root;
            while (current.Next != null)
            {
                if (value.Equals(current.Value))
                    return true;
                current = current.Next;
            }

            return false;
        }

        /// <summary>
        /// Print out all contents of the linked list.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return _root?.ToString() ?? string.Empty;
        }
    }
}
