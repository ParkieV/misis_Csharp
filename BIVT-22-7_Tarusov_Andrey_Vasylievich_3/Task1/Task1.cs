using Structures;


namespace Task1
{

    public class Task1
    {
        static void Main(string[] args)
        {
            Structures.MyStack<int> stack = new MyStack<int>();
            stack.Push(1);
            stack.Push(2);
            Console.WriteLine(stack.Peek());
            Structures.MyQueue<int> queue = new MyQueue<int>();
            queue.Push(1);
            queue.Push(2);
            Console.WriteLine(queue.First);
        }
    }
}