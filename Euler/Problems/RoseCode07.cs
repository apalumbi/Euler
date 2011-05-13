using System.Linq;
using System.Numerics;

namespace Euler.Problems {
	public class RoseCode07 : Problem {

		public override string Solve() {
			for (long i = 100000; i > 0; i--) {
				var baseEight = Helper.ConvertToBase(i, 8);
				var reverseNumber = long.Parse(new string(i.ToString().Reverse().ToArray()));
				var baseNine = Helper.ConvertToBase(reverseNumber, 9);

				if (baseNine == baseEight) {
					return baseEight;
				}
			}

			return Helper.GARF;
		}

		public override string Solution {
			get { return "156535"; }
		}
	}
}