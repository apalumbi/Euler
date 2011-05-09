using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Numerics;

namespace Euler.Problems {
	public class Problem42 : Problem {

		public override string Solve() {
			var triangles = new HashSet<BigInteger>();
			for (int i = 1; i <= 1000; i++) {
				triangles.Add(Formulas.Triangle(i));
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

		public override string Solution {
			get { return "162"; }
		}
	}
}