using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

namespace Euler.Problems {
	public class Problem62 : Problem {

		public override string Solve() {
			var bunchOfCubes = new HashSet<long>();
			var lengthOfCube = 0;
			long i = 0;
			var limitReached = false;
			var result = "";

			var instanceList = new List<Pair<Instances, long>>();
			while (!limitReached) {
				i++;
				var cube = i * i * i;
				var cubeString = cube.ToString();
				if (cubeString.Length != lengthOfCube) {
					lengthOfCube = cubeString.Length;
					instanceList = new List<Pair<Instances, long>>();
				}
				instanceList.Add(new Pair<Instances, long>(Helper.CountInstances(cubeString), cube));

				var groupings = from instance in instanceList
												group instance by instance.First.StringValue;

				var instanceCount = groupings.Where(g => g.Count() == 5);
				if (instanceCount.Count() != 0) {
					limitReached = true;
					result = instanceList.Where(instance => instance.First.StringValue == instanceCount.First().Key).Min(c => c.Second).ToString();
				}
			}
			return result;
		}

		public override string Solution {
			get { return "127035954683"; }
		}
	}
}
