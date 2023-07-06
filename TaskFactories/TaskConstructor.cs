using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp.Contracts;

namespace ConsoleApp.TaskFactory
{
    public abstract class TaskConstructor
    {
        protected List<ITask> _tasks = new List<ITask>();

        public IEnumerable<ITask> Tasks { get => _tasks; }

        public abstract void CreateTasks();
    }
}
