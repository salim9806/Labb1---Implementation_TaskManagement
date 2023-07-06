using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp.Contracts;
using ConsoleApp.TasksTypes;

namespace ConsoleApp.TaskFactory
{
    public class FutureTaskConstructor : TaskConstructor
    {
        public override void CreateTasks()
        {

            _tasks.AddRange(new ITask[]
            {
                new FutureTask("Clean the window", new DateTime(2023, 7, 10), status: ITask.TaskStatus.Completed),
                new FutureTask("Deliver assigments", new DateTime(2023, 9, 5), status: ITask.TaskStatus.Cancelled),
                new FutureTask("Get a haircut", new DateTime(2023, 10, 22)),
                new FutureTask("Buy t-shirt", new DateTime(2023, 7, 22))
			});

		}
	}
}
