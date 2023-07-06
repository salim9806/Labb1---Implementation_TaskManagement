using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp.Contracts;
using ConsoleApp.TasksTypes;

namespace ConsoleApp.TaskFactory
{
    public class TodoTaskConstructor : TaskConstructor
    {
        public override void CreateTasks()
        {
            _tasks.AddRange(new ITask[]
            {
                new TodoTask("Take out dogs"),
                new TodoTask("Workout biceps", ITask.TaskStatus.Suspended),
                new TodoTask("Work on project", ITask.TaskStatus.Cancelled),
                new TodoTask("Fix a bug", ITask.TaskStatus.Completed),
                new TodoTask("Find new job", ITask.TaskStatus.Completed),
                new TodoTask("Take a walk")
			}
			);
        }
    }
}
