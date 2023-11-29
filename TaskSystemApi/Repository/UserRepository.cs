using Microsoft.EntityFrameworkCore;
using TaskSystemApi.Data;
using TaskSystemApi.Models;
using TaskSystemApi.Repository.Interface;
using TaskSystemApi.Services.Exception;

namespace TaskSystemApi.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly TasksSystemDBContext _dBContext;
        public UserRepository(TasksSystemDBContext tasksSystemDBContext)
        {
            _dBContext = tasksSystemDBContext;
        }
        public async Task<List<UserModel>> GetAll()
        {
            return await _dBContext.Users.ToListAsync();
        }

        public async Task<UserModel> GetById(int id)
        {
            return await _dBContext.Users.FirstOrDefaultAsync(x => x.Id == id) ?? new UserModel();
        }

        public async Task<UserModel> AddUser(UserModel user)
        {
            await _dBContext.Users.AddAsync(user);
            await _dBContext.SaveChangesAsync();
            return user;
        }

        public async Task<UserModel> UpdateUser(UserModel user, int id)
        {
            UserModel userById = await GetById(id);

            NullException.ThrowIfUserNull(user, id);

            userById.Name = user.Name;
            userById.Email = user.Email;

            _dBContext.Update(userById);
            await _dBContext.SaveChangesAsync();

            return userById;
        }
        public async Task<bool> DeleteUser(int id)
        {
            UserModel userById = await GetById(id);

            NullException.ThrowIfUserNull(userById, id);

            _dBContext.Remove(userById);
            await _dBContext.SaveChangesAsync();

            return true;
        }
    }
}
