using Library.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Commands
{
    public record InsertPersonCommand(string FirstName, string LastName) : IRequest<Person>;
    //public class InsertPersonCommand : IRequest<Person>
    //{
    //    public String FirstName { get; set; }
    //    public String LastName { get; set; }
    //    public InsertPersonCommand(string firstname, string lastname)
    //    {
    //        FirstName = firstname;
    //        LastName = lastname;
    //    }
    //}
}
