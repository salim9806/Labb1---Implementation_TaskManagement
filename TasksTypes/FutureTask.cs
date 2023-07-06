using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp.Contracts;

namespace ConsoleApp.TasksTypes
{
    public class FutureTask : ITask
    {
        public static uint MAXIMUM_FUTURE_MINUTES = 300;
        public string Title { get; set; }

        private DateTime _createAt;
        public DateTime CreateAt
        {
            get
            {
                return _createAt;
            }
            set
            {
                if (value < DateTime.Now.AddMinutes(MAXIMUM_FUTURE_MINUTES))
                    throw new Exception($"The future task can not be scheduled less than {MAXIMUM_FUTURE_MINUTES} minutes");
                _createAt = value;
            }
        }
		public DateTime DueAt { get; set; }
        public ITask.TaskStatus Status { get; set; }

		public FutureTask()
        { }

        public FutureTask(string title, DateTime createAt, ITask.TaskStatus status = ITask.TaskStatus.Ongoing)
        {
            Title = title;
            CreateAt = createAt;
            Status = status;
        }

    }
}
