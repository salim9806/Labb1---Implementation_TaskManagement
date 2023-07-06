using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp.Contracts;

namespace ConsoleApp.TasksTypes
{
    public class MilestoneTask : ITask
    {
        public static ushort MAXIMUM_DAYS_MAILESTONE = 5;

        public string Title { get; set; }
        public DateTime CreateAt { get; set; }

        private DateTime _dueAt;
        public DateTime DueAt
        {
            get
            {
                return _dueAt;
            }
            set
            {
                if (value >= CreateAt.AddDays(MAXIMUM_DAYS_MAILESTONE))
                    _dueAt = value;
                else
                    throw new Exception($"The minimum range of a milestone task is {MAXIMUM_DAYS_MAILESTONE} days");
            }
        }
        public ITask.TaskStatus Status { get; set; }

        public MilestoneTask()
        { }

        public MilestoneTask(string title,DateTime dueAt, ITask.TaskStatus status = ITask.TaskStatus.Ongoing)
        {
            Title = title;
            CreateAt = DateTime.Now;
            DueAt = dueAt;
            Status = status;
        }

    }
}
