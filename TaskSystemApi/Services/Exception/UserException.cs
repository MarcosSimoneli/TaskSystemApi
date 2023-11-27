namespace TaskSystemApi.Services.Exception
{
    public class UserException : IOException
    {
        public UserException(int id) : base($"User by id:{id} was not found!")
        {
        }
    }
}
