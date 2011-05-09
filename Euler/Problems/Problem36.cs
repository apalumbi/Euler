namespace Euler.Problems {
	public class Problem36 : Problem {

		public override string Solve() {
			var sum = 0;
			for (int i = 0; i < 1000000; i++) {
				if (Helper.IsPalindrome(i.ToString())) {
					if (Helper.IsPalindrome(Helper.ConvertToBase(i, 2))) {
						sum += i;
					}
				}
			}
			return sum.ToString();
		}

		public override string Solution {
			get { return "872187"; }
		}
	}
}