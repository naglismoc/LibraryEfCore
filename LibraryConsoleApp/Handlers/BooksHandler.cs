using DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryConsoleApp.Handlers;

public class BooksHandler
{
    private readonly BookRepository _bookRepository;
    public BooksHandler(BookRepository bookRepository)
    {
        _bookRepository = bookRepository;

    }
    public async Task HandleAsync()
    {
    }
}
