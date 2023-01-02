using System.Net.Http.Headers;

namespace SITG
{
	internal class KMA
	{
		#region 키
		private readonly string key = "WuYigYpzVdnTnYYq9TrIRJtcQmYHHevRI2ljxaarYXFGuiv6RbaZXbAOAeie9MGApsdH%2B8hDjGb5YKJ8cv5kIw%3D%3D";
		private readonly string ver = "0.1";
		#endregion

		#region 변수
		private string _serviceKey;
		private string _pageNo;
		private string _numOfRows;
		private string _dataType;   // 고정
		private string _sat;        // 고정
		private string _data;
		private string _area;
		private string _time;
		#endregion

		#region
		private string _addr = "https://apis.data.go.kr/1360000/SatlitImgInfoService/getInsightSatlit?";
		#endregion

		#region 생성자
		internal KMA(string[] args)
		{
			_serviceKey = key;
			_pageNo = args[0];
			_numOfRows = args[1];
			_dataType = "JSON";
			_sat = "G2";

			switch (args[2])
			{
				case "ir":
					_data = "ir105";
					break;
				default:
				case "vi":
					_data = "vi006";
					break;
				case "wv":
					_data = "wv069";
					break;
				case "sw":
					_data = "sw038";
					break;
				case "rgbt":
					_data = "rgbt";
					break;
				case "rgbdn":
					_data = "rgbdn";
					break;
			}

			_area = args[3];
			_time = args[4];

			BuildURL();
		}
		#endregion

		/// <summary>요청을 통해 JSON 파일을 받는다.</summary>
		/// <returns>JSON 응답</returns>
		public async Task<string> Request()
		{
			try
			{
				HttpClient client = new HttpClient();
				HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, _addr);

				request.Headers.UserAgent.Add(new ProductInfoHeaderValue("STIG", ver));

				return await client.SendAsync(request).Result.EnsureSuccessStatusCode().Content.ReadAsStringAsync();
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
				return "";
			}
		}

		/// <summary>요청을 통해 그 웹사이트의 파일들 바이트 배열로 다운로드한다.</summary>
		/// <param name="url">웹사이트 URL</param>
		/// <returns>바이트 배열</returns>
		public async Task<byte[]> Request(string url)
		{
			try
			{
				HttpClient client = new HttpClient();
				HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, url);

				request.Headers.UserAgent.Add(new ProductInfoHeaderValue("STIG", ver));

				return await client.SendAsync(request).Result.EnsureSuccessStatusCode().Content.ReadAsByteArrayAsync();
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
				return new byte[0];
			}
		}

		/// <summary>전달인자로부터 URL을 만든다.</summary>
		private void BuildURL()
		{
			_addr += $"serviceKey={_serviceKey}&pageNo={_pageNo}&numOfRows={_numOfRows}"
				+ $"&dataType={_dataType}&sat={_sat}&data={_data}&area={_area}&time={_time}";
		}
	}
}
