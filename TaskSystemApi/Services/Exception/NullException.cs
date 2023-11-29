using TaskSystemApi.Models;

namespace TaskSystemApi.Services.Exception
{
    public class NullException : IOException
    {
        public NullException(string message) : base(message)
        {
        }

        public static void ThrowIfUserNull(UserModel user, int id)
        {
            if (user == null)
                throw new NullException($"The UserId: {id} doesn't exist!");
        }

        public static void ThrowIfTaskNull(TaskModel task, int id)
        {
            if (task == null)
                throw new NullException($"The TaskId: {id} doesn't exist!");
        }

    }
}
