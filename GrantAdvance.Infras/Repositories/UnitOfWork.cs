using GrantAdvance.Data.Context;
using GrantAdvance.Infras.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace GrantAdvance.Infras.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CompleteAsync()
        {
            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                await _context.SaveChangesAsync();
                transaction.Commit();
            }
        }
    }
}
