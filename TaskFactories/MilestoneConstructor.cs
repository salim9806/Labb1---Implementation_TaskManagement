using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp.Contracts;
using ConsoleApp.TasksTypes;

namespace ConsoleApp.TaskFactory
{
    public class MilestoneConstructor : TaskConstructor
    {
        public override void CreateTasks()
        {
            _tasks.AddRange(new ITask[]
            {
                new MilestoneTask("Web landing page", dueAt: new DateTime(2023, 9, 18)),
                new MilestoneTask("Buid a house", dueAt: new DateTime(2023, 12, 1)),
                new MilestoneTask("Design database", dueAt: new DateTime(2024, 4, 10)),
                new MilestoneTask("Recruit new memeber", dueAt: new DateTime(2024, 7, 29)),
                new MilestoneTask("Hack facebook", dueAt: new DateTime(2023, 10, 9))
			});

		}
	}
}
