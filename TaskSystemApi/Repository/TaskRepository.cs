using Microsoft.EntityFrameworkCore;
using TaskSystemApi.Data;
using TaskSystemApi.Models;
using TaskSystemApi.Repository.Interface;
using TaskSystemApi.Services.Exception;

namespace TaskSystemApi.Repository
{
    public class TaskRepository : ITaskRepository
    {
        private readonly TasksSystemDBContext _dBContext;
        public TaskRepository(TasksSystemDBContext tasksSystemDBContext)
        {
            _dBContext = tasksSystemDBContext;
        }
        public async Task<List<TaskModel>> GetAll()
        {
            return await _dBContext.Tasks.ToListAsync();
        }

        public async Task<TaskModel> GetById(int id)
        {
            return await _dBContext.Tasks.FirstOrDefaultAsync(x => x.Id == id) ?? new TaskModel();
        }

        public async Task<TaskModel> AddTask(TaskModel task)
        {
            await _dBContext.Tasks.AddAsync(task);
            await _dBContext.SaveChangesAsync();
            return task;
        }

        public async Task<TaskModel> UpdateTask(TaskModel task, int id)
        {
            TaskModel taskById = await GetById(id);

            NullException.ThrowIfTaskNull(taskById, id);

            taskById.Name = task.Name;
            taskById.UserId = task.UserId;
            taskById.User = task.User;

            _dBContext.Update(taskById);
            await _dBContext.SaveChangesAsync();

            return taskById;
        }
        public async Task<bool> DeleteTask(int id)
        {
            TaskModel taskById = await GetById(id);

            NullException.ThrowIfTaskNull(taskById, id);

            _dBContext.Remove(taskById);
            await _dBContext.SaveChangesAsync();

            return true;
        }
    }
}
