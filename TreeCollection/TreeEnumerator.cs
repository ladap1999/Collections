using System.Collections;

namespace TreeCollection;

public class TreeEnumerator<T> : IEnumerator<T>
{
    private readonly bool isReversed;
    private readonly Stack<Node<T>> stack = new Stack<Node<T>>();
    private Node<T> current;
    object IEnumerator.Current => Current;
    public T Current
    {
        get
        {
            if (current == null)
            {
                throw new InvalidOperationException();
            }

            return current.Value;
        }
    }

    public TreeEnumerator(Node<T> root, bool isReversed)
    {
        this.isReversed = isReversed;
        current = null;
        Initialize(root);
    }

    private void Initialize(Node<T> node)
    {
        if (node == null)
        {
            return;
        }

        if (!isReversed)
        {
            Initialize(node.Right);
            stack.Push(node);
            Initialize(node.Left);
        }
        else
        {
            Initialize(node.Left);
            stack.Push(node);
            Initialize(node.Right);
        }
    }

    public bool MoveNext()
    {
        if (stack.Count == 0)
        {
            return false;
        }

        current = stack.Pop();
        return true;
    }

    public void Reset()
    {
        current = null;
        stack.Clear();
    }

    public void Dispose()
    {
        current = null;
        stack.Clear();
    }
}