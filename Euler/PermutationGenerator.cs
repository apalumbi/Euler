using System.Collections.Generic;
using System.Numerics;
using Euler.Problems;

namespace Euler {
	public class PermutationGenerator<T> {

		private List<Pair<int, T>> elements;
		private BigInteger numLeft;
		private BigInteger total;

		public PermutationGenerator(List<T> elements) {
			this.elements = new List<Pair<int, T>>();

			var i = 0;
			foreach (var element in elements) {
				this.elements.Add(new Pair<int, T>(i, element));
				i++;
			}
			total = getFactorial(elements.Count);
			numLeft = total;
		}

		public BigInteger getNumLeft() {
			return numLeft;
		}

		public BigInteger getTotal() {
			return total;
		}

		public bool hasMore() {
			return numLeft.CompareTo(0) == 1;
		}

		private static BigInteger getFactorial(int n) {
			BigInteger fact = 1;
			for (BigInteger i = n; i > 1; i--) {
				fact = fact * i;
			}
			return fact;
		}

		public List<Pair<int, T>> getNext() {

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
	}
}