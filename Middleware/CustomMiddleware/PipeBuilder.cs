using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomMiddleware
{
    public class PipeBuilder
    {
		Action<string> _mainAction;
		List<Type> _pipeTypes;
		public PipeBuilder(Action<string> mainAction)
		{
			_mainAction = mainAction;
			_pipeTypes = new List<Type>();
		}

		public PipeBuilder AddPipe(Type pipeType)
		{
			_pipeTypes.Add(pipeType);
			return this;
		}

		private Action<string> CreatePipe(int index)
		{
			if (index < _pipeTypes.Count - 1)
			{
				var childPipeHandle = CreatePipe(index + 1);
				var pipe = (Pipe)Activator.CreateInstance(_pipeTypes[index], childPipeHandle);
				return pipe.Handle;
			}
			else
			{
				var finalPipe = (Pipe)Activator.CreateInstance(_pipeTypes[index], _mainAction);
				return finalPipe.Handle;
			}
		}

		public Action<string> Build()
		{
			return CreatePipe(0);
		}
	}
}
