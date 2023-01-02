using Newtonsoft.Json.Linq;

namespace SITG
{
	internal static class Response
	{
		/// <summary>요청이 성공적이었는지 확인한다.</summary>
		/// <param name="resp">응답</param>
		/// <returns>성공 여부</returns>
		public static bool VerifyHeader(JObject resp)
		{
			string? code = resp["response"]?["header"]?["resultCode"]?.ToString();

			return !string.IsNullOrEmpty(code) && code == "00";
		}
	}
}
