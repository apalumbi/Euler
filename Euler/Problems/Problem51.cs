using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Euler.Problems {
	public class Problem51 : Problem {

		public override string Solve() {
			var primeLookup = Helper.BuildPrimes(10000000);
			var lastPrime = primeLookup.Last();
			var expectedPrimeFamilyCount = 8;

			var replacement = "";
			bool haveEnoughPrimes = true;
			while (haveEnoughPrimes && replacement.Length < 4) {
				replacement += "*";
				var alreadyChecked = new HashSet<string>();
				for (int i = 0; i < 999; i++) {
					var sorted = i.ToStringList().OrderBy(c => c);
					var sortedNumber = string.Join("", sorted);
					if (!alreadyChecked.Contains(sortedNumber)) {
						alreadyChecked.Add(sortedNumber);
						var number = replacement + sortedNumber;
						var perms = new PermutationGenerator<string>(number.ToStringList()).GetAllPermutations().Distinct();

						foreach (var perm in perms) {
							var family = new List<int>();
							for (int j = 0; j < 10; j++) {
								var numberString = perm.Replace("*", j.ToString());
								if (!numberString.StartsWith("0")) {
									family.Add(int.Parse(numberString));
								}
							}
							if (family.Count > 0 && family.Max() > lastPrime) {
								haveEnoughPrimes = false;
							}
							var primeCount = family.Count(p => primeLookup.Contains(p));
							if (primeCount == expectedPrimeFamilyCount) {
								return family.Min().ToString();
							}
						}
					}
				}
			}

			return "garf";
		}
	}
}
