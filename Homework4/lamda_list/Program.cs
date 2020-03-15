using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lamda_list
{
    public class Node<T>
    {
        public Node<T> Next { get; set; }
        public T Data { get; set; }

        public Node(T t)
        {
            Next = null;
            Data = t;
        }
    }

    public class GenericList<T>
    {
        private Node<T> head;
        private Node<T> tail;
        public GenericList()
        {
            tail = head = null;
        }
        public Node<T> Head
        {
            get => head;
        }
        public void Add(T t)
        {
            Node<T> n = new Node<T>(t);
            if(tail==null)
            {
                head = tail = n;
            }
            else
            {
                tail.Next = n;
                tail = n;
            }
        }
        public void Foreach(Action<T> act)
        {
            Node<T> temp;
            temp = head;
            if (temp == null)
                return;
            act(temp.Data);
                while(temp!=tail)
            {
                temp = temp.Next;
                act(temp.Data);
            }
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            int sum = 0;
            GenericList<int> intlist = new GenericList<int>();
            for(int x=0;x<10;x++)
            {
                intlist.Add(x);
            }

            Action<int> printout = delegate (int item)
             {
                 Console.WriteLine(item);
             };
            intlist.Foreach(printout);
            intlist.Foreach(x => sum += x);
            Console.WriteLine(sum);
        }
    }
}
