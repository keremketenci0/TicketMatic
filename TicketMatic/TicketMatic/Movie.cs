using TicketMatic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;


namespace TicketMatic
{

    class Movie
    {
        public Session session { get; set; }
        public Hall hall { get; set; }
        public string name { get; set; }
        public string genre { get; set; }
        public double duration { get; set; }

        public (string, double, string) generate_movie1()
        {
            //Generates the movie1
            this.name = "The Batman";
            this.duration = 2.56;
            this.genre = "superhero";
            return (this.name, this.duration, this.genre);
        }
      
        public (string, double, string) generate_movie2()
        {
            //Generates the movie2
            this.name = "Spider-Man 2";
            this.duration = 2.07;
            this.genre = "superhero";
            return (this.name, this.duration, this.genre);
        }
    }
}