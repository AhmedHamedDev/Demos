using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User_Defines_Conversion_Operators
{
    public class UserId
    {
        public UserId(Guid value)
        {
            Value = value;
        }

        public Guid Value { get; }

        // convert from guid to userid
        public static implicit operator UserId(Guid guid)
        {
            return new UserId(guid);
        }

        // convert from userid to guid
        public static implicit operator Guid(UserId userId)
        {
            return userId.Value;
        }

        // convert from guid to userid
        //public static explicit operator UserId(Guid guid)
        //{
        //    return new UserId(guid);
        //}

        // convert from userid to guid
        //public static explicit operator Guid(UserId userId)
        //{
        //    return userId.Value;
        //}
    }
}
