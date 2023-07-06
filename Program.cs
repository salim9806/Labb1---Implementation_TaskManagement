/*
 * 
 * Jag har implementerat Singleton, Factory method och strategy pattern
 * 
 * ----- Singleton -----
 * TaskManagementSystem.cs (singleton class)
 * 
 * ----- Factory Method -----
 * 
 * TaskConstructor.cs (creator)
 * FutureTaskConstructor.cs (concrete creator)
 * MileStoneConstructor.cs (concrete creator)
 * TodoTaskConstructor.cs (concrete creator)
 * ITask.cs (product)
 * FutureTask.cs (concrete product)
 * MilestoneTask.cs (concrete product)
 * TodoTask.cs (concrete product)
 * 
 * ----- Strategy pattern -----
 * TaskSystemMangament.cs (context)
 * IPrioritizationStrategy.cs  (strategy)
 * AlmostDueStrategy.cs (concrete strategy)
 * CompletedPrioritizationStrategy.cs (concrete strategy)
 * OnGoingPrioritizationStrategy.cs (concrete strategy)
 * OverDueStrategy.cs (concrete strategy)
 * 
 */


using ConsoleApp.Contracts;
using ConsoleApp.Strategies;
using ConsoleApp.TaskFactory;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace ConsoleApp
{
	internal class Program
	{
		static TaskManagementSystem taskSystem;
		static void Main(string[] args)
		{
			taskSystem = TaskManagementSystem.Instance;
			string[] taskTypes = taskSystem.TaskConstructors.Select(t => t.GetType().Name).ToArray();
			string[] sortStrategies = Assembly.GetExecutingAssembly().GetTypes().Where(t => !t.IsInterface && typeof(IPrioritizationStrategy).IsAssignableFrom(t)).Select(t => t.Name).ToArray();

			var taskConstructor = DisplayTaskTypesSelection(taskTypes);
			IPrioritizationStrategy sortStrategy = DisplaySortBySelection(sortStrategies);

			taskSystem.TaskSorter.SetStrategy(sortStrategy);

			ITask[] sortedTasks = taskSystem.TaskSorter.Proritize(taskConstructor.Tasks).ToArray();

			DisplayTasks(sortedTasks);
		}

		static TaskConstructor DisplayTaskTypesSelection(string[] typeNames)
		{
			DisplaySelection(typeNames.Select(t => t.Replace("Constructor", string.Empty)).ToArray());
			string taskType = typeNames[ValidateInput(typeNames.Length)];
			Console.Clear();
			return taskSystem.TaskConstructors.Single(t => t.GetType().Name == taskType);
		}

		static IPrioritizationStrategy DisplaySortBySelection(string[] strategyNames)
		{
			DisplaySelection(strategyNames);
			string strategyType = strategyNames[ValidateInput(strategyNames.Length)];
			Console.Clear();
			return ActivateInstance<IPrioritizationStrategy>(strategyType);
		}

		static void DisplayTasks(ITask[] tasks)
		{
			if(!tasks.Any())
			{
				Console.WriteLine("Empty! No Tasks found.");
			}

			for(int i = 0; i < tasks.Count(); i++)
			{
				Console.WriteLine($"(#{i})\nTitle\"{tasks[i].Title}\"\nStatus:{tasks[i].Status.ToString()}\n\n");
			}
		}

		static void DisplaySelection(string[] options)
		{
			for(int i = 0; i < options.Length; i++)
			{
				Console.WriteLine($"[{i}] - {options[i]}");
			}
		}

		static T ActivateInstance<T>(string instanceName)
		{
			//return (T)Activator.CreateInstance(typeof(Program).Assembly.FullName, instanceName).Unwrap();
			var assembly = Assembly.GetExecutingAssembly();

			var type = assembly.GetTypes()
				.First(t => t.Name == instanceName);

			return (T)Activator.CreateInstance(type);
		}

		static int ValidateInput(int numberOfOptions)
		{
			while (true)
			{
				Console.Write("Pick an option: ");
				string s;
				if ((s = Console.ReadLine()) != null && int.TryParse(s, out int i) && i >= 0 && i < numberOfOptions)
				{
					return i;
				}
				Console.WriteLine("Incorrect choice of option, try again!");
			}
		}
	}

	
}