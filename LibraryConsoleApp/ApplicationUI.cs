using DataAccess.Repositories;
using LibraryConsoleApp.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryConsoleApp
{
    public class ApplicationUI
    {
        private readonly AuthorsHandler _authorsHandler;
        private readonly BooksHandler _booksHandler;
        public ApplicationUI()
        {
            LibraryDbContextFactory dbcf = new LibraryDbContextFactory();
            using var context = new LibraryDbContextFactory().CreateDbContext([]);

            AuthorRepository authorRepository = new AuthorRepository(context);
            BookRepository bookRepository = new BookRepository(context);

            _authorsHandler = new AuthorsHandler(authorRepository);
            _booksHandler = new BooksHandler(bookRepository);
        }


        public async Task RunAsync()
        {
            await Console.Out.WriteLineAsync("pagrindinis aplikacijos valdymo menu");
            while (true)
            {
                printOptions();
                string option = Console.ReadLine();
                switch (option)
                {
                    case "1":
                        await _authorsHandler.HandleAsync();
                        break;
                    case "2":
                        await _booksHandler.HandleAsync();
                        break;
                    case "3":
                        Environment.Exit(1);
                        break;
                }
            }

        }

        public void printOptions()
        {
            Console.WriteLine("1. authors menu");
            Console.WriteLine("2. books menu");
            Console.WriteLine("3. System exit");

        }
    }
}
