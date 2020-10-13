using System;
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
      _Service.AddBook();
    }
    private void ReadBook()
    {
      throw new NotImplementedException();
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
      throw new NotImplementedException();
    }


    public LibraryController()
    {
      _running = true;
      this.input = input;
    }
  }
}