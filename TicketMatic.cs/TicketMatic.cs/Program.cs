using TicketMatic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;


namespace TicketMatic
{
    class Program
    {
        public static int selected_date;
        public static int selected_movie;
        public static int selected_session;
        public static string selected_seat;
        public static string seat_number;

        public static int number_of_tickets;
        public static int number_of_tickets2;

        public static int confirmation;

        public static List<string> taken_seats = new List<string>();

        public static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("version: 1.0");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("__________________ _______  _        _______ _________ _______  _______ __________________ _______ ");
            Console.WriteLine("\\__   __/\\__   __/(  ____ \\| \\    /\\(  ____ \\\\__   __/(       )(  ___  )\\__   __/\\__   __/(  ____ \\");
            Console.WriteLine("   ) (      ) (   | (    \\/|  \\  / /| (    \\/   ) (   | () () || (   ) |   ) (      ) (   | (    \\/");
            Console.WriteLine("   | |      | |   | |      |  (_/ / | (__       | |   | || || || (___) |   | |      | |   | |      ");
            Console.WriteLine("   | |      | |   | |      |   _ (  |  __)      | |   | |(_)| ||  ___  |   | |      | |   | |      ");
            Console.WriteLine("   | |      | |   | |      |  ( \\ \\ | (         | |   | |   | || (   ) |   | |      | |   | |      ");
            Console.WriteLine("   | |   ___) (___| (____/\\|  /  \\ \\| (____/\\   | |   | )   ( || )   ( |   | |   ___) (___| (____/\\");
            Console.WriteLine("   )_(   \\_______/(_______/|_/    \\/(_______/   )_(   |/     \\||/     \\|   )_(   \\_______/(_______/");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("\nDeveloped by Kerem Ketenci");
            Console.WriteLine();
            Console.WriteLine();

            // Generate the seats
            var (seats1, seats1s, seatList1, occupied_seats1) = Hall.gerenate_seats1();
            var (seats2, seats2s, seatList2, occupied_seats2) = Hall.gerenate_seats2();
            var (seats3, seats3s, seatList3, occupied_seats3) = Hall.gerenate_seats3();
            var (seats4, seats4s, seatList4, occupied_seats4) = Hall.gerenate_seats4();
            var (seats5, seats5s, seatList5, occupied_seats5) = Hall.gerenate_seats5();
            var (seats6, seats6s, seatList6, occupied_seats6) = Hall.gerenate_seats6();
            var (seats7, seats7s, seatList7, occupied_seats7) = Hall.gerenate_seats7();
            var (seats8, seats8s, seatList8, occupied_seats8) = Hall.gerenate_seats8();

            List<int> occupied_seat_list = new List<int>
            {
                occupied_seats1,
                occupied_seats2,
                occupied_seats3,
                occupied_seats4,
                occupied_seats5,
                occupied_seats6,
                occupied_seats7,
                occupied_seats8
            };

            List<string>[] seat_list = new List<string>[8];
            seat_list[0] = seatList1;
            seat_list[1] = seatList2;
            seat_list[2] = seatList3;
            seat_list[3] = seatList4;
            seat_list[4] = seatList5;
            seat_list[5] = seatList6;
            seat_list[6] = seatList7;
            seat_list[7] = seatList8;

            // Generates the halls
            Hall hall = new Hall();
            hall.capacity = Hall.row * (2 * Hall.minrow + Hall.row - 1) / 2;

            var hall1 = new Hall();
            var hall1Number = hall1.generate_hall1();

            var hall2 = new Hall();
            var hall2Number = hall2.generate_hall2();

            var hall3 = new Hall();
            var hall3Number = hall3.generate_hall3();

            var hall4 = new Hall();
            var hall4Number = hall4.generate_hall4();

            // Generates the movies
            var movie1 = new Movie();
            var (movie1Name, movie1Duration, movie1Genre) = movie1.generate_movie1();

            var movie2 = new Movie();
            var (movie2Name, movie2Duration, movie2Genre) = movie2.generate_movie2();

            // Generates the sessions
            var session1 = new Session();
            var (session1Number, session1Time, session1Movie, session1Subtitle, session1Hall) = session1.generate_session1();

