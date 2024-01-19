using LibraryIO;
using LibraryIO.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //string path = @"c:\temptest\booksSalvatore.txt";
            string path = @"c:\temptest\books.txt";

            //List<Book> books = new List<Book>();
            //books = Processes.PopulateBooks();
            //Processes.WriteToFile(books, path);
            //**************************************************

            List<Book> bk = Processes.ReadFromFile(path);
            Console.WriteLine("Unsorted list");
            foreach (var book in bk)
            {
                Console.WriteLine(book);
            }
            Console.WriteLine();
            Console.WriteLine("List sorted by title");

            List<Book> sortedBooks = bk;
            sortedBooks.Sort();

            bk.Sort();
            foreach (Book book in bk)
            {
                Console.WriteLine(book);
            }

            //********************************************************
            //use lambda expression to sort by year
            Console.WriteLine("Used lambda to sort by year");
            Console.WriteLine();
            List<Book> books1 = bk.OrderBy(b => b.Year).ToList();
            foreach (Book book in books1)
            {
                Console.WriteLine(book);
            }

            Console.WriteLine("Add new book");

            Book newBook = new Book();
            newBook.Title = "Title New new";
            newBook.Author = "Rik";
            newBook.Year = 2023;
            Processes.WriteToFileOneBook(newBook, path);

          
            

        }

        
    }
}
