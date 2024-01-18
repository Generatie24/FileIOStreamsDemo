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

            var bk = Processes.ReadFromFile(path);
            Console.WriteLine("Unsorted list");
            foreach (Book book in bk)
            {
                Console.WriteLine(book);
            }
            Console.WriteLine();
            Console.WriteLine("List sorted by title");

           // List<Book> sortedBooks = bk;
            //sortedBooks.Sort();

            bk.Sort();
            foreach (Book book in bk)
            {
                Console.WriteLine(book);
            }

            //********************************************************
            //use lambda expression to sort by year
            Console.WriteLine("Used lambda to sort by year");
            Console.WriteLine();
            List<Book> books = bk.OrderBy(dritan => dritan.Year).ToList();
            foreach (Book book in books)
            {
                Console.WriteLine(book);
            }

            Console.WriteLine("Add new book");

            Book newBook = new Book();
            newBook.Title = "Title New";
            newBook.Author = "Rik";
            newBook.Year = 2023;
            Processes.WriteToFileOneBook(newBook, path);

          
            

        }

        
    }
}
