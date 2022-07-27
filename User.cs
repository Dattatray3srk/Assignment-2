﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CS_CON_LibraryMS
{
    internal class User
    {

        static List<Book> bookList = new List<Book>();
        static List<BorrowDetails> borrowList = new List<BorrowDetails>();
        static Book book = new Book();
        static BorrowDetails borrow = new BorrowDetails();

        public int bookId { get; internal set; }
        public int bookCount { get; internal set; }
        public int bookPrice { get; internal set; }
        public string bookName { get; internal set; }
        public int x { get; internal set; }

        public void brLogin()
        {
            Console.Write("Welcome !!!\nEnter your password :");
            string password = Console.ReadLine();

            if (password == "123456")
            {
                bool close = true;
                while (close)
                {
                    Console.WriteLine("\nMenu\n" +
                    "1)Add book\n" +
                    "2)Delete book\n" +
                    "3)Search book\n" +
                    "4)Borrow book\n" +
                    "5)Return book\n" +
                    "6)Close\n\n");
                    Console.Write("Choose your option from menu :");

                    int option = int.Parse(Console.ReadLine());

                    if (option == 1)
                    {
                        GetBook();
                    }
                    else if (option == 2)
                    {
                        RemoveBook();
                    }
                    else if (option == 3)
                    {
                        SearchBook();
                    }
                    else if (option == 4)
                    {
                        Borrow();
                    }
                    else if (option == 5)
                    {
                        ReturnBook();
                    }
                    else if (option == 6)
                    {
                        Console.WriteLine("Thank you for Coming, Visit Again..!!");
                        close = false;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid option\nPlease Retry !!!");
                    }
                }
            }
            else
            {
                Console.WriteLine("Invalid password");
            }
            Console.ReadLine();
        }

        public static void GetBook()
        {
            Book book = new Book();
            Console.WriteLine("Book Id:{0}", book.bookId = bookList.Count + 1);
            Console.Write("Book Name:");
            book.bookName = Console.ReadLine();
            Console.Write("Book Price:");
            book.bookPrice = int.Parse(Console.ReadLine());
            Console.Write("Number of Books:");
            book.x = book.bookCount = int.Parse(Console.ReadLine());
            bookList.Add(book);
        }

        //To delete book details from the Library database 
        public static void RemoveBook()
        {
            Book book = new Book();
            Console.Write("Enter Book id to be deleted : ");

            int Del = int.Parse(Console.ReadLine());

            if (bookList.Exists(x => x.bookId == Del))
            {
                bookList.RemoveAt(Del - 1);
                Console.WriteLine("Book id - {0} has been deleted", Del);
            }
            else
            {
                Console.WriteLine("Invalid Book id");
            }

            bookList.Add(book);
        }

        //To search book details from the Library database using Book id 
        public static void SearchBook()
        {
            Book book = new Book();
            Console.Write("Search by BOOK id :");
            int find = int.Parse(Console.ReadLine());

            if (bookList.Exists(x => x.bookId == find))
            {
                foreach (Book searchId in bookList)
                {
                    if (searchId.bookId == find)
                    {
                        Console.WriteLine("Book id :{0}\n" +
                        "Book name :{1}\n" +
                        "Book price :{2}\n" +
                        "Book Count :{3}", searchId.bookId, searchId.bookName, searchId.bookPrice, searchId.bookCount);
                    }
                }
            }
            else
            {
                Console.WriteLine("Book id {0} not found", find);
            }
        }

        //To borrow book details from the Library
        public static void Borrow()
        {
            Book book = new Book();
            BorrowDetails borrow = new BorrowDetails();
            Console.WriteLine("User id : {0}", (borrow.userId = borrowList.Count + 1));
            Console.Write("Name :");

            borrow.userName = Console.ReadLine();

            Console.Write("Book id :");
            borrow.borrowBookId = int.Parse(Console.ReadLine());
            Console.Write("Number of Books : ");
            borrow.borrowCount = int.Parse(Console.ReadLine());
            Console.Write("Address :");
            borrow.userAddress = Console.ReadLine();
            borrow.borrowDate = DateTime.Now;
            Console.WriteLine("Date - {0} and Time - {1}", borrow.borrowDate.ToShortDateString(), borrow.borrowDate.ToShortTimeString());

            if (bookList.Exists(x => x.bookId == borrow.borrowBookId))
            {
                foreach (Book searchId in bookList)
                {
                    if (searchId.bookCount >= searchId.bookCount - borrow.borrowCount && searchId.bookCount - borrow.borrowCount >= 0)
                    {
                        if (searchId.bookId == borrow.borrowBookId)
                        {
                            searchId.bookCount = searchId.bookCount - borrow.borrowCount;
                            break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Only {0} books are found", searchId.bookCount);
                        break;
                    }
                }
            }
            else
            {
                Console.WriteLine("Book id {0} not found", borrow.borrowBookId);
            }
            borrowList.Add(borrow);
        }

        //To return borrowed book to the library 
        public static void ReturnBook()
        {
            Book book = new Book();
            Console.WriteLine("Enter following details :");

            Console.Write("Book id : ");
            int returnId = int.Parse(Console.ReadLine());

            Console.Write("Number of Books:");
            int returnCount = int.Parse(Console.ReadLine());

            if (bookList.Exists(y => y.bookId == returnId))
            {
                foreach (Book addReturnBookCount in bookList)
                {
                    if (addReturnBookCount.x >= returnCount + addReturnBookCount.bookCount)
                    {
                        if (addReturnBookCount.bookId == returnId)
                        {
                            addReturnBookCount.bookCount = addReturnBookCount.bookCount + returnCount;
                            break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Count exists the actual count");
                        break;
                    }
                }
            }
            else
            {
                Console.WriteLine("Book id {0} not found", returnId);
            }
        }
    }
}
