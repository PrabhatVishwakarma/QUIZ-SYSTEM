using System;
using Tool.Server.Model;

namespace Tool.Server.Repository
{
    public class UserRepository : IRepository<User>
    {
        AppDbContext _dbContext;

        public UserRepository(AppDbContext appDbContext)
        {
            _dbContext = appDbContext;
        }

        public async Task<User> CreateAsync(User _object)
        {
            var obj = await _dbContext.Users.AddAsync(_object);
            _dbContext.SaveChanges();
            return obj.Entity;
        }

        Task IRepository<User>.DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<List<User>> IRepository<User>.GetAllAsync()
        {
            throw new NotImplementedException();
        }

        Task<User> IRepository<User>.GetByIdAsync(int Id)
        {
            throw new NotImplementedException();
        }

        Task IRepository<User>.UpdateAsync(User _object)
        {
            throw new NotImplementedException();
        }
    }
}