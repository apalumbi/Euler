using System.Collections.Generic;
using System.Numerics;
using Euler.Problems;

namespace Euler {
	public class PermutationGenerator<T> {

		List<Pair<int, T>> elements;
		BigInteger numLeft;
		BigInteger total;

		public PermutationGenerator(List<T> elements) {
			this.elements = new List<Pair<int, T>>();

			var i = 0;
			foreach (var element in elements) {
				this.elements.Add(new Pair<int, T>(i, element));
				i++;
			}
			total = GetFactorial(elements.Count);
			numLeft = total;
		}

		public BigInteger GetNumLeft() {
			return numLeft;
		}

		public BigInteger Total {
			get { return total; }
		}

		public bool HasMore {
			get { return numLeft.CompareTo(0) == 1; }
		}

		BigInteger GetFactorial(int n) {
			BigInteger fact = 1;
			for (BigInteger i = n; i > 1; i--) {
				fact = fact * i;
			}
			return fact;
		}

		public List<Pair<int, T>> GetNext() {

			if (numLeft == total) {
				numLeft = numLeft - 1;
				return elements;
			}

			Pair<int, T> temp;

			int j = elements.Count - 2;
			while (elements[j].First > elements[j + 1].First) {
				j--;
			}

			// Find index k such that a[k] is smallest integer
			// greater than a[j] to the right of a[j]

			int k = elements.Count - 1;
			while (elements[j].First > elements[k].First) {
				k--;
			}

			// Interchange a[j] and a[k]

			temp = elements[k];
			elements[k] = elements[j];
			elements[j] = temp;

			// Put tail end of permutation after jth position in increasing order

			int r = elements.Count - 1;
			int s = j + 1;

			while (r > s) {
				temp = elements[s];
				elements[s] = elements[r];
				elements[r] = temp;
				r--;
				s++;
			}

			numLeft = numLeft - 1;
			return elements;
		}

		public string GetSpecificPermutation(int permuationToGet) {
			var currentPermutatation = 0;
			while (currentPermutatation < permuationToGet - 1) {
				GetNext();
				currentPermutatation++;
			}
			var perm = GetNext();
			var result = "";
			foreach (var p in perm) {
				result += p.Second.ToString();
			}
			return result;
		}


		public HashSet<string> GetAllPermutations() {
			var results = new HashSet<string>();
			while (HasMore) {
				var perm = GetNext();
				var result = "";
				foreach (var p in perm) {
					result += p.Second.ToString();
				}
				results.Add(result);
			}
			return results;
		}
	}
}