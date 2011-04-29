using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

namespace Euler.Problems {
	public class Problem32 : Problem {
		public override string Solve() {
			var results = new HashSet<BigInteger>();
			for (BigInteger i = 0; i < 10000; i++) {
				if (CannotBePandigital(i.ToString())) {
					continue;
				}

				for (BigInteger j = 0; j < 10000; j++) {
					if (CannotBePandigital(j.ToString())) {
						continue;
					}

					var product = i * j;
					if (product.ToString().Length > 9) {
						continue;
					}
					var number = i.ToString() + j.ToString() + product.ToString();
					if (IsPandigital(number)) {
						if (!results.Contains(product)) {
							results.Add(product);
							Helper.Write(number);
						}
					}
				}
			}

			BigInteger sum = 0;
			foreach (var r in results) {
				sum += r;
			}
			return sum.ToString();
		}
			

		bool CannotBePandigital(string number) {
			var i = CountInstances(number);

			return i.Ones > 1 || i.Twos > 1 || i.Threes > 1 || i.Fours > 1 ||
						 i.Fives > 1 || i.Sixes > 1 || i.Sevens > 1 || i.Eights > 1 ||
						 i.Nines > 1 || i.Zeros > 0;
		}

		Instances CountInstances(string number) {
			var instances = new Instances();
			foreach (var n in number) {
				if (n == '1') instances.Ones++;
				else if (n == '2') instances.Twos++;
				else if (n == '3') instances.Threes++;
				else if (n == '4') instances.Fours++;
				else if (n == '5') instances.Fives++;
				else if (n == '6') instances.Sixes++;
				else if (n == '7') instances.Sevens++;
				else if (n == '8') instances.Eights++;
				else if (n == '9') instances.Nines++;
				else if (n == '0') instances.Zeros++;
			}
			return instances;
		}

		bool IsPandigital(string number) {
			if (number.Length != 9) {
				return false;
			}

			var i = CountInstances(number);

			return i.Ones == 1 && i.Twos == 1 && i.Threes == 1 && i.Fours == 1 &&
						 i.Fives == 1 && i.Sixes == 1 && i.Sevens == 1 && i.Eights == 1 &&
						 i.Nines == 1 && i.Zeros == 0;
		}
	}

	public class Instances {
		public int Ones = 0;
		public int Twos = 0;
		public int Threes = 0;
		public int Fours = 0;
		public int Fives = 0;
		public int Sixes = 0;
		public int Sevens = 0;
		public int Eights = 0;
		public int Nines = 0;
		public int Zeros = 0;
	}
}
