using System;
using System.Collections.Generic;
using CsharpLibrary.Models;

namespace CsharpLibrary.Services
{
  class LibraryService
  {
    private List<Book> Books { get; set; }

    public string GetBooks(bool available)
    {
      string list = "\n ****************** \n";
      var books = Books.FindAll(b => b.IsAvailable == available);
      if (books.Count != 0)
      {
        for (int i = 0; i < books.Count; i++)
        {
          var book = books[i];
          if (book.IsAvailable == available)
          {
            list += $"{i + 1}. {book.Title} - by {book.Author}\n";
          }
        }
        return list;
      }
      else
      {
        return "\nNo Books in this Category.";
      }

    }


    internal string Checkout(int v)
    {
      var books = Books.FindAll(b => b.IsAvailable);
      if (v < books.Count)
      {
        books[v].IsAvailable = false;
        return "\nEnjoy your book.\n";
      }
      Console.Clear();
      return "\nInvalid Input, no such book.\n";
    }

    internal string Return(int v)
    {
      var books = Books.FindAll(b => !b.IsAvailable);
      if (v < books.Count)
      {
        books[v].IsAvailable = true;
        return "\nThank you for returning this book.\n";
      }
      return "\nInvalid Input, no such book.\n";
    }

    public LibraryService()
    {
      Books = new List<Book>();
      Books.Add(new Book("Bear", "Marian Engel", "The story of a 27-year-old, lonely, woman who, alone on an island, discovers an obssessive passion.", false));
      Books.Add(new Book("1Q84", "Haruki Murakami", "A young woman named Aomame follows a taxi driver's enigmatic suggestion and begins to notice puzzling discrepencies in the world around her.", true));
      Books.Add(new Book("Night Watch", "Terry Pratchett", "Commander Sam Vimes of the Ankh-Morpork City Watch had it all. But now he's back in his own rough, touch past without even the clothes he was in when the lightning struck.", true));
      Books.Add(new Book("Dune", "Frank Herbert", "Set on the desert planet Arrakis, Dune is the story of the boy Paul Atreides, who would become the mysterious man knwon as Maud'dib.  He would avenge the traitorous plot against his noble family - and would bring to fruition humankind's most ancient and unattainable dream.", true));
    }

  }
}