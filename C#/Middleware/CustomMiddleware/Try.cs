using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomMiddleware
{
	public class Try : Pipe
	{
		public Try(Action<string> action) : base(action) { }

		public override void Handle(string msg)
		{
			try
			{
				Console.WriteLine("trying");
				_action(msg);
			}
			catch (Exception)
			{

			}
		}
	}
}
