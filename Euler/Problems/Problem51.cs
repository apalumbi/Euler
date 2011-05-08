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
				for (int index = 1; index < number.ToString().Length; index++) {
					var modified = new List<string>();
					CreateModifications(number, index, modified);
					var primeCount = modified.Count(p => primeLookup.Contains(int.Parse(p)));
					if (primeCount == countTarget) {
						return modified.Min();
					}
				}
			}

			return "";
		}

		private void CreateModifications(int number, int index, List<string> modified) {
			for (int replacement = 0; replacement < 10; replacement++) {
				var mod = Replace(number.ToString(), replacement.ToString(), index);
				if (!String.IsNullOrEmpty(mod)) {
					modified.Add(mod);
				}
			}
		}

		string Replace(string text, string p, int index) {
			if (index + 1 >= text.Length) {
				return "";
			}
			var foo = text.ToList().Select(c => c.ToString()).ToList();
			foo[index] = p;
			foo[index + 1] = p;
			return string.Join("", foo);
		}
	}
}
