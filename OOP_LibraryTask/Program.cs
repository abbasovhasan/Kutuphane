using OOP_LibraryTask.Book_LibraryPart;
using System.ComponentModel.Design.Serialization;
using System.Reflection.Emit;

namespace OOP_LibraryTask
{
    internal class Program
    {
        static void Main(string[] args)
        {


            Library library = new Library();

            int option;
            string enteredProperty;
            string result;
            start:
            Console.WriteLine("Xos gelmisiniz!");

            Console.WriteLine("1) Add book");
            Console.WriteLine("2) Get book");
            Console.WriteLine("3) Find all books");
            Console.WriteLine("4) Remove all books");

            Console.WriteLine("Istediyiniz funksiyanin sira nomresini qeyd edin: ");

            enteredProperty = Console.ReadLine();
            if (enteredProperty == null)
            {
                Console.Clear();
                Console.WriteLine("Bos saxlamag olmaz!");
                goto start;
            }
            if (!int.TryParse(enteredProperty, out option))
            {
                Console.Clear();
                Console.WriteLine("Reqem daxil etmelisiniz!");
                goto start;
            }
            if (option != 1 && option != 2 && option != 3 && option != 4)
            {
                Console.Clear() ;
                Console.WriteLine("Bele bir xidmet movcud deyil!");
                goto start;    
            }
            switch (option)
            {
                case 1: option = 1;
                       Book newBook = new Book();
                    Console.WriteLine("Kitabin adini daxil edin: ");
                    newBook.Name = Console.ReadLine();

                    Console.WriteLine("Muellifin adini qeyd edin: ");
                    newBook.Author = Console.ReadLine();
                    
                    Console.WriteLine("Kitabin qiymetini qeyd edin: ");
                    double price;
                    l2:
                    if (!double.TryParse(Console.ReadLine(), out price))
                    {
                        Console.WriteLine("Daxil edilen melumat duzgun deyil!");
                        goto l2 ;
                    }
                    newBook.Price = price;  

                    Console.Write("Kitabin sehife sayini mueyyen edin: ");
                    int pageCount;
                    l3:
                    if(!int.TryParse(Console.ReadLine(),out pageCount))
                    {
                        Console.Write("Daxil edilen meulumat dogru deyil! ");
                        goto l3 ;
                    }
                    newBook.PageCount = pageCount;

                    newBook.Code = Guid.NewGuid().ToString();

                     library.AddBook(newBook);
                    Console.WriteLine("Ana menyuya qayitmaq ucun klaviaturada power off tusundan ferqli her hansisa bir duymeye basin!");
                    Console.ReadKey();
                    Console.Clear (); goto start ;
                    ; 
                    case 2: option = 2;
                    l4:
                    Console.Write("Axtardiginiz kitabin adini qeyd edin: ");

                    var book = library.GetBook(Console.ReadLine());   
                    if(book is null)
                    {
                        Console.WriteLine ("Bele bir kitab tapilmadi! ");
                        Console.WriteLine("Ana menyuya qayitmaq ucun Y herfine basin, eger istemirsinizse diger herflerden birince clickleyin!");
                        var answer = Console.ReadKey();
                        Thread.Sleep(1000);
                        if (answer.KeyChar.ToString().ToLower() == "y")
                        {   
                            Console.Clear();
                            goto start ;
                        }
                        goto l4;
                    }
                    Console.WriteLine($"Name: {book.Name} || Author: {book.Author} || PageCount: {book.PageCount} ||Price: {book.Price}");

                    Console.WriteLine();

                    Console.WriteLine("Ana menyuya qayitmaq ucun klaviaturada power off tusundan ferqli her hansisa bir duymeye basin!");
                    Console.ReadKey();

                    Console.Clear(); goto start;
                    

                    case 3: option = 3;
                    List<Book> allBooks =  library.FindAllBooks();

                    foreach (var item in allBooks)
                    {
                        Console.WriteLine($"Name: {item.Name} || Author: {item.Author} || PageCount: {item.PageCount} ||Price: {item.Price}");
                    }
                    Console.WriteLine("Ana menyuya qayitmaq ucun klaviaturada power off tusundan ferqli her hansisa bir duymeye basin!");
                    Console.ReadKey();
                    Console.Clear(); goto start;

                        case 4: option = 4;
                    library.RemoveAllBooks();
                    Console.WriteLine("Melumatlarin hamisi silindi...");

                    Console.WriteLine("Ana menyuya qayitmaq ucun klaviaturada power off tusundan ferqli her hansisa bir duymeye basin!");
                    Console.ReadKey();
                    Console.Clear(); goto start;
                    
                   
            }

        }
    }
}