            var session2 = new Session();
            var (session2Number, session2Time, session2Movie, session2Subtitle, session2Hall) = session2.generate_session2();

            var session3 = new Session();
            var (session3Number, session3Time, session3Movie, session3Subtitle, session3Hall) = session3.generate_session3();

            var session4 = new Session();
            var (session4Number, session4Time, session4Movie, session4Subtitle, session4Hall) = session4.generate_session4();

            var session5 = new Session();
            var (session5Number, session5Time, session5Movie, session5Subtitle, session5Hall) = session5.generate_session5();

            var session6 = new Session();
            var (session6Number, session6Time, session6Movie, session6Subtitle, session6Hall) = session6.generate_session6();

            var session7 = new Session();
            var (session7Number, session7Time, session7Movie, session7Subtitle, session7Hall) = session7.generate_session7();

            var session8 = new Session();
            var (session8Number, session8Time, session8Movie, session8Subtitle, session8Hall) = session8.generate_session8();

            //Generates the dates
            DateTime date1 = new DateTime(2023, 05, 01);
            DateTime date2 = new DateTime(2023, 05, 02);
            DateTime date3 = new DateTime(2023, 05, 03);
            DateTime date4 = new DateTime(2023, 05, 04);
            DateTime date5 = new DateTime(2023, 05, 05);

            // Generates Reservation
            Reservation reservation = new Reservation();
            reservation.date = new DateTime();
            reservation.movie = new Movie();
            reservation.session = new Session();
            reservation.hall = new Hall();

            reservation.full_name = string.Empty;

