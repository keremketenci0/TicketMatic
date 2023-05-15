using TicketMatic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;


namespace TicketMatic
{
    class Reservation
    {
        public Session session { get; set; }
        public Hall hall { get; set; }
        public Movie movie { get; set; }
        public DateTime date { get; set; }
        public string full_name { get; set; }
        public string seat { get; set; }
        public string payment_method { get; set; }


    }
}
