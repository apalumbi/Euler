using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Numerics;

namespace Euler.Problems {
	public class Problem22 : Problem {

		public override string Solve() {
			var nameString = File.ReadAllText(@"Files\" + this.Name);
			var names = nameString.Replace('"', ' ').Split(',').ToList();
			names = names.OrderBy(a => a).ToList();

			BigInteger total = 0;
			int counter = 1;
			foreach (var name in names) {
				var points = Helper.GetWordCount(name);
				total += (points * counter);
				counter++;
			}

			return total.ToString();
		}

		public override string Solution {
			get { return "871198282"; }
		}
	}
}	