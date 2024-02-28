using DataAccess.Entities;
using DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryConsoleApp.Handlers;

public class AuthorsHandler
{
    private readonly AuthorRepository _authorRepository;
    public AuthorsHandler(AuthorRepository authorRepository)
    {
        _authorRepository = authorRepository;

    }
    public async Task HandleAsync()
    {
        bool shouldStay = true;
        while (shouldStay)
        {
            printOptions();
            string option = Console.ReadLine();
            switch (option)
            {
                case "1":
                    await PrintAsync();
                    break;
                case "2":
                    await Console.Out.WriteLineAsync("show author with books");
                    break;
                case "3":
                    await Console.Out.WriteLineAsync("create author");
                    break;
                case "4":
                    await Console.Out.WriteLineAsync("edit author");
                    break;
                case "5":
                    await Console.Out.WriteLineAsync("delete author");
                    break;
                case "6":
                    Environment.Exit(1);
                    break;
            }
            shouldStay = shouldStayInAuthorsMenu();
        }

    }
    public bool shouldStayInAuthorsMenu()
    {
        string continueKey = "y";
        while (true)
        {
            Console.Out.WriteLine("Do you want to continue work in authors menu?(y/n)");
            continueKey = Console.ReadLine().ToLower();
            if (continueKey.Equals("y"))
            {
                return true;
            }

            if (continueKey.Equals("n"))
            {
                return false;
            }
        }
    }
    private async Task PrintAsync()
    {
        List<Author> authors = await _authorRepository.ReadAllAsync();

        Console.WriteLine("Authors:");
        Console.WriteLine($"{"Id",-5} {"Vardas",-20} {"Pavardė",-20}");

        foreach (var author in authors)
        {
            Console.WriteLine($"{author.Id,-5} {author.Name,-20} {author.Surname,-20}");
        }
    }
    public void printOptions()
    {
        Console.WriteLine("1. authors list");
        Console.WriteLine("2. show author");
        Console.WriteLine("3. create author");
        Console.WriteLine("4. edit author");
        Console.WriteLine("5. delete author");
        Console.WriteLine("6. System exit");

    }
}
