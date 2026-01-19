
//make a generic node class
public class Node<T> 
{
    public T Data;
    public Node<T> Next;

    public Node(T data )
    {
        Data = data;
        Next = null;
    }
}


//make a generic single linked list class
public class SingleLinkedList<T>
{
    private Node<T> head;
    private Node<T> tail;
    public SingleLinkedList()
    {
        head = null;
        tail = null;
    }

    public void Add(T data)
    {
        Node<T> newNode = new Node<T>(data);
        if (head == null)
        {
            head = newNode;
            tail = newNode;
        }
        else
        {
            tail.Next = newNode;
            tail = newNode;
        }
    }

    public void PrintList()
    {
        Node<T> curr = head;

        while(curr != null)
        {
            Console.Write(curr.Data + " -> ");
            curr = curr.Next;
        }
        Console.Write("null");
    }
}

//main program
public class Program
{
    public static void Main(string[] args)
    {
        SingleLinkedList<int> list = new SingleLinkedList<int>();
        list.Add(1);
        list.Add(2);
        list.Add(3);
        list.PrintList();

    }
}