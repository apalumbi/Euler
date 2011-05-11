﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Euler.Problems {
	public class Problem59 : Problem {

		public override string Solve() {
			var bytes = File.ReadAllText(@"Files\" + Name).Split(',');
			var wordList = File.ReadAllText(@"Files\Problem42");

			var elements = new List<string> {"a", "b", "c", "d", "e", "f", "e", "h",
																																		 "i", "j", "k", "l", "m", "n", "o", "p", "q",
																																		 "r", "s", "t", "u", "v", "w", "x", "y", "z"};

			var sized = new HashSet<string>();
			var combination = "";
			var generator = new PermutationGenerator2(elements.Count, 3);
			while (generator.HasMore) {
				combination = "";
				var indices = generator.GetNext();
				for (int i = 0; i < indices.Length; i++) {
					combination += (elements[indices[i]]);
				}
				sized.Add(combination);
			}
			
			return sized.Count.ToString();
		}
	}
}
