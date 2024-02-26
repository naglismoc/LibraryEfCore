
using DataAccess.Entities;
using DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LibraryConsoleApp
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            var dbcf = new LibraryDbContextFactory();
            using var context = dbcf.CreateDbContext(args);
            var authorRepository = new AuthorRepository(context);



            //    var authors = GetAuthors(authorRepository);
            // CreateAuthor(authorRepository);
            //switch 1 rodyti GetAuthors(), 2 kurti createAuthor().....
        }
        //private static async Task CreateAuthor(AuthorRepository repository)
        //{
        //    await Console.Out.WriteLineAsync("Iveskite autoriaus varda");
        //    var author = new Author()
        //    {
        //        Name = "EFAutorName",
        //        Surname = "EFAutorSurname"
        //    };
        //    await repository.CreateAsync(author);
        //}
        //private static async Task<List<Author>> GetAuthors(AuthorRepository repository)
        //{
        //    return await repository.ReadAllAsync();
        //}
    }
}
