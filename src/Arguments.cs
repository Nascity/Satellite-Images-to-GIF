namespace SITG
{
	internal class Arguments
	{
		private const string prefix = "--";
		private const string suffix = ":";

		private string[] args;

		private string data;
		private string area;
		private string time;

		private string? interval;
		private string? filename;
		private string? directory;

		public Arguments(string[] args)
		{
			if (args.Length >= 6 && args.Length % 2 == 0)
			{
				this.args = new string[8];

				for (int i = 0; i < args.Length; i++)
				{
					if (args[i] == $"{prefix}data{suffix}") data = args[++i];
					if (args[i] == $"{prefix}area{suffix}") area = args[++i];
					if (args[i] == $"{prefix}time{suffix}") time = args[++i];

					if (args[i] == $"{prefix}interval{suffix}") interval = args[++i];
					if (args[i] == $"{prefix}filename{suffix}") filename = args[++i];
					if (args[i] == $"{prefix}directory{suffix}") directory = args[++i];
				}

				if (data == null || area == null || time == null)
				{
					SITGmain.HelpMsg();
					throw new Exception("Incorrect arguments");
				}
			}
			else
			{
				SITGmain.HelpMsg();
				throw new Exception("Incorrect arguments");
			}
		}

		public string[] Process()
		{
			args[0] = "1";
			args[1] = "100";
			args[2] = data;
			args[3] = area;
			args[4] = time;

			args[5] = interval ?? "2";
			args[6] = filename ?? "out";
			args[7] = directory ?? "output";

			return args;
		}
	}
}
