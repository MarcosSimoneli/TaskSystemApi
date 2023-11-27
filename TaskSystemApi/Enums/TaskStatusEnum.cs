using System.ComponentModel;

namespace TaskSystemApi.Enums
{
    public enum TaskStatusEnum
    {
        [Description("To do")]
        ToDo = 1,
        [Description("Working")]
        Working = 2,
        [Description("Done")]
        Done = 3
    }
}
