using System;
using System.Collections.Generic;
using Euler.Problems;

namespace Euler {
	class Program {
		[STAThread]
		static void Main(string[] args) {
			
			var problems = new List<Problem> {
				new Problem32(),
				new Problem38(),
				new Problem43(),
				new Problem47(),
			};
						
			foreach (var problem in problems) {
				Helper.Write("Starting: " + problem.Name);
				var start = DateTime.Now;
				var answer = problem.Solve();
				Helper.Write(problem.Name + " calculated the following: " + answer);
				Helper.Copy(answer);
				if (!String.IsNullOrEmpty(problem.Solution)) {
					Helper.Write("The proper solution is: " + problem.Solution);

					if (answer != problem.Solution) {
						Helper.Write("!!!!!!!!!!!!!!!!!!!!!!!Answer is now incorrect!!!!!!!!!!!!!!!!!!!!!!!!!!!");
					}
				}
				Helper.Write("It took " + (DateTime.Now - start) + " to calculate the answer");
			}
			
			Console.ReadLine();
		}
	}
}
