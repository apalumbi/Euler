namespace Euler {
	public class Pair<T, U> {
		public T First;
		public U Second;
		public Pair(T first, U second) {
			First = first;
			Second = second;
		}

		public override string ToString() {
			return First.ToString() + " X " + Second.ToString();
		}
	}
}