using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Network
{
	public static class NeuroProg
	{
		public static int[][] GetImages(string filename)
		{
			var images = new List<List<int>>();
			var image = new List<int>();

			using (var sr = new StreamReader(filename))
			{
				char[] tmp;
				while (!sr.EndOfStream)
				{
					tmp = sr.ReadLine().ToCharArray();
					if (tmp[0] == '-')
					{
						images.Add(image);
						image = new List<int>();
					}
					else
						image.AddRange(tmp.Select(el => el == '0' ? -1 : 1));
				}
				images.Add(image);
			}

			return images.Select(el => el.ToArray()).ToArray();
		}

		public static void SaveImage(int[] image, int size, string filename)
		{
			var tmp = "";
			using (var sw = new StreamWriter(filename))
			{
				for (int i = 0; i < image.Length / size; i++)
				{
					for (int j = 0; j < size; j++)
					{
						tmp += image[i * size + j] == -1 ? "0" : "1";
					}
					sw.WriteLine(tmp);
					tmp = "";
				}
			}
		}
	}
}