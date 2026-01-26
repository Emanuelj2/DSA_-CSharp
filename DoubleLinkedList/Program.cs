

using System.ComponentModel;
using System.Linq.Expressions;
using System.Reflection.Metadata;

public class Node<T>
{
    public T? Data;
    public Node<T>? Next;
    public Node<T>? Prev;

    public Node(T data)
    {
        Data = data;
        Next = null;
        Prev = null;
    }
}

public class DoubleLinkedList<T>
{
    private Node<T>? Head;
    private Node<T>? Tail;
    
    public DoubleLinkedList()
    {
        Head = null;
        Tail = null;
    }

    //adda a node
    public void AddNode(T data)
    {
        //make a node with the data
        Node<T> newNode = new Node<T>(data);

        if(Head == null)
        {
            Head = Tail = newNode;
            return;
        }
        Tail.Next = newNode;
        newNode.Prev = Tail;
        Tail = newNode;
    }

    public void Delete(T data)
    {
        Node<T> curr = Head;

        if(curr == null)
        {
            return;
        }

        if(curr != null && !curr.Data.Equals(data));
        {
            curr = curr.Next;
        }

        
    }

    public void IsertAfter(int position, T data)
    {
        
    }

    //print the list
    public void PrintList()
    {
        Node<T> curr = Head;
        Console.Write("Normal print: ");
        while(curr != null)
        {
            Console.Write(curr.Data + " <-> ");
            curr = curr.Next;
        }
        Console.WriteLine("null");
    }

    public void PrintReverse()
    {
        Node<T> curr = Tail;
        Console.Write("Reverse print: ");
        while(curr != null)
        {
            Console.Write(curr.Data + " <-> ");
            curr = curr.Prev;
        }
        Console.WriteLine("null");
    }

    
}

public class Program
{
    public static void Main(string[] args)
    {
        DoubleLinkedList<int> dll = new();
        dll.AddNode(10);
        dll.AddNode(5);
        dll.AddNode(20);
        dll.PrintList();
        dll.PrintReverse();
    }
}