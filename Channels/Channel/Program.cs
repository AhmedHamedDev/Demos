
using System.Collections.Concurrent;

var channel = new Channel<string>();

Task.WaitAll(Consumer(channel), Producer(channel), Producer(channel), Producer(channel), Producer(channel));


async Task Producer(IWrite<string> writer)
{
	for (int i = 0; i < 1; i++)
	{
		writer.Push(i.ToString());
		await Task.Delay(100);
	}
	writer.Complete();
}

async Task Consumer(IRead<string> reader)
{
	while (!reader.IsComplete())
	{
		var msg = await reader.Read();
        Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
	}
}

public interface IRead<T>
{
	Task<T> Read();
	bool IsComplete();
}

public interface IWrite<T>
{
	void Push(T msg);
	void Complete();
}


public class Channel<T> : IRead<T>, IWrite<T>
{
	private bool Finished;

	private ConcurrentQueue<T> _queue;
	private SemaphoreSlim _flag;

	public Channel()
	{
		_queue = new ConcurrentQueue<T>();
		_flag = new SemaphoreSlim(0);
	}

	public void Push(T msg)
	{
		_queue.Enqueue(msg);
		_flag.Release();
	}

	public async Task<T> Read()
	{
		// wait until push finish to read
		// so not many threads read same data at the same time
		await _flag.WaitAsync();

		if (_queue.TryDequeue(out var msg))
		{
			return msg;
		}

		return default;
	}

	public void Complete()
	{
		Finished = true;
	}

	public bool IsComplete()
	{
		return Finished && _queue.IsEmpty;
	}
}