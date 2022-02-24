using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomMiddleware
{
	public class Wrap : Pipe
	{
		public Wrap(Action<string> action) : base(action) { }

		public override void Handle(string msg)
		{
			Console.WriteLine("start");
			_action(msg);
			Console.WriteLine("ends");
		}
	}
}
