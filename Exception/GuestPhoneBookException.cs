using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exception1
{
    public class GuestPhoneBookException: ApplicationException
    {
        public GuestPhoneBookException() { }
        public GuestPhoneBookException(string message) : base(message) { }

        public GuestPhoneBookException(string message, System.Exception innerException) { }



    }
}
