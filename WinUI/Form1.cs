using System;
using System.IO;
using LibraryIO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibraryIO.Models;
using System.Configuration;

namespace WinUI
{
    public partial class Form1 : Form
    {
        //string path = @"c:\temptest\books.txt";
        string path = ConfigurationManager.AppSettings["file"];
        List<Book> temp = new List<Book>();
        public Form1()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            ShowList();
        }

        private void ShowList()
        {
            lstBooks.Items.Clear();
            List<Book> list;
            try
            {
                list = Processes.ReadFromFile(path);
                foreach (var item in list)
                {
                    lstBooks.Items.Add(item);
                }
            }
            catch (FileNotFoundException ex)
            {
                lblError.Visible = true;
                lblError.Text = ex.Message;

                //MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                lblError.Visible = true;
                lblError.Text = ex.Message;
                
                //MessageBox.Show(ex.Message);
            }
            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Book book = new Book();
            book.Title = txtTitle.Text;
            book.Author = txtAuthor.Text;
            book.Year = int.Parse(txtYear.Text);
            Processes.WriteToFileOneBook(book,path);
            ShowList();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            lstBooks.Items.RemoveAt(lstBooks.SelectedIndex);
            foreach ( var item in lstBooks.Items )
            {
                temp.Add((Book)item);
            }
            
            Processes.WriteToFile(temp,path,false);
           
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Book book = new Book();
            book.Title = txtTitle.Text;
            book.Author = txtAuthor.Text;
            book.Year = int.Parse(txtYear.Text);

            lstBooks.Items.RemoveAt(lstBooks.SelectedIndex);
            
            foreach (var item in lstBooks.Items)// without updated
            {
                temp.Add((Book)item); // list without updated, record already deleted
            }
            
            Processes.WriteToFile(temp, path, false);
            Processes.WriteToFileOneBook(book, path); // add to text file

            var list = Processes.ReadFromFile(path);
            foreach (var item in list)
            {
                lstBooks.Items.Add(item);
            }

        }

        private void lstBooks_SelectedIndexChanged(object sender, EventArgs e)
        {
            var book = (Book)lstBooks.SelectedItem;
            if (book != null)
            {
                txtAuthor.Text = book.Author;
                txtTitle.Text = book.Title;
                txtYear.Text = book.Year.ToString();
            }
        }
    }
}
