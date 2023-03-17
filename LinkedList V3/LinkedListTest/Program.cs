using System;

namespace MyLinkedList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Creating the list.
            List<int> lista = new List<int>();
            lista.Add(0);
            lista.Add(1);
            lista.Add(2);
            lista.Add(3);
            lista.Add(4);
            lista.Add(5);
            lista.Add(6);
            lista.Add(7);
            lista.Add(8);

            lista.Remove(0);
            lista.Remove(1);
            lista.RemoveElement(4);
            lista.Remove(5);
            lista.RemoveElement(6);

            // Showing info.
            Console.WriteLine("List Nº1");
            Console.WriteLine("********");
            Console.WriteLine("First Element: "+lista.GetElement(0));
            Console.WriteLine("Last Element: " + lista.GetLastElement());
            Console.WriteLine("Size: " + lista.Size());
            Console.WriteLine("Elements: " + lista.ToString());

            List<string> lista2 = new List<string>();
            lista2.Add("Manolo");
            lista2.Add("Rosario");
            lista2.Add("María");
            lista2.Add("Chemari");
            lista2.RemoveElement("María");

            // Showing info.
            Console.WriteLine();
            Console.WriteLine("List Nº2");
            Console.WriteLine("********");
            Console.WriteLine("First Element: " + lista2.GetElement(0));
            Console.WriteLine("Last Element: " + lista2.GetLastElement());
            Console.WriteLine("Size: " + lista2.Size());
            Console.WriteLine("Elements: " + lista2.ToString());

            foreach (string s in lista2)
            {
                Console.WriteLine("IEnumerator working");
            }

        }
    }
}