            bool ok_fullname_selection = true;
            while (ok_fullname_selection)
            {
                try
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Enter your name and surname?");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("Type '0' to shutdown the program");
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    reservation.full_name = Console.ReadLine();
                    ok_fullname_selection = false;

                    if (reservation.full_name == "0")
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("Program is shutting down");
                        Environment.Exit(0);
                    }
                }
                catch (Exception)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("!!!!! You entered an invalid value !!!!!");
                    continue;
                }
                
                bool ok_date_selection = true;
                while (ok_date_selection)
                {
                    //Prints the dates
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("Available Dates");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("1) " + date1.ToString("dd.MM.yyyy"));
                    Console.WriteLine("2) " + date2.ToString("dd.MM.yyyy"));
                    Console.WriteLine("3) " + date3.ToString("dd.MM.yyyy"));
                    Console.WriteLine("4) " + date4.ToString("dd.MM.yyyy"));
                    Console.WriteLine("5) " + date5.ToString("dd.MM.yyyy"));

                    try
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("Which date do you want to buy tickets to?");
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("Type '0' to shutdown the program");
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        selected_date = Convert.ToInt32(Console.ReadLine());
                    }
                    catch (Exception)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("!!!!! Enter the number associated with the date !!!!!");
                        continue;
                    }

                    switch (selected_date)
                    {
                        case 0:
                            break;
                        case 1:
                            Console.WriteLine("Selected Date: " + date1.ToString("dd.MM.yyyy"));
                            reservation.date = date1;
                            ok_date_selection = false;
                            break;
                        case 2:
                            Console.WriteLine("Selected Date: " + date2.ToString("dd.MM.yyyy"));
                            reservation.date = date2;
                            ok_date_selection = false;
                            break;
                        case 3:
                            Console.WriteLine("Selected Date: " + date3.ToString("dd.MM.yyyy"));
                            reservation.date = date3;
                            ok_date_selection = false;
                            break;
                        case 4:
                            Console.WriteLine("Selected Date: " + date4.ToString("dd.MM.yyyy"));
                            reservation.date = date4;
                            ok_date_selection = false;
                            break;
                        case 5:
                            Console.WriteLine("Selected Date: " + date5.ToString("dd.MM.yyyy"));
                            reservation.date = date5;
                            ok_date_selection = false;
                            break;
                        default:
                            ok_date_selection = true;
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("!!!!! There is no date associated with this number !!!!!");
                            continue;
                    }
                    if (selected_date == 0)
                    {
                        Console.WriteLine("Returning to fullname selection");
                        ok_date_selection = false;
                        ok_fullname_selection = true;
                        break;
                    }

                    bool ok_movie_selection = true;
                    while (ok_movie_selection)
                    {
                        //Prints the movies
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("\nMovies");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("1) \"" + movie1Name + "\" | Genre: " + movie1Genre + " | Duration: " + movie1Duration);
                        Console.WriteLine();
                        Console.WriteLine("2) \"" + movie2Name + "\" | Genre: " + movie2Genre + " | Duration: " + movie2Duration);

                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("Which movie do you want to buy tickets to?");
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("Type '0' to return to the name entry screen");
                        try
                        {
                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                            selected_movie = Convert.ToInt32(Console.ReadLine());
                        }
                        catch (Exception)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("!!!!! Enter the number associated with the movie !!!!!");
                            continue;
                        }

                        switch (selected_movie)
                        {
                            case 0:
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                Console.WriteLine("Returning to date selection\n");
                                ok_date_selection = true;
                                break;
                            case 1:
                                Console.WriteLine("selected Movie \"" + movie1Name + "\"");
                                ok_movie_selection = false;
                                break;
                            case 2:
                                Console.WriteLine("selected Movie \"" + movie2Name + "\"");
                                ok_movie_selection = false;
                                break;
                            default:
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("!!!!! There is no movie associated with this number !!!!!");
                                ok_movie_selection = true;
                                continue;
                        }

                        // Returns back to date selection
                        if (selected_movie == 0)
                        {
                            ok_date_selection = true;
                            break;
                        }

                        bool ok_session_selection = true;
                        while (ok_session_selection)
                        {
                            switch (selected_movie)
                            {
                                case 1:
                                    reservation.movie = movie1;
                                    Console.ForegroundColor = ConsoleColor.Magenta;
                                    Console.WriteLine("\nAvailable sessions");
                                    Console.ForegroundColor = ConsoleColor.White;

                                    //Session 1
                                    Console.WriteLine("-----------------------------------------------------\n");
                                    Console.WriteLine("Session: " + session1Number);
                                    Console.WriteLine("Time: " + session1Time.ToString(@"hh\:mm"));
                                    Console.WriteLine("Subtitle: " + session1Subtitle);
                                    Console.WriteLine("Hall number: " + session1Hall);
                                    Console.WriteLine("\n-----------------------------------------------------\n");

                                    //Session 2
                                    Console.WriteLine("Session: " + session2Number);
                                    Console.WriteLine("Time: " + session2Time.ToString(@"hh\:mm"));
                                    Console.WriteLine("Subtitle: " + session2Subtitle);
                                    Console.WriteLine("Hall number: " + session2Hall);
                                    Console.WriteLine("\n-----------------------------------------------------\n");

                                    //Session 3
                                    Console.WriteLine("Session: " + session3Number);
                                    Console.WriteLine("Time: " + session3Time.ToString(@"hh\:mm"));
                                    Console.WriteLine("Subtitle: " + session3Subtitle);
                                    Console.WriteLine("Hall number: " + session3Hall);
                                    Console.WriteLine("\n-----------------------------------------------------\n");

                                    //Session 4
                                    Console.WriteLine("Session: " + session4Number);
                                    Console.WriteLine("Time: " + session4Time.ToString(@"hh\:mm"));
                                    Console.WriteLine("Subtitle: " + session4Subtitle);
                                    Console.WriteLine("Hall number: " + session4Hall);
                                    Console.WriteLine("\n-----------------------------------------------------\n");
                                    break;

                                case 2:
                                    reservation.movie = movie2;
                                    Console.ForegroundColor = ConsoleColor.Magenta;
                                    Console.WriteLine("\nAvailable sessions");
                                    Console.ForegroundColor = ConsoleColor.White;

                                    //Session 5
                                    Console.WriteLine("-----------------------------------------------------\n");
                                    Console.WriteLine("Session: " + session5Number);
                                    Console.WriteLine("Time: " + session5Time.ToString(@"hh\:mm"));
                                    Console.WriteLine("Subtitle: " + session5Subtitle);
                                    Console.WriteLine("Hall number: " + session5Hall);
                                    Console.WriteLine("\n-----------------------------------------------------\n");

                                    //Session 6
                                    Console.WriteLine("Session: " + session6Number);
                                    Console.WriteLine("Time: " + session6Time.ToString(@"hh\:mm"));
                                    Console.WriteLine("Subtitle: " + session6Subtitle);
                                    Console.WriteLine("Hall number: " + session6Hall);
                                    Console.WriteLine("\n-----------------------------------------------------\n");

                                    //Session 7
                                    Console.WriteLine("Session: " + session7Number);
                                    Console.WriteLine("Time: " + session7Time.ToString(@"hh\:mm"));
                                    Console.WriteLine("Subtitle: " + session7Subtitle);
                                    Console.WriteLine("Hall number: " + session7Hall);
                                    Console.WriteLine("\n-----------------------------------------------------\n");

                                    //Session 8
                                    Console.WriteLine("Session: " + session8Number);
                                    Console.WriteLine("Time: " + session8Time.ToString(@"hh\:mm"));
                                    Console.WriteLine("Subtitle: " + session8Subtitle);
                                    Console.WriteLine("Hall number: " + session8Hall);
                                    Console.WriteLine("\n-----------------------------------------------------\n");
                                    break;
                                default:
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("!!!!! There is no Session for this film !!!!!");
                                    continue;
                            }
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.WriteLine("Which session do you want to buy tickets to?");
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("Type '0' to go back to movie selection");

                            try
                            {
                                Console.ForegroundColor = ConsoleColor.DarkCyan;
                                selected_session = Convert.ToInt32(Console.ReadLine());
                            }
                            catch (Exception)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("!!!!! Enter the number associated with the session !!!!!");
                                continue;
                            }

                            //Returns back to movie selection
                            if (selected_session == 0)
                            {
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                Console.WriteLine("Returning to movie selection");
                                ok_movie_selection = true;
                                break;
                            }
                            else if (selected_movie == 1)
                            {
                                Console.ForegroundColor = ConsoleColor.DarkCyan;
                                switch (selected_session)
                                {
                                    case 1:
                                        Console.WriteLine("Selected session: " + session1Number);

                                        reservation.session.number = session1Number;
                                        ok_session_selection = false;
                                        break;
                                    case 2:
                                        Console.WriteLine("Selected session: " + session2Number);
                                        reservation.session.number = session2Number;
                                        ok_session_selection = false;
                                        break;
                                    case 3:
                                        Console.WriteLine("Selected session: " + session3Number);
                                        reservation.session.number = session3Number;
                                        ok_session_selection = false;
                                        break;
                                    case 4:
                                        Console.WriteLine("Selected session: " + session4Number);
                                        reservation.session.number = session4Number;
                                        ok_session_selection = false;
                                        break;
                                    default:
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("!!!!! There is no session associated with this number !!!!!");
                                        ok_session_selection = true;
                                        continue;
                                }
                            }

                            // Prints the selected session
                            else if (selected_movie == 2)
                            {
                                Console.ForegroundColor = ConsoleColor.DarkCyan;
                                switch (selected_session)
                                {
                                    case 0:
                                        break;
                                    case 5:
                                        Console.WriteLine("Selected session: " + session5Number);
                                        reservation.session.number = session5Number;
                                        ok_session_selection = false;
                                        break;
                                    case 6:
                                        Console.WriteLine("Selected session: " + session6Number);
                                        reservation.session.number = session6Number;
                                        ok_session_selection = false;
                                        break;
                                    case 7:
                                        Console.WriteLine("Selected session: " + session7Number);
                                        reservation.session.number = session7Number;
                                        ok_session_selection = false;
                                        break;
                                    case 8:
                                        Console.WriteLine("Selected session: " + session8Number);
                                        reservation.session.number = session8Number;
                                        ok_session_selection = false;
                                        break;
                                    default:
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("!!!!! There is no session associated with this number !!!!!");
                                        ok_session_selection = true;
                                        continue;
                                }
                            }

                            bool ok_number_of_tickets = true;
                            while (ok_number_of_tickets)
                            {
                                Console.ForegroundColor = ConsoleColor.Magenta;
                                Console.WriteLine("\nTotal number of available seats: " + (hall.capacity - occupied_seat_list[selected_session - 1]));
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.WriteLine("how many tickets do you want to buy");
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                Console.WriteLine("Type '0' to go back to session selection");
                                try
                                {
                                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                                    number_of_tickets = Convert.ToInt32(Console.ReadLine());
                                    if (number_of_tickets <= (hall.capacity - occupied_seat_list[selected_session - 1]))
                                    {
                                        number_of_tickets2 = number_of_tickets;
                                        ok_number_of_tickets = false;
                                    }
                                    else
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("There aren't that many empty seats");
                                        ok_number_of_tickets = true;
                                        continue;
                                    }

                                }
                                catch (Exception)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("!!!!! Please enter a number !!!!!");
                                    ok_number_of_tickets = true;
                                    continue;
                                }
                                // Returns back to number of tickets selection
                                if (number_of_tickets == 0)
                                {
                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                    Console.WriteLine("Returning to session selection");
                                    ok_number_of_tickets = false;
                                    ok_session_selection = true;
                                    break;
                                }
                                else
                                {
                                    ok_session_selection = false;
                                }

                                bool ok_seat_selection = true;
                                while (ok_seat_selection)
                                {
                                    switch (selected_session)
                                    {
                                        case 1:
                                            Hall.replace_seats1(seats1, seats1s);
                                            break;
                                        case 2:
                                            Hall.replace_seats2(seats2, seats2s);
                                            break;
                                        case 3:
                                            Hall.replace_seats3(seats3, seats3s);
                                            break;
                                        case 4:
                                            Hall.replace_seats4(seats4, seats4s);
                                            break;
                                        case 5:
                                            Hall.replace_seats5(seats5, seats5s);
                                            break;
                                        case 6:
                                            Hall.replace_seats6(seats6, seats6s);
                                            break;
                                        case 7:
                                            Hall.replace_seats7(seats7, seats7s);
                                            break;
                                        case 8:
                                            Hall.replace_seats8(seats8, seats8s);
                                            break;
                                    }

                                    // Prints the "SCREEN"
                                    Console.ForegroundColor = ConsoleColor.Magenta;
                                    for (int i = 0; i <= Hall.column * 1.8; i++)
                                    {
                                        Console.Write("--");
                                    }
                                    Console.Write("SCREEN");
                                    for (int i = 0; i <= Hall.column * 1.8; i++)
                                    {
                                        Console.Write("--");
                                    }
                                    Console.WriteLine();
                                    Console.ForegroundColor = ConsoleColor.Magenta;
                                    Console.WriteLine("\nTotal number of seats: " + hall.capacity);
                                    Console.ForegroundColor = ConsoleColor.Gray;

                                    switch (selected_session)
                                    {
                                        case 1:
                                            // Prints the seats of session1
                                            Console.WriteLine("Session 1\n");
                                            Hall.print_seats1(seats1);
                                            break;

                                        case 2:
                                            // Prints the seats of session2
                                            Console.WriteLine("Session 2\n");
                                            Hall.print_seats2(seats2);
                                            break;
                                        case 3:
                                            // Prints the seats of session3
                                            Console.WriteLine("Session 3\n");
                                            Hall.print_seats3(seats3);
                                            break;
                                        case 4:
                                            // Prints the seats of session4
                                            Console.WriteLine("Session 4\n");
                                            Hall.print_seats4(seats4);
                                            break;
                                        case 5:
                                            // Prints the seats of session5
                                            Console.WriteLine("Session 5\n");
                                            Hall.print_seats5(seats5);
                                            break;
                                        case 6:
                                            // Prints the seats of session6
                                            Console.WriteLine("Session 6\n");
                                            Hall.print_seats6(seats6);
                                            break;
                                        case 7:
                                            // Prints the seats of session7
                                            Console.WriteLine("Session 7\n");
                                            Hall.print_seats7(seats7);
                                            break;
                                        case 8:
                                            // Prints the seats of session8
                                            Console.WriteLine("Session 8\n");
                                            Hall.print_seats8(seats8);
                                            break;
                                    }

                                    taken_seats.Clear();

                                    string[] seat_number = new string[number_of_tickets];

                                    for (int i = 0; i < number_of_tickets; i++)
                                    {
                                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                                        Console.WriteLine("seat " + (i + 1));
                                        selected_seat = Console.ReadLine().ToLower();
                                        if (selected_seat == "0")
                                        {
                                            Console.WriteLine("Returning to number of tickets selection");
                                            ok_seat_selection = false;
                                            break;
                                        }
                                        if (seat_list[(selected_session - 1)].Contains(selected_seat))
                                        {
                                            Console.WriteLine();
                                        }

                                        else
                                        {
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.WriteLine("This seat is full or not exist");
                                            Console.WriteLine("Selected seats have been reset");
                                            taken_seats.Clear();
                                            i--;
                                            ok_seat_selection = true;
                                            continue;
                                        }
                                        switch (selected_session)
                                        {
                                            case 1:
                                                seat_number[i] = selected_seat;
                                                int line1 = seat_number[i][0] - 97;
                                                int col1 = seat_number[i][1] - 49;
                                                if (seats1[line1, col1] == "xx")
                                                {
                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                    Console.WriteLine("This seat is taken");
                                                    i--;
                                                    break;
                                                }
                                                else
                                                {
                                                    taken_seats.Add(seat_number[i]);
                                                    seats1[line1, col1] = "xx";
                                                }
                                                break;
                                            case 2:
                                                seat_number[i] = selected_seat;
                                                int line2 = seat_number[i][0] - 97;
                                                int col2 = seat_number[i][1] - 49;
                                                if (seats2[line2, col2] == "xx")
                                                {
                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                    Console.WriteLine("This seat is taken");
                                                    i--;
                                                    break;
                                                }
                                                else
                                                {
                                                    taken_seats.Add(seat_number[i]);
                                                    seats2[line2, col2] = "xx";
                                                }
                                                break;
                                            case 3:
                                                seat_number[i] = selected_seat;
                                                int line3 = seat_number[i][0] - 97;
                                                int col3 = seat_number[i][1] - 49;
                                                if (seats3[line3, col3] == "xx")
                                                {
                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                    Console.WriteLine("This seat is taken");
                                                    i--;
                                                    break;
                                                }
                                                else
                                                {
                                                    taken_seats.Add(seat_number[i]);
                                                    seats3[line3, col3] = "xx";
                                                }
                                                break;
                                            case 4:
                                                seat_number[i] = selected_seat;
                                                int line4 = seat_number[i][0] - 97;
                                                int col4 = seat_number[i][1] - 49;
                                                if (seats4[line4, col4] == "xx")
                                                {
                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                    Console.WriteLine("This seat is taken");
                                                    i--;
                                                    break;
                                                }
                                                else
                                                {
                                                    taken_seats.Add(seat_number[i]);
                                                    seats4[line4, col4] = "xx";
                                                }
                                                break;
                                            case 5:
                                                seat_number[i] = selected_seat;
                                                int line5 = seat_number[i][0] - 97;
                                                int col5 = seat_number[i][1] - 49;
                                                if (seats5[line5, col5] == "xx")
                                                {
                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                    Console.WriteLine("This seat is taken");
                                                    i--;
                                                    break;
                                                }
                                                else
                                                {
                                                    taken_seats.Add(seat_number[i]);
                                                    seats5[line5, col5] = "xx";
                                                }
                                                break;
                                            case 6:
                                                seat_number[i] = selected_seat;
                                                int line6 = seat_number[i][0] - 97;
                                                int col6 = seat_number[i][1] - 49;
                                                if (seats6[line6, col6] == "xx")
                                                {
                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                    Console.WriteLine("This seat is taken");
                                                    i--;
                                                    break;
                                                }
                                                else
                                                {
                                                    taken_seats.Add(seat_number[i]);
                                                    seats6[line6, col6] = "xx";
                                                }
                                                break;
                                            case 7:
                                                seat_number[i] = selected_seat;
                                                int line7 = seat_number[i][0] - 97;
                                                int col7 = seat_number[i][1] - 49;
                                                if (seats7[line7, col7] == "xx")
                                                {
                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                    Console.WriteLine("This seat is taken");
                                                    i--;
                                                    break;
                                                }
                                                else
                                                {
                                                    taken_seats.Add(seat_number[i]);
                                                    seats7[line7, col7] = "xx";
                                                }
                                                break;
                                            case 8:
                                                seat_number[i] = selected_seat;
                                                int line8 = seat_number[i][0] - 97;
                                                int col8 = seat_number[i][1] - 49;
                                                if (seats8[line8, col8] == "xx")
                                                {
                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                    Console.WriteLine("This seat is taken");
                                                    i--;
                                                    break;
                                                }
                                                else
                                                {
                                                    taken_seats.Add(seat_number[i]);
                                                    seats8[line8, col8] = "xx";
                                                }
                                                break;
                                        }

                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                        Console.WriteLine("Seat number: " + string.Join(", ", taken_seats));
                                        reservation.seat = string.Join(", ", taken_seats);
                                        if (i == (number_of_tickets - 1))
                                        {
                                            ok_seat_selection = false;
                                            break;
                                        }
                                    }
                                    // Returns back to number of tickets selection
                                    if (selected_seat == "0")
                                    {
                                        ok_seat_selection = false;
                                        ok_number_of_tickets = true;
                                        break;
                                    }
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.WriteLine("-----------------------------------------------------");
                                    Console.WriteLine("Full name: " + reservation.full_name);
                                    Console.WriteLine("Selected date: " + reservation.date.ToString("dd.MM.yyyy"));
                                    Console.WriteLine("Selected movie: \"" + reservation.movie.name + "\"");
                                    Console.WriteLine("Selected session: " + reservation.session.number);
                                    switch (reservation.session.number)
                                    {
                                        case 1:
                                            //Session 1
                                            Console.WriteLine("Time: " + session1Time.ToString(@"hh\:mm"));
                                            Console.WriteLine("Subtitle: " + session1Subtitle);
                                            Console.WriteLine("Hall number: " + session1Hall);
                                            Console.WriteLine("Seat number: " + string.Join(", ", taken_seats));
                                            Console.WriteLine("-----------------------------------------------------\n");
                                            break;
                                        case 2:
                                            //Session 2
                                            Console.WriteLine("Time: " + session2Time.ToString(@"hh\:mm"));
                                            Console.WriteLine("Subtitle: " + session2Subtitle);
                                            Console.WriteLine("Hall number: " + session2Hall);
                                            Console.WriteLine("Seat number: " + string.Join(", ", taken_seats));
                                            Console.WriteLine("-----------------------------------------------------\n");
                                            break;
                                        case 3:
                                            //Session 3
                                            Console.WriteLine("Time: " + session3Time.ToString(@"hh\:mm"));
                                            Console.WriteLine("Subtitle: " + session3Subtitle);
                                            Console.WriteLine("Hall number: " + session3Hall);
                                            Console.WriteLine("Seat number: " + string.Join(", ", taken_seats));
                                            Console.WriteLine("-----------------------------------------------------\n");
                                            break;
                                        case 4:
                                            //Session 4
                                            Console.WriteLine("Time: " + session4Time.ToString(@"hh\:mm"));
                                            Console.WriteLine("Subtitle: " + session4Subtitle);
                                            Console.WriteLine("Hall number: " + session4Hall);
                                            Console.WriteLine("Seat number: " + string.Join(", ", taken_seats));
                                            Console.WriteLine("-----------------------------------------------------\n");
                                            break;
                                        case 5:
                                            //Session 5
                                            Console.WriteLine("Time: " + session5Time.ToString(@"hh\:mm"));
                                            Console.WriteLine("Subtitle: " + session5Subtitle);
                                            Console.WriteLine("Hall number: " + session5Hall);
                                            Console.WriteLine("Seat number: " + string.Join(", ", taken_seats));
                                            Console.WriteLine("-----------------------------------------------------\n");
                                            break;
                                        case 6:
                                            //Session 6
                                            Console.WriteLine("Time: " + session6Time.ToString(@"hh\:mm"));
                                            Console.WriteLine("Subtitle: " + session6Subtitle);
                                            Console.WriteLine("Hall number: " + session6Hall);
                                            Console.WriteLine("Seat number: " + string.Join(", ", taken_seats));
                                            Console.WriteLine("-----------------------------------------------------\n");
                                            break;
                                        case 7:
                                            //Session 7
                                            Console.WriteLine("Time: " + session7Time.ToString(@"hh\:mm"));
                                            Console.WriteLine("Subtitle: " + session7Subtitle);
                                            Console.WriteLine("Hall number: " + session7Hall);
                                            Console.WriteLine("Seat number: " + string.Join(", ", taken_seats));
                                            Console.WriteLine("-----------------------------------------------------\n");
                                            break;
                                        case 8:
                                            //Session 8
                                            Console.WriteLine("Time: " + session8Time.ToString(@"hh\:mm"));
                                            Console.WriteLine("Subtitle: " + session8Subtitle);
                                            Console.WriteLine("Hall number: " + session8Hall);
                                            Console.WriteLine("Seat number: " + string.Join(", ", taken_seats));
                                            Console.WriteLine("-----------------------------------------------------\n");
                                            break;
                                    }
                                    bool ok_payment_selection = true;
                                    while (ok_payment_selection)
                                    {
                                        try
                                        {
                                            Console.ForegroundColor = ConsoleColor.Cyan;
                                            Console.WriteLine("Which payment method do you want to pay with?");
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Console.WriteLine("1) Cash\n2) Credit card");
                                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                                            Console.WriteLine("Type '0' to go to seat selection");
                                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                                            int payment = Convert.ToInt32(Console.ReadLine());
                                            if (payment == 0)
                                            {
                                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                Console.WriteLine("Returning to seat selection");
                                                ok_payment_selection = false;
                                                ok_seat_selection = true;
                                                break;
                                            }
                                            else if (payment == 1)
                                            {
                                                reservation.payment_method = "Cash";  
                                            }
                                            else if (payment == 2)
                                            {
                                                reservation.payment_method = "Credit Card";
                                            }
                                            else
                                            {
                                                Console.ForegroundColor = ConsoleColor.Red;
                                                Console.WriteLine("!!!!! Enter the number associated with the method !!!!!");
                                                ok_payment_selection = true;
                                                continue;
                                            }
                                        }
                                        catch (Exception)
                                        {
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.WriteLine("!!!!! Enter a number !!!!!");
                                            ok_payment_selection = true;
                                            continue;
                                        }

                                        bool ok_confirmation = true;
                                        while (ok_confirmation)
                                        {
                                            try
                                            {
                                                Console.WriteLine("Selected payment method: " + reservation.payment_method);
                                                Console.ForegroundColor = ConsoleColor.Cyan;
                                                Console.WriteLine("Type 1 to confirm your payment");
                                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                Console.WriteLine("Type '0' to go to payment selection");
                                                Console.ForegroundColor = ConsoleColor.DarkCyan;
                                                confirmation = Convert.ToInt32(Console.ReadLine());
                                                if (confirmation == 0)
                                                {

                                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                    Console.WriteLine("program is shutting down");
                                                    ok_confirmation = false;
                                                    ok_payment_selection = true;
                                                    break;
                                                }

                                                else if (confirmation == 1)
                                                {
                                                    Console.ForegroundColor = ConsoleColor.Green;
                                                    Console.WriteLine("Your ticket has been confirmed have a good watching");
                                                    Environment.Exit(0);
                                                }
                                                else
                                                {
                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                    Console.WriteLine("!!!!! There is no function associated with this number !!!!!");
                                                    ok_confirmation = true;
                                                    continue;
                                                }
                                            }
                                            catch (Exception)
                                            {
                                                Console.ForegroundColor = ConsoleColor.Red;
                                                Console.WriteLine("!!!!! Enter the number associated with the function !!!!!");
                                                ok_confirmation = true;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
