using System;
using System.Collections.Generic;
using System.Linq;
using Euler.Problems;
using System.Reflection;

namespace Euler {
	class Program {
		[STAThread]
		static void Main(string[] args) {
			//var problems = GetAllClasses("Euler.Problems");
			var problems = new List<Problem> { new Problem61() };
			var start = DateTime.Now;

			var results = new List<Result>();
			foreach (var problem in problems) {
				Helper.Write("Starting: " + problem.Name);
				var result = Print(problem, DateTime.Now);
				results.Add(result);
				Helper.Write(result.Output);
			}

			Helper.Write("");
			foreach (var result in results) {
				if (!result.Correct) {
					Helper.Write(result.ProblemName + " was incorrect. Calculated: " + result.CalculatedAnswer + " Solution: " + result.Solution);
				}
			}
			Helper.Write("");
			Helper.Write("10 slowest");
			foreach (var result in results.OrderByDescending(r => r.RunningTime).Take(10)) {
				Helper.Write(result.ProblemName + " ran for " + result.RunningTime.TotalSeconds);
			}

			Helper.Write("");
			var runningTime = (DateTime.Now - start);
			Helper.Write("Total time to run " + problems.Count + " problems: " + runningTime.TotalSeconds + " seconds");
			Helper.Write("Average problem running time: " + runningTime.TotalSeconds / problems.Count + " seconds");
			Console.ReadLine();
		}

		static List<Problem> GetAllClasses(string nameSpace) {
			var namespaceList = new List<string>();
			foreach (var type in Assembly.GetExecutingAssembly().GetTypes()) {
				if (type.Namespace == nameSpace)
					namespaceList.Add(type.Name);
			}

			var returnList = new List<Problem>();
			foreach (var className in namespaceList.OrderBy(n => n)) {
				var type = Type.GetType(nameSpace + "." + className);
				Problem instance = null;
				if (type != null) {
					try {
						instance = (Problem)Activator.CreateInstance(type);
					}
					catch { }
				}
				if (instance != null) {
					returnList.Add(instance);
				}
			}
			return returnList;
		}

		static Result Print(Problem problem, DateTime start) {
			var result = new Result {
				ProblemName = problem.Name,
				CalculatedAnswer = problem.Solve(),
				RunningTime = (DateTime.Now - start),
				Solution = problem.Solution,
			};
			Helper.Copy(result.CalculatedAnswer);
			return result;
		}
	}
}
