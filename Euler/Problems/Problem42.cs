using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Euler.Problems {
	public class Problem42 : Problem {

		public override string Solve() {
			var triangles = new HashSet<double>();
			for (int i = 1; i <= 1000; i++) {
				triangles.Add(Formula(i));
			}

			var words = File.ReadAllText(@"Files\" + this.Name).Replace("\"", "").Split(',').ToList();

			var triangleWordsCount = 0;

			foreach (var word in words) {
				var wordCount = Helper.GetWordCount(word);
				if (triangles.Contains(wordCount)) {
					triangleWordsCount++;
				}
			}

			return triangleWordsCount.ToString();
		}

		double Formula(int number) {
			return .5 * number * (number + 1);
		}
	}
}