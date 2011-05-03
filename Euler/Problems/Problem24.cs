using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Euler.Problems {
	public class Problem24 : Problem {

		List<string> results = new List<string>();
		public override string Solve() {
			var numbers = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
			permute(numbers, 0, numbers.Count);
			results.Sort();
			return results[999999];
		}

		void permute(List<int> numbers, int start, int n) {
			if (start == n - 1) {
				print(numbers, n);
			}
			else {
				for (int i = start; i < n; i++) {
					int temp = numbers[i];

					numbers[i] = numbers[start];
					numbers[start] = temp;
					permute(numbers, start + 1, n);
					numbers[start] = numbers[i];
					numbers[i] = temp;
				}
			}
		}

		void print(List<int> numbers, int size) {
			var stringer = new StringBuilder();
			for (int i = 0; i < size; i++) {
				stringer.Append(numbers[i]);
			}
			results.Add(stringer.ToString());
		}

		//private static void Problem24b() {
		//  var numbers = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
		//  permute2(numbers, 0, numbers.Count);
		//  results.Sort();
		//  Console.WriteLine(results[999999]);
		//}

		//static void permute2(List<int> numbers, int start, int n) {
		//  print(numbers, n);
		//  if (start < n) {
		//    int i = 0;
		//    int j = 0;
		//    for (i = n - 2; i >= start; i--) {
		//      for (j = i + 1; j < n; j++) {
		//        swap(numbers, i, j);
		//        permute(numbers, i + 1, n);
		//      }
		//      rotateLeft(numbers, i, n);
		//    }
		//  }
		//}

		//static void rotateLeft(List<int> numbers, int start, int n) {
		//  int temp = numbers[start];
		//  for (int i = start; i < n - 1; i++) {
		//    numbers[i] = numbers[i + 1];
		//  }
		//  numbers[n - 1] = temp;
		//}

		//static void swap(List<int> numbers, int i, int j) {
		//  int temp;
		//  temp = numbers[i];
		//  numbers[i] = numbers[j];
		//  numbers[j] = temp;
		//}
	}
}
