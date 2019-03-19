using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaTickets.Domain.Entities
{
    public class EmailSettings
    {
        public string PrimaryDomain { get; }

        public int PrimaryPort { get; }

        public string SecondayDomain { get; }

        public int SecondaryPort { get; }

        public string UsernameEmail { get; }

        public string UsernamePassword { get; }

        public string FromEmail { get; }

        public string ToEmail { get; }

        public string CcEmail { get;  }
    }
}
