using System.Collections;


namespace Structures
{
    public class Node<T>
    {
        public T Value { get; set; }
        public Node(T value)
        {
            Value = value;
        }
        public Node<T>? Next { get; set; } = null;
    }

    public class MyStack<T> : IEnumerable<T>
    {
        Node<T>? head;
        int count;

        public bool IsEmpty { get { return count == 0; } }

        public int Count { get { return count; } }

        public void Push(T item)
        {
            Node<T> node = new Node<T>(item);
            node.Next = head;
            head = node;
            count++;
        }
        public T? Pop()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("Stack is empty!");
            }
            Node<T>? temp = head;
            head = head.Next;
            count--;
            return temp.Value;
        }
        public T Peek()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("Stack is empty!");
            }
            return head.Value;
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            Node<T> current = head;
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }
    }
}