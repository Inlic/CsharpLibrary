using System;
using CsharpLibrary.Controllers;

namespace CsharpLibrary
{
  class Program
  {
    static void Main(string[] args)
    {
      new LibraryController().Run();
    }
  }
}
