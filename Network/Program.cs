using System;

namespace Network
{
	public class Program
	{
		public static void Main(string[] args)
		{
			
			if (args.Length > 3)
			{
				var width = int.Parse(args[0]);
				var height = int.Parse(args[1]);
				var nn = new Network(width * height);
				
				var images = NeuroProg.GetImages(args[2]);
				foreach (var image in images)
				{
					nn.AddVector(image);
				}

				var input = NeuroProg.GetImages(args[3])[0];
				var result = nn.Restore(input);
				NeuroProg.SaveImage(result, width, args[4]);
			}
		}
	}
}
