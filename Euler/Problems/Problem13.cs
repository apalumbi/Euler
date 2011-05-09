using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Numerics;

namespace Euler.Problems {
	public class Problem13 : Problem {

		public override string Solve() {
			var lines = File.ReadAllLines(@"Files\" + this.Name); 
			var numbers = lines.Select(n => BigInteger.Parse(n));
			
			BigInteger sum = 0;
			foreach (var number in numbers) {
				sum += number;
			}

			return sum.ToString().Substring(0, 10);
		}

		public override string Solution {
			get { return "5537376230"; }
		}
	}
}
