using TaskSystemApi.Models;
using Serilog;

namespace TaskSystemApi.Services.Exception
{
    public class NullException : IOException
    {
        public NullException(string message) : base(message)
        {
            Log.Error(message);
        }

        //TODO CHECK IF THE LOG IT NOT GOING TO BE DUPLICATE
        public static void ThrowIfUserNull(UserModel user, int id)
        {
            if (user == null)
            {
                string errorMessage = $"The UserId: {id} doesn't exist!";
                Log.Error(errorMessage);
                throw new NullException(errorMessage);
            }
        }

        public static void ThrowIfTaskNull(TaskModel task, int id)
        {
            if (task == null)
            {
                string errorMessage = $"The UserId: {id} doesn't exist!";
                Log.Error(errorMessage);
                throw new NullException(errorMessage);
            }
        }

    }
}
