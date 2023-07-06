using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Contracts
{
    public interface ITask
    {
        public enum TaskStatus
        {
            Ongoing,
            Suspended,
            Cancelled,
            Completed
        }

        public string Title { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime DueAt { get; set; }
		public TaskStatus Status { get; set; }
    }
}
