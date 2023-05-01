using System.Collections;

namespace TreeCollection
{
    public class Tree<T> : IEnumerable<T>, IComparable<T>
    {
        private Node<T> _root;
        private bool _isReversed;

        public Tree(bool isReversed = false)
        {
            _root = null;
            this._isReversed = isReversed;
        }

        public void Add(T value)
        {
            _root = AddRecursive(_root, value);
        }

        private Node<T> AddRecursive(Node<T> current, T value)
        {
            if (current == null)
            {
                return new Node<T>(value);
            }

            if (Comparer<T>.Default.Compare(value, current.Value) == -1)
            {
                current.Left = AddRecursive(current.Left, value);
            }
            else if (Comparer<T>.Default.Compare(value, current.Value) == 1)
            {
                current.Right = AddRecursive(current.Right, value);
            }
            else
            {
                throw new Exception("An element with the same value already exists in the tree.");
            }

            return current;
        }

        public IEnumerator<T> GetEnumerator()
        {
            if (_isReversed)
            {
                return new TreeEnumerator<T>(_root, true);
            }

            return new TreeEnumerator<T>(_root, false);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<T>)this).GetEnumerator();
        }
        
        public int CompareTo(T? other)
        {
            return this.CompareTo(other);
        }
    }
}