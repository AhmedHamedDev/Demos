using Library.Commands;
using Library.DataAccess;
using Library.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Handlers
{
    internal class InsertPersonHandler : IRequestHandler<InsertPersonCommand, Person>
    {
        private readonly IDataAccess _dataAccess;

        public InsertPersonHandler(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }
        public async Task<Person> Handle(InsertPersonCommand request, CancellationToken cancellationToken)
        {
            return _dataAccess.InsertPerson(request.FirstName, request.LastName);
        }
    }
}
