namespace stig
{
	static internal class Interval
	{
		static public bool WaitInterval(int i, int interval)
		{
			return i % (interval / 2) == 0;
		}
	}
}