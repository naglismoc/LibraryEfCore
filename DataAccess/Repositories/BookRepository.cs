



using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class BookRepository
    {
        private readonly LibraryDbContext _context;

        public BookRepository(LibraryDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Book book)
        {
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
        }
        public async Task<Book> ReadAsync(int id)
        {
            return await _context.Books.Include(b => b.Author).FirstOrDefaultAsync(a => a.Id == id);
        }
        public async Task<List<Book>> ReadAllAsync()
        {
            return await _context.Books.Include(b => b.Author).ToListAsync();
        }
        public async Task UpdateAsync(Book book)
        {
            var eBook = await _context.Books.FindAsync(book.Id);
            if (eBook == null)
            {
                throw new KeyNotFoundException($"Book with Id {book.Id} not found.");
            }
            _context.Books.Entry(eBook).CurrentValues.SetValues(book);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null)
            {
                throw new KeyNotFoundException($"Book with Id {id} not found.");
            }
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
        }

    }
}
