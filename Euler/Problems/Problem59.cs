using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Euler.Problems {
	public class Problem59 : Problem {

		public override string Solve() {
			var bytes = File.ReadAllText(@"Files\" + Name).Split(',');
			var wordList = File.ReadAllText(@"Files\Problem42");

			return "";
		}
	}
}
