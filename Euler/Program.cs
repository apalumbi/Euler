using System;
using System.Collections.Generic;
using Euler.Problems;

namespace Euler {
	class Program {
		[STAThread]
		static void Main(string[] args) {
			
			var problems = new List<Problem> {
				new Problem24(),
			};
						
			foreach (var problem in problems) {
				Helper.Write("Starting: " + problem.Name);
				var start = DateTime.Now;
				var answer = problem.Solve();
				Helper.Write("The Answer For " + problem.Name + " is: " + answer);
				Helper.Copy(answer);
				Helper.Write("It took " + (DateTime.Now - start) + " to calculate the answer");
			}
			
			Console.ReadLine();
		}
	}
}
