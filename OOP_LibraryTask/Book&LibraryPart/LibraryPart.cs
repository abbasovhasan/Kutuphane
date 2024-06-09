namespace OOP_LibraryTask.Book_LibraryPart;

public class Book
{
    public string Name { get; set; }

    public string Author { get; set; }
    public int PageCount { get; set; }
    public double Price { get; set; }
    public string Code { get; set; }

}
public class Library
{
    public Library()
    {
        this.Books = new List<Book>();
    }

    public List<Book> Books { get; set; }



    public void AddBook(Book book)
    {
        Books.Add(book);
    }

    public Book GetBook(string search)
    {

        return this.Books.FirstOrDefault(b => b.Name.Contains(search.ToLower()));
    }

    public List<Book> FindAllBooks()
    {

        return this.Books.ToList();

    }

    public void RemoveAllBooks()
    {

        foreach (Book book in this.FindAllBooks())
        {
            this.Books.Remove(book);
        }


    }

}


