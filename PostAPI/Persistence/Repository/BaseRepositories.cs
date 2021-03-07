using System;
using PostAPI.Persistence.Context;
namespace PostAPI.Persistence.Repository
{
    public abstract class BaseRepository
    {
        protected readonly AppDbContext _context;

        public BaseRepository(AppDbContext context)
        {
            _context = context;
        }
    }
}