
Action<string> pipe = (msg) =>
	Try2(msg, (msg1) =>
		Try(msg1, (msg2) =>
			Wrap(msg2, Seccond)));

pipe("1");

void First(string msg)
{
	Console.WriteLine($"executing {msg} first function");
}

void Seccond(string msg)
{
	Console.WriteLine($"executing {msg} seccond function");
}

void Wrap(string msg, Action<string> function)
{
	Console.WriteLine("start");
	function(msg);
	Console.WriteLine("ends");
}

void Try(string msg, Action<string> function)
{
	try
	{
		Console.WriteLine("trying");
		function(msg);
	}
	catch (Exception)
	{

	}
}

void Try2(string msg, Action<string> function)
{
	try
	{
		Console.WriteLine("trying2");
		function(msg);
	}
	catch (Exception)
	{

	}
}