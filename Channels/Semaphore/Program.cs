
SemaphoreSlim gate = new SemaphoreSlim(1);

for (int i = 0; i < 10; i++)
{
    Console.WriteLine("Start");
	await gate.WaitAsync();
    Console.WriteLine("Do Some Work");
	gate.Release();
    Console.WriteLine("Finish");
}