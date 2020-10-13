using System;
using CsharpLibrary.Services;

namespace CsharpLibrary.Controllers
{
  class LibraryController
  {

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
      throw new NotImplementedException();
    }
    private void ReadBook()
    {
      throw new NotImplementedException();
    }
    private void CheckoutBook()
    {
      Console.WriteLine(new LibraryService().GetBooks(true));
    }

    private void ReturnBook()
    {
      Console.WriteLine(new LibraryService().GetBooks(false));
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