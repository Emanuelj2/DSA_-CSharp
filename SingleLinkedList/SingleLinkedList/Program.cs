
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

    //add a node
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

    //add a node at the start
    public void AddAtAtart(T data)
    {
        Node<T> newNode = new Node<T>(data);
        if (head == null)
        {
            head = newNode;
            tail = newNode;
        }
        else
        {
            newNode.Next = head;
            head = newNode;
        }
    }

    public void Delete(T data)
    {
        if (head == null) return;

        if (head.Data.Equals(data))
        {
            head = head.Next;
            if (head == null) tail = null;
            return;
        }

        Node<T> curr = head;
        while (curr.Next != null && !curr.Next.Data.Equals(data))
        {
            curr = curr.Next;
        }
        if (curr.Next != null)
        {
            curr.Next = curr.Next.Next;
            if (curr.Next == null) tail = curr;
        }
    }

    public void SortList()
    {
        if (head == null || head.Next == null) return;

        bool swapped;
        do
        {
            swapped = false;
            Node<T> curr = head;
            while (curr.Next != null)
            {
                IComparable<T> currData = curr.Data as IComparable<T>;
                if (currData != null && currData.CompareTo(curr.Next.Data) > 0)
                {
                    T temp = curr.Data;
                    curr.Data = curr.Next.Data;
                    curr.Next.Data = temp;
                    swapped = true;
                }
                curr = curr.Next;
            }
        } while (swapped);
    }

    public void SortInGroupsOfK(int k)
    {
        if (head == null || k <= 1) return;

        Node<T> groupStart = head;

        while (groupStart != null)
        {
            
            Node<T> groupEnd = groupStart;
            int count = 1;
            while (groupEnd.Next != null && count < k)
            {
                groupEnd = groupEnd.Next;
                count++;
            }

            // Bubble sort 
            bool swapped;
            do
            {
                swapped = false;
                Node<T> curr = groupStart;

                // Sort only up to groupEnd
                while (curr != groupEnd)
                {
                    IComparable<T> currData = curr.Data as IComparable<T>;
                    if (currData != null && currData.CompareTo(curr.Next.Data) > 0)
                    {
                        // Swap
                        T temp = curr.Data;
                        curr.Data = curr.Next.Data;
                        curr.Next.Data = temp;
                        swapped = true;
                    }
                    curr = curr.Next;
                }
            } while (swapped);

            // Move to next group
            groupStart = groupEnd.Next;
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
        list.Add(45);
        list.Add(2);
        list.Add(3);
        list.AddAtAtart(0);
        list.PrintList();
        Console.WriteLine();
        list.Delete(2);
        list.Add(34);
        list.Add(23);
        list.PrintList();
        Console.WriteLine();
        list.SortInGroupsOfK(3);
        list.PrintList();
        Console.WriteLine();
        list.SortList();
        list.PrintList();

    }
}