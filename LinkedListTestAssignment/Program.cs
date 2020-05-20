using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListTestAssignment
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList<string> linkedList = new LinkedList<string>();
            // добавление элементов
            linkedList.Add("Tom");
            linkedList.Add("Alice");
            linkedList.Add("Bob");
            linkedList.Add("Sam");
            linkedList.Add("Tom");

            linkedList.Add("Lama", 4);
            string name = linkedList.Get(3);
            //Console.WriteLine(name);
            linkedList.Remove(1);

            var Query = from item in linkedList where item == "Tom" select item;

            //выводим элементы
            foreach (var item in Query)
            {
                Console.WriteLine(item);
            }

            int count = linkedList.Count;

            //Console.WriteLine(count);


        }
    }

    public class Node<T>
    {
        public Node(T data)
        {
            Data = data;
        }
        public T Data { get; set; }
        public Node<T> Next { get; set; }
        public int Index { get; set; }
    }

    public class LinkedList<T> : IEnumerable<T>
    {
        Node<T> head; // головной элемент
        Node<T> tail; // последний элемент
        int count;  // количество элементов в списке

        // добавление элемента
        public void Add(T data)
        {
            Node<T> node = new Node<T>(data);

            if (head == null)
                head = node;
            else
                tail.Next = node;
            tail = node;

            count++;
        }

        //добавление элемента по индексу
        public void Add(T data, int index)
        {
            if (index < 0 || index > count)
                throw new Exception("Введен невалидный индекс");

            int counter = 0;
            Node<T> node = new Node<T>(data);

            if (index != 0)
            {
                Node<T> current = head;
                Node<T> previous = null;
                while (current != null && counter != index)
                {
                    counter++;
                    previous = current;
                    current = current.Next;
                }

                node.Next = current;
                previous.Next = node;
            }
            else
            {
                node.Next = head;
                head = node;
            }

            count++;
        }

        //удаление элемента по индексу
        public void Remove(int index)
        {
            if (index < 0 || index >= count)
                throw new Exception("Введен невалидный индекс");

            int counter = 0;
            Node<T> current = head;
            Node<T> previous = null;

            if (index != 0)
            {
                while (current != null && counter != index)
                {
                    counter++;
                    count--;

                    previous = current;
                    current = current.Next;
                }

                previous.Next = current.Next;
            }
            else
            {
                head = current.Next;
            }

        }

        //получение элемента по индексу
        public T Get(int index)
        {
            if (index < 0 || index >= count)
                throw new Exception("Введен невалидный индекс");

            int counter = 0;
            Node<T> current = head;

            while (current != null && counter != index)
            {
                counter++;
                current = current.Next;
            }
            return current.Data;
        }


        //размер контейнера
        public int Count { get { return count; } }

        //реализация интерфейса IEnumerable
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            Node<T> current = head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }
    }
}
