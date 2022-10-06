using Newtonsoft.Json.Linq;

namespace SITG
{
	static internal class SITGmain
	{
		/// <summary>도움말을 출력한다.</summary>
		static public void HelpMsg()
		{
			Console.WriteLine
($@"
===== USAGE

sitg --data: <DATA> --area: <AREA> --time: <TIME> --interval: <INTERVAL> --filename: <FILENAME> --directory: <DIRECTORY>

## DATA
ir: 적외영상
vi: 가시영상
wv: 수증기영상
sw: 단파적외영상
rbgt: RGB컬러
rgbdn: RGB주야간합성

## AREA
fd: 전구
ea: 동아시아
ko: 한반도

## TIME
YYYYMMDD 양식으로 입력

## INTERVAL (Optional)
시간 간격(분)을 2의 배수로 입력
(기본값은 2분)

## FILENAME (Optional)
출력할 파일명 입력
(확장자명 없이)

## DIRECTORY
출력할 폴더명 입력

==== USAGE
");
		}

		/// <summary>
		/// 프로그램의 EntryPoint이었다.
		/// 지금은 이 클래스의 진입점이다.
		/// </summary>
		/// <param name="args">여러가지 전달인자</param>
		static public async Task<int?> SitgMain(string[] args)
		{
			try
			{
				if (args.Length == 8)
				{
					if (int.Parse(args[5]) % 2 == 0)
					{
						KMA kma = new KMA(args);

						string response = await kma.Request();

						if (!string.IsNullOrEmpty(response))
						{
							JObject jResponse = JObject.Parse(response);

							if (Response.VerifyHeader(jResponse))
							{
								var imageURL = jResponse["response"]?["body"]?["items"]?["item"]?.Children()["satImgC-file"]?.ToList()[0].ToString();

								if (imageURL != null)
								{
									string[] imageURLs = imageURL.Trim(new char[] { '[', ']' }).Split(',');

									for (int i = 0; i < imageURLs.Length; i++)
									{
										if (Interval.WaitInterval(i, int.Parse(args[5])))
										{
											imageURLs[i] = imageURLs[i].TrimStart();

											Console.WriteLine($"{imageURLs[i]} [{i + 1}/{imageURLs.Length}]");

											Downloader.Download(await kma.Request(imageURLs[i]), i, args[6], args[7]);
										}
									}

									return imageURLs.Length;
								}
							}
							else
							{
								Console.WriteLine($"Errorcode: {jResponse["response"]?["header"]?["resultCode"]?.ToString()}");
							}
						}
					}
					else
					{
						throw new Exception("Interval error.");
					}
				}
				else
				{
					HelpMsg();
				}

				return null;
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
				return null;
			}
		}
	}
}