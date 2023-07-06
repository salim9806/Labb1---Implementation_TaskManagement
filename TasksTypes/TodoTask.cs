using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp.Contracts;

namespace ConsoleApp.TasksTypes
{
    public class TodoTask : ITask
    {
        public string Title { get; set; }
        public DateTime CreateAt { get; set; }
        public ITask.TaskStatus Status { get; set; }
		public DateTime DueAt { get; set; }

		public TodoTask()
        { }

        public TodoTask(string title, ITask.TaskStatus status = ITask.TaskStatus.Ongoing)
        {
            Title = title;
            CreateAt = DateTime.Now;
            DueAt = DateTime.Now.AddYears(50);
            Status = status;
        }

    }
}
