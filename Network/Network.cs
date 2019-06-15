using System;
using System.Collections.Generic;
using System.Linq;

namespace Network
{
	public class Network
	{
		public int[,] Matrix { get; set; }
		public int VectorLength { get; set; }
		public List<int[]> Etalons { get; set; }

		public Network(int vectorLength)
		{
			VectorLength = vectorLength;
			Matrix = new int[vectorLength, vectorLength];
			Etalons = new List<int[]>();
		}

		public void AddVector(int[] vector)
		{
			if (vector.Length != VectorLength)
				throw new ArgumentException("[err]: Entire vector`s length doesn`t match");
			
			Matrix = Matrix
				.Add(vector.MultiplySelfTransponent())
				.NullifyMainDiagonal();
			
			Etalons.Add(vector);
		}

		public int[] Restore(int[] vector)
		{
			if (vector.Length != VectorLength)
				throw new ArgumentException("[err]: Entire vector`s length doesn`t match");

			var prev = new int[VectorLength];

			while(!vector.SequenceEqual(prev))
			{
				prev = vector;
				vector = Matrix.Multiply(vector).Select(el => el >= 0 ? 1 : -1).ToArray();
			}

			return prev;
		}
	}
}
