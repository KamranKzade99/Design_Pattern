using System.Text;

namespace _5_Builder;

class EndPointBuilder
{
	private readonly string _baseUrl;
	private readonly StringBuilder _routeParameters;
	private readonly StringBuilder _queryStrings;


	public EndPointBuilder(string baseUrl)
	{
		_baseUrl = baseUrl;
		_routeParameters = new();
		_queryStrings = new();
	}


	public EndPointBuilder AppendRoute(string route)
	{
		_routeParameters.Append('/');
		_routeParameters.Append(route);
		return this;
	}


	public EndPointBuilder AppendQueryString(string key, string value)
	{
		_queryStrings.Append(key);
		_queryStrings.Append('=');
		_queryStrings.Append(value);
		_queryStrings.Append('&');

		return this;
	}



	public string Build()
	{
		var url = $"{_baseUrl}{_routeParameters}";

		if (_queryStrings.Length > 0)
			url += $"?{_queryStrings.ToString().TrimEnd('&')}";

		return url;
	}
}



//class Program
//{
//	static void Main()
//	{
//		string url = new EndPointBuilder("https://www.logbook.itstep.org")
//			.AppendRoute("api")
//			.AppendRoute("v1")
//			.AppendRoute("teachers")
//			.AppendQueryString("name", "Kamran")
//			.AppendQueryString("surname", "Karimzada")
//			.Build();


//		Console.WriteLine(url);
//	}
//}
