using System;

namespace DataStructures
{
    public class SortedSet<T> where T : IComparable
    {
        private ListElement<T> _root;

        public void Insert(T value)
        {
            if (_root == null)
            {
                _root = new ListElement<T>(value);
            }
            else
            {
                InsertRecursive(value, _root);
            }
        }

        private void InsertRecursive(T value, ListElement<T> current)
        {
            var compare = value.CompareTo(current.Value);
            if (compare < 0)
            {
                // Insert before
                var newElement = new ListElement<T>(value);
                if (current == _root)
                {
                    newElement.Next = _root;
                    _root.Previous = newElement;
                    _root = newElement;
                }
                else
                {
                    newElement.Next = current;
                    newElement.Previous = current.Previous;
                    current.Previous.Next = newElement;
                    current.Previous = newElement;
                }
            }
            else if (compare == 0)
            {
                // Do not insert (only unique elements)
            }
            else
            {
                // Go to next node. If there is no next node, insert as last.
                if (current.Next != null)
                {
                    InsertRecursive(value, current.Next);
                }
                else
                {
                    var newElement = new ListElement<T>(value);
                    newElement.Previous = current;
                    current.Next = newElement;
                }
            }
        }

        public void Remove(T value)
        {
            if (_root == null) return;

            var current = _root;
            while (!current.Value.Equals(value) && current.Next != null)
            {
                current = current.Next;
            }

            if (!current.Value.Equals(value)) return;
            if (current == _root)
            {
                if (current.Next == null)
                {
                    _root = null;
                }
                else
                {
                    _root.Next.Previous = null;
                    _root = _root.Next;
                }
            }
            else
            {
                if (current.Next != null)
                {
                    current.Next.Previous = current.Previous;
                }
                current.Previous.Next = current.Next;
            }
        }

        public int Count()
        {
            if (_root == null) return 0;

            var count = 1;
            var current = _root;

            while (current.Next != null)
            {
                count++;
                current = current.Next;
            }

            return count;
        }

        public T GetByIndex(int index)
        {
            if (_root == null) return default(T);

            var current = _root;
            for (var i = 0; i < index; i++)
            {
                current = current.Next;
            }
            return current.Value;
        }

        /// <summary>
        /// Print out all contents of the linked list.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return _root?.ToString() ?? String.Empty;
        }
    }
}
