using System;
using System.Collections.Generic;

namespace CS_CON_LibraryMS

{
    class Book
    {
        public int bookId;
        public string bookName;
        public int bookPrice;
        public int bookCount;
        public int x;
    }

    class BorrowDetails
    {
        public int userId;
        public string userName;
        public string userAddress;
        public int borrowBookId;
        public DateTime borrowDate;
        public int borrowCount;
    }
    class Program
    {
        static List<Book> bookList = new List<Book>();
        static List<BorrowDetails> borrowList = new List<BorrowDetails>();
        static Book book = new Book();
        static BorrowDetails borrow = new BorrowDetails();
        static void Main(string[] args)
        {
            bool logLoop = true;
            while (logLoop == true)
            {
                Console.WriteLine("||-----------------------------------------------------------------||");
                Console.WriteLine("||---------------WELCOME TO LEGENDARY LIBRARY SYSTEM---------------||");
                Console.WriteLine("||-----------------------------------------------------------------||");
                Console.WriteLine("\n-----Menu-----\n" +
                    "                        \n" +
                    "How do you Want to Login\n" +
                    "1)As an Admin\n" +
                    "2)As an User\n"
                   );
                Console.Write("Choose your option from menu :");

                int logCase = int.Parse(Console.ReadLine());
                switch (logCase)
                {
                    case 1:
                        Admin lib = new Admin();
                        lib.libLogin();
                        break;
                    case 2:
                        User br = new User();
                        br.brLogin();
                        break;
                    case 3:
                        logLoop = false;
                        break;
                    default:
                        Console.WriteLine("Invalid selection");
                        break;
                }
            }
        }
    }

}