using TicketMatic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;


namespace TicketMatic
{
    class Session
    {
        public Movie movie { get; set; }
        public Hall hall { get; set; }
        public int number { get; set; }
        public char subtitle { get; set; } // Y = yes | N = no 
        public TimeSpan time { get; set; }

        public (int, TimeSpan, Movie, char, Hall) generate_session1()
        {
            // Generates the session1
            Session session1 = new Session();
            session1.number = 1;
            session1.time = new TimeSpan(19, 0, 0);
            session1.subtitle = 'N';

            var movie1 = new Movie();
            //var (movie1Name, movie1Duration, movie1Genre) = movie1.generate_movie1();
            session1.movie = movie1;
            
            var hall1 = new Hall();
            //var hall1Number = hall1.generate_hall1();
            session1.hall = hall1;
            return (session1.number, session1.time, session1.movie, session1.subtitle, session1.hall);
        }
        
        public (int, TimeSpan, Movie, char, int) generate_session2()
        {
            // Generates the session2
            Session session2 = new Session();
            session2.number = 2;
            session2.time = new TimeSpan(23, 0, 0);
            var movie1 = new Movie();
            var (movie1Name, movie1Duration, movie1Genre) = movie1.generate_movie1();
            session2.movie = movie1;
            session2.subtitle = 'Y';
            var hall1 = new Hall();
            var hall1Number = hall1.generate_hall1();
            session2.hall = hall1;
            return (session2.number, session2.time, session2.movie, session2.subtitle, hall1Number);
        }
        
        public (int, TimeSpan, Movie, char, int) generate_session3()
        {
            // Generates the session3
            Session session3 = new Session();
            session3.number = 3;
            session3.time = new TimeSpan(19, 0, 0);
            var movie1 = new Movie();
            var (movie1Name, movie1Duration, movie1Genre) = movie1.generate_movie1();
            session3.movie = movie1;
            session3.subtitle = 'N';
            var hall2 = new Hall();
            var hall2Number = hall2.generate_hall2();
            session3.hall = hall2;
            return (session3.number, session3.time, session3.movie, session3.subtitle, hall2Number);
        }
        
        public (int, TimeSpan, Movie, char, int) generate_session4()
        {
            // Generates the session4
            Session session4 = new Session();
            session4.number = 4;
            session4.time = new TimeSpan(23, 0, 0);
            var movie1 = new Movie();
            var (movie1Name, movie1Duration, movie1Genre) = movie1.generate_movie1();
            session4.movie = movie1;
            session4.subtitle = 'Y';
            var hall2 = new Hall();
            var hall2Number = hall2.generate_hall2();
            session4.hall = hall2;
            return (session4.number, session4.time, session4.movie, session4.subtitle, hall2Number);
        }
        
        public (int, TimeSpan, Movie, char, int) generate_session5()
        {
            // Generates the session5
            Session session5 = new Session();
            session5.number = 5;
            session5.time = new TimeSpan(19, 0, 0);
            var movie2 = new Movie();
            var (movie2Name, movie2Duration, movie2Genre) = movie2.generate_movie2();
            session5.movie = movie2;
            session5.subtitle = 'N';
            var hall3 = new Hall();
            var hall3Number = hall3.generate_hall3();
            session5.hall = hall3;
            return (session5.number, session5.time, session5.movie, session5.subtitle, hall3Number);
        }
        
        public (int, TimeSpan, Movie, char, int) generate_session6()
        {
            // Generates the session6
            Session session6 = new Session();
            session6.number = 6;
            session6.time = new TimeSpan(23, 0, 0);
            var movie2 = new Movie();
            var (movie2Name, movie2Duration, movie2Genre) = movie2.generate_movie2();
            session6.movie = movie2;
            session6.subtitle = 'Y';
            var hall3 = new Hall();
            var hall3Number = hall3.generate_hall3();
            session6.hall = hall3;
            return (session6.number, session6.time, session6.movie, session6.subtitle, hall3Number);
        }
        
        public (int, TimeSpan, Movie, char, int) generate_session7()
        {
            // Generates the session7
            Session session7 = new Session();
            session7.number = 7;
            session7.time = new TimeSpan(19, 0, 0);
            var movie2 = new Movie();
            var (movie2Name, movie2Duration, movie2Genre) = movie2.generate_movie2();
            session7.movie = movie2;
            session7.subtitle = 'N';
            var hall4 = new Hall();
            var hall4Number = hall4.generate_hall4();
            session7.hall = hall4;
            return (session7.number, session7.time, session7.movie, session7.subtitle, hall4Number);
        }
        
        public (int, TimeSpan, Movie, char, int) generate_session8()
        {
            // Generates the session8
            Session session8 = new Session();
            session8.number = 8;
            session8.time = new TimeSpan(23, 0, 0);
            var movie2 = new Movie();
            var (movie2Name, movie2Duration, movie2Genre) = movie2.generate_movie2();
            session8.movie = movie2;
            session8.subtitle = 'Y';
            var hall4 = new Hall();
            var hall4Number = hall4.generate_hall4();
            session8.hall = hall4;
            return (session8.number, session8.time, session8.movie, session8.subtitle, hall4Number);
        }
    }
}
