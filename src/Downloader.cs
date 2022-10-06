namespace SITG
{
	static internal class Downloader
	{
		public static void Download(byte[] info, int index, string filename = "out", string directory = "download")
		{
			try
			{
				Directory.CreateDirectory(directory);

				File.WriteAllBytes($"{directory}\\{filename}_{index}.png", info);
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}
		}
	}
}
