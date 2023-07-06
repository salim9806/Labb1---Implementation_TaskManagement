using ConsoleApp.Contracts;
using ConsoleApp.TaskFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
	public class TaskManagementSystem
	{
		private static TaskManagementSystem _instance;

		private List<TaskConstructor> _taskConstructors = new List<TaskConstructor>();
		private TaskSorter _sorter;

		public IEnumerable<TaskConstructor> TaskConstructors { get => _taskConstructors; }
		public TaskSorter TaskSorter { get => _sorter; }

		private TaskManagementSystem()
		{
			_sorter = new TaskSorter();

			foreach (var t in typeof(TaskManagementSystem).Assembly.GetTypes())
			{
				if (typeof(TaskConstructor).IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract)
				{
					var addedTaskConstructor = (TaskConstructor)Activator.CreateInstance(t);
					addedTaskConstructor.CreateTasks();
					_taskConstructors.Add(addedTaskConstructor);
				}
			}
		}

		public static TaskManagementSystem Instance
		{
			get
			{

				if (_instance == null)
				{
					_instance = new TaskManagementSystem();
				}
				return _instance;
			}
		}
	}
}
