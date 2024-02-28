
using DataAccess.Entities;
using DataAccess.Repositories;
using LibraryConsoleApp.Handlers;
using Microsoft.EntityFrameworkCore;

namespace LibraryConsoleApp
{
    internal class Program
    {
        private static AuthorRepository authorRepository;
        static async Task Main(string[] args)
        {
            ApplicationUI app = new ApplicationUI();
            await app.RunAsync();

            //var authors = await GetAuthors();
            //foreach (var author in authors)
            //{
            //    await Console.Out.WriteLineAsync(author.Name + " " + author.Surname + " " + author.Books.Count);
            //    foreach (var book in author.Books)
            //    {
            //        await Console.Out.WriteLineAsync("--" + book.Title + " " + book.Genre);
            //    }
            //}
            //await CreateAuthor();
            //switch 1 rodyti GetAuthors(), 2 kurti createAuthor().....
        }
        private static async Task CreateAuthor()
        {
            await Console.Out.WriteLineAsync("Iveskite autoriaus varda");
            var author = new Author()
            {
                Name = "EFAutorName",
                Surname = "EFAutorSurname"
            };
            await authorRepository.CreateAsync(author);
        }
        private static async Task<List<Author>> GetAuthors()
        {
            return await authorRepository.ReadAllAsync();
        }
    }
}
