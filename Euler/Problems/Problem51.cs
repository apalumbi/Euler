using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Euler.Problems {
	public class Problem51 : Problem {

		public override string Solve() {
			var primeLookup = Helper.BuildPrimes(100000);

			var countTarget = 8;

			var numbers = new List<int>();
			for (int i = 0; i < 100000; i++) {
				numbers.Add(i);
			}

			foreach (var number in numbers) {
				for (int index = 0; index < number.ToString().Length; index++) {
					var modified = new List<string>();
					for (int replacement = 1; replacement < 10; replacement++) {
						modified.Add(Replace(number.ToString(), replacement.ToString(), index));
					}
					var primeCount = modified.Count(p => primeLookup.Contains(int.Parse(p)));
					if (primeCount == countTarget) {
						return modified.Min();
					}
				}
			}

			return "";
		}

		string Replace(string text, string p, int index) {
			var foo = text.ToList().Select(c => c.ToString()).ToList();
			foo[index] = p;
			return string.Join("", foo);
		}
	}
}
