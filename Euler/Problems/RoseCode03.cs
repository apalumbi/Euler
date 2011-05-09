namespace Euler.Problems {
	public class RoseCode03 : Problem {

		public override string Solve() {
			var primes = Helper.BuildPrimes();

			var total = 0;
			foreach (var prime in primes) {
				if (prime < 1000000 && Helper.IsPalindrome(prime.ToString())) {
					total += prime;
				}
			}
			return total.ToString();
		}
		
		public override string Solution {
			get { return "4838098"; }
		}
	}
}