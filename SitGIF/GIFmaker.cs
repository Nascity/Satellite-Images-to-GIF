using AnimatedGif;

namespace SITG
{
	static internal class GIFmaker
	{
		static public async Task Make(string path, int interval, int? length, int delay = 33)
		{
			using (var gif = new AnimatedGifCreator($"{path}.gif", delay))
			{
				Console.WriteLine("Creating GIF...");

				for (int i = 0; i < length; i++)
				{
					if (Interval.WaitInterval(i, interval))
					{
						try
						{
							await gif.AddFrameAsync($"{path}_{i}.png");
						}
						catch (Exception e)
						{
							Console.WriteLine(e.Message);
							return;
						}
					}
				}
			}
		}
	}
}