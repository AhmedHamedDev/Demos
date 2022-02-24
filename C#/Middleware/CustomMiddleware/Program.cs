using CustomMiddleware;

var pipe = new PipeBuilder(First)
			.AddPipe(typeof(Try))
			.AddPipe(typeof(Wrap))
			.AddPipe(typeof(Wrap))
			.Build();

pipe("Wrold");

void First(string msg)
{
	Console.WriteLine($"executing {msg} first function");
}

void Seccond(string msg)
{
	Console.WriteLine($"executing {msg} seccond function");
}
