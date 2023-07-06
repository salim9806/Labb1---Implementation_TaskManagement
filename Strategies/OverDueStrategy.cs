using ConsoleApp.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Strategies
{
	public class OverDueStrategy : IPrioritizationStrategy
	{
		public IEnumerable<ITask> Proritize(IEnumerable<ITask> tasks)
		{
			return tasks.Where(t => DateTime.Now > t.DueAt);
		}
	}
}
