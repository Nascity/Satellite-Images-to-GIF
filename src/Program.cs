namespace stig
{
	static public class Program
	{
		static async Task Main(string[] args)
		{
			if (args.Length == 6)
			{
				args.Append("output");
				args.Append("out");
			}
			else if (args.Length == 7)
			{
				args.Append("out");
			}
			else if (args.Length == 8)
			{

			}
			else
			{
				SITGmain.HelpMsg();
				return;
			}

			int? len = await SITGmain.SitgMain(args);

			if (len != null)
			{
				await GIFmaker.Make($"{args[7]}\\{args[6]}", int.Parse(args[5]), len);
			}
		}
	}
}