using System;
using CsharpLibrary.Models;
using CsharpLibrary.Services;

namespace CsharpLibrary.Controllers
{
  class LibraryController
  {
    private LibraryService _Service { get; set; } = new LibraryService();
    private bool _running { get; set; }

    public string input { get; set; }

    public void Run()
    {
      while (_running)
      {
        GetUserInput();
      }
    }
    private void GetUserInput()
    {
      Console.WriteLine("Choose an option: Add, Read, Checkout, Return, Delete, or Quit");
      input = Console.ReadLine().ToLower();
      switch (input)
      {
        case "add":
          AddBook();
          break;
        case "read":
          ReadBook();
          break;
        case "checkout":
          Console.Clear();
          CheckoutBook();
          break;
        case "return":
          Console.Clear();
          ReturnBook();
          break;
        case "delete":
          Console.Clear();
          DeleteBook();
          break;
        case "quit":
          _running = false;
          Console.WriteLine("\nGoodbye");
          break;
        default:
          Console.Clear();
          Console.WriteLine("\nInvalid Input Try Again");
          break;
      }
    }

    private void AddBook()
    {
      Console.Clear();
      Console.WriteLine("\nTitle of the Book you wish to Add");
      string title = Console.ReadLine();
      Console.WriteLine("\nAuthor of the Book you wish to Add");
      string author = Console.ReadLine();
      Console.WriteLine("\nDescription for the Book you wish to Add");
      string description = Console.ReadLine();
      var newBook = new Book(title, author, description, true);
      _Service.AddBook(newBook);
      Console.Clear();
      Console.WriteLine($"\nBook {title} Added");
    }
    private void ReadBook()
    {
      Console.WriteLine(_Service.GetAllBooks());
      Console.WriteLine("\nWhich book would you like to read?");
      string selectionStr = Console.ReadLine();
      if (int.TryParse(selectionStr, out int selection) && selection > 0)
      {
        Console.WriteLine(_Service.ReadBook(selection - 1));
      }
      else
      {
        Console.WriteLine("Invalid Number: Selection must be a number greater than 0");
      }
    }
    private void CheckoutBook()
    {
      Console.WriteLine(_Service.GetBooks(true));
      Console.WriteLine("\nWhich book would you like to checkout?");
      string selectionStr = Console.ReadLine();
      if (int.TryParse(selectionStr, out int selection) && selection > 0)
      {
        Console.WriteLine(_Service.Checkout(selection - 1));
      }
      else
      {
        Console.WriteLine("Invalid Number: Selection must be a number greater than 0");
      }
    }

    private void ReturnBook()
    {
      Console.WriteLine(_Service.GetBooks(false));
      Console.WriteLine("\nWhich book would you like to return?");
      string selectionStr = Console.ReadLine();
      if (int.TryParse(selectionStr, out int selection) && selection > 0)
      {
        Console.WriteLine(_Service.Return(selection - 1));
      }
      else
      {
        Console.WriteLine("Invalid Number: Selection must be a number greater than 0 and available");
      }
    }
    private void DeleteBook()
    {
      Console.WriteLine(_Service.GetBooks(true));
      Console.WriteLine("\nType the title of the book you would like to remove from the collection.");
      string selectionStr = Console.ReadLine();
      Console.WriteLine(_Service.DeleteBook(selectionStr));
    }


    public LibraryController()
    {
      _running = true;
      this.input = input;
    }
  }
}