using LibraryIO.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryIO
{
    public class Processes
    {

        public static void WriteToFile(List<Book> books, string path)
        {
            using (StreamWriter sw = new StreamWriter(path,true))
            {
                for (int index = 0; index < books.Count; index++)
                {
                    sw.WriteLine(books[index].Title);
                    sw.WriteLine(books[index].Author);
                    sw.WriteLine(books[index].Year);
                    //sw.WriteLine(books[index]);
                }
            }

        }
        public static void WriteToFile(List<Book> books, string path, bool overwrite)
        {
            using (StreamWriter sw = new StreamWriter(path, overwrite))
            {
                for (int index = 0; index < books.Count; index++)
                {
                    sw.WriteLine(books[index].Title);
                    sw.WriteLine(books[index].Author);
                    sw.WriteLine(books[index].Year);
                    //sw.WriteLine(books[index]);
                }
            }

        }
        public static List<Book> ReadFromFile(string path)
        {
            using (StreamReader sr = new StreamReader(path))
            {

                List<Book> lines = new List<Book>();
                while (!sr.EndOfStream)
                {
                    Book b = new Book();
                    b.Title = sr.ReadLine();
                    b.Author = sr.ReadLine();
                    b.Year = Convert.ToInt32(sr.ReadLine());
                    lines.Add(b);
                }
                return lines;
            }
        }

        public static List<Book> PopulateBooks()
        {
            List<Book> books = new List<Book>();
            books.Add(new Book{Author="Rik", Title="title3", Year = 2010});
            books.Add(new Book{Author="Kenan", Title="title4", Year = 2000});
            books.Add(new Book{Author="Eveline", Title="title31", Year = 2003});
            books.Add(new Book{Author="Hasan", Title="title2", Year = 2008});
            books.Add(new Book{Author="Gabriela", Title="title5", Year = 2015});

            return books;
        }


        //***********************************************************

        //Add one book

        public static void WriteToFileOneBook(Book book, string path)
        {
            using (StreamWriter sw = new StreamWriter(path,true))
            {
                Book b = new Book();
                sw.WriteLine(b.Title = book.Title);
                sw.WriteLine(b.Author = book.Author);
                sw.WriteLine(b.Year = book.Year);
            }
        }

       

    }
}
