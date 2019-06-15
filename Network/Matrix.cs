using System;

namespace Network
{
	public static class Matrix
	{
		public static int[,] Multiply(this int[,] m1, int[,] m2)
		{
			if (m1.GetUpperBound(1) != m2.GetUpperBound(0))
				throw new ArgumentException("[err]: Dimensions don`t match");

			var r = new int
			[
				m1.GetUpperBound(0) + 1,
				m2.GetUpperBound(1) + 1
			];

			for (int i = 0; i <= m1.GetUpperBound(0); i++)
				for (int j = 0; j <= m2.GetUpperBound(1); j++)
					for (int k = 0; k <= m1.GetUpperBound(1); k++)
						r[i,j] += m1[i,k] * m2[k,j];

			return r;
		}

		public static int[] Multiply(this int[,] m1, int[] m2)
		{
			if (m1.GetUpperBound(1) != m2.Length - 1)
				throw new ArgumentException("[err]: Dimensions don`t match");

			var r = new int[m2.Length];

			for (int i = 0; i <= m1.GetUpperBound(0); i++)
				for (int j = 0; j < m2.Length; j++)
					r[i] += m1[i,j] * m2[j];

			return r;
		}

		public static int[,] MultiplySelfTransponent(this int[] m)
		{
			var len = m.Length;
			var r = new int[len,len];

			for (int i = 0; i < len; i++)
				for (int j = 0; j < len; j++)
					r[i,j] = m[i] * m[j];

			return r;
		}

		public static int[,] Add(this int[,] m1, int[,] m2)
		{
			if (m1.GetUpperBound(0) != m2.GetUpperBound(0) ||
				m1.GetUpperBound(1) != m2.GetUpperBound(1))
				throw new ArgumentException("[err]: Dimensions don`t match");

			var r = new int
			[
				m1.GetUpperBound(0) + 1,
				m1.GetUpperBound(1) + 1
			];

			for (int i = 0; i <= m1.GetUpperBound(0); i++)
				for (int j = 0; j <= m1.GetUpperBound(1); j++)
					r[i,j] = m1[i,j] + m2[i,j];

			return r;
		}

		public static int[,] NullifyMainDiagonal(this int[,] m)
		{
			if (m.GetUpperBound(0) != m.GetUpperBound(1))
				throw new ArgumentException("[err]: Matrix is not a square");
			
			for (int i = 0; i <= m.GetUpperBound(0); i++)
				m[i,i] = 0;

			return m;
		}
	}
}
