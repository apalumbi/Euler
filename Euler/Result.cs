using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Euler {
	public class Result {
		public string ProblemName;
		public string CalculatedAnswer;
		public string Solution;
		public TimeSpan RunningTime;

		public bool Correct { get { return CalculatedAnswer == Solution; } }

		public string Output { get { return "Calculated Answer: " + CalculatedAnswer + " - Running Time: " + RunningTime; } }
	}
}
