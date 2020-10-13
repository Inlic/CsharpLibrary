using System;

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
          CheckoutBook();
          break;
        case "return":
          ReturnBook();
          break;
        case "delete":
          DeleteBook();
          break;
        case "quit":
          _running = false;
          Console.WriteLine("\nGoodbye");
          break;
        default:
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
      throw new NotImplementedException();
    }

    private void ReturnBook()
    {
      throw new NotImplementedException();
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