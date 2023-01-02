namespace SITG
{
	static public class Program
	{
		static async Task Main(string[] args)
		{
			try
			{
				var arguments = new Arguments(args).Process();

				int? len = await SITGmain.SitgMain(arguments);

				if (len != null)
				{
					await GIFmaker.Make($"{arguments[7]}\\{arguments[6]}", int.Parse(arguments[5]), len);
				}
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}
		}
	}
}