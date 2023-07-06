using ConsoleApp.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
	public class TaskSorter
	{
		private IPrioritizationStrategy _sorter;

		public void SetStrategy(IPrioritizationStrategy sorter)
		{
			_sorter = sorter;
		}

		public IEnumerable<ITask> Proritize(IEnumerable<ITask> tasks)
		{
			return _sorter.Proritize(tasks);
		}
	}
}
