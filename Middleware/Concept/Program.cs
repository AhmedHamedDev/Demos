
Try(LambdaFirst);
Wrap(LambdaSeccond);


void First()
{
    Console.WriteLine("executing first function");
}

void Seccond()
{
    Console.WriteLine("executing seccond function");
}

void LambdaFirst()
{
	Wrap(First);
}
void LambdaSeccond()
{
	Try(Seccond);
}

void Wrap(Action function)
{
    Console.WriteLine("start");
	function();
    Console.WriteLine("ends");
}

void Try(Action function)
{
	try
	{
		Console.WriteLine("trying");
		function();
	}
	catch (Exception)
	{

	}
}