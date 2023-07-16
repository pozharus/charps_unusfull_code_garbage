// See https://aka.ms/new-console-template for more information

using System.Net.NetworkInformation;

namespace BinaryTree
{
    class Program
    {
        static void Main(string[] args)
        {
            var tree = new Tree<int>();
            tree.Add(5);
            tree.Add(3);
            tree.Add(7);
            tree.Add(1);
            tree.Add(2);
            tree.Add(8);
            tree.Add(6);
            tree.Add(9);
            tree.Add(4);

            Console.WriteLine("Prefix:");
            foreach (var item in tree.Preorder())
            {
                Console.Write(item + ", ");
            }
            
            Console.WriteLine("\nPostfix:");
            foreach (var item in tree.Postorder())
            {
                Console.Write(item + ", ");
            }
            
            Console.WriteLine("\nInfix:");
            foreach (var item in tree.Inorder())
            {
                Console.Write(item + ", ");
            }
        }
    }
}