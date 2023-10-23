using Logistics.Management.Data.Context;
using Logistics.Management.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Logistics.Management.Data.Repositories
{
    public class RequestRepository
    {
        private readonly ApplicationDbContext _context;

        public RequestRepository(ApplicationDbContext context) => _context = context;

        public async Task<List<Request>> GetAllAsync(CancellationToken cancellationToken) =>
          await _context.Requests.ToListAsync(cancellationToken);

        public async Task<Request> GetByIdAsync(Guid id) =>
            await _context.Requests.Include(r => r.RequestItems)
                                   .FirstOrDefaultAsync(r => r.Id == id);

        public async Task CreateAsync(Request request)
        {
            _context.Requests.Add(request);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Request request)
        {
            _context.Entry(request).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int requestId)
        {
            var request = await _context.Requests.FindAsync(requestId);
            if (request != null)
            {
                _context.Requests.Remove(request);
                await _context.SaveChangesAsync();
            }
        }
    }
}