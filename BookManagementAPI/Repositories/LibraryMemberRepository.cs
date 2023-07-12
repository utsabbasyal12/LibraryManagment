using BookManagementAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BookManagementAPI.Repositories
{
    public class LibraryMemberRepository : ILibraryMemberRepository
    {
        private readonly ApplicationDbContext _context;

        public LibraryMemberRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<LibraryMembersModel>> GetMembers()
        {
            return await _context.Members.ToListAsync();
        }
        public async Task<LibraryMembersModel> GetMemberById(int MemberId)
        {
            return await _context.Members.FirstOrDefaultAsync(x => x.MemberId == MemberId);
        }
        public async Task<LibraryMembersModel> AddMembers(LibraryMembersModel model)
        {
            var result = await _context.Members.AddAsync(model);
            await _context.SaveChangesAsync();
            return result.Entity;
        }
        public async Task<LibraryMembersModel> UpdateMembers(LibraryMembersModel model)
        {
            var result = await _context.Members.FirstOrDefaultAsync(a => a.MemberId == model.MemberId);

            if(result != null)
            {
                result.Name = model.Name;
                result.ContactNo = model.ContactNo;
                result.Address = model.Address;

                await _context.SaveChangesAsync();

                return result;
            }
            return null;
        }
        public async Task DeleteMembers(int MemberId)
        {
            var result = await _context.Members.FirstOrDefaultAsync(a => a.MemberId == MemberId);
            if(result != null)
            {
                _context.Members.Remove(result);
                await _context.SaveChangesAsync();
            }
        }
    }
}
