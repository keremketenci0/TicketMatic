using TicketMatic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TicketMatic
{
    class Hall
    {
        public static int row = 6; // Determines how many rows of cinema seats
        public static int column = 9; // Determines how many coulums of cinema seats
        public static int minrow = 4; // Determines the number of seats in the first row
        public int number { get; set; }
        public string seat_number { get; set; }
        public int capacity { get; set; }

        public int generate_hall1()
        {
            //Generates the hall1
            this.number = 1;
            return this.number;
        }
        public int generate_hall2()
        {
            //Generates the hall1
            this.number = 2;
            return this.number;
        }
        public int generate_hall3()
        {
            //Generates the hall1
            this.number = 3;
            return this.number;
        }
        public int generate_hall4()
        {
            //Generates the hall1
            this.number = 4;
            return this.number;
        }

        public static (string[,], string[,], List<string>, int) gerenate_seats1()
        {
            //  creates a 2D array for the seats of the movie hall
            string[,] seats1 = new string[row, column];
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < minrow + i; j++)
                {
                    seats1[i, j] = (char)(i + 97) + (j + 1).ToString();
                }
            }
            Random random = new Random(Guid.NewGuid().GetHashCode());
            // determines the maximum number of occupied seats that can be
            int full_seat1 = random.Next(1, (row * (2 * minrow + row - 1) / 2) - 2); //with at least one seat left vacant
            // Marks the full_seat as "xx"
            for (int i = 0; i < full_seat1; i++)
            {
                int line = random.Next(0, row);
                int col = random.Next(0, minrow + line);
                //Console.WriteLine($"{line} {col}"); 
                seats1[line, col] = "xx";
            }
            string[,] seats1s = new string[seats1.GetLength(0), seats1.GetLength(1)]; // seats1s dizisi seats1 dizisiyle aynı boyutta oluşturulur
            for (int i = 0; i < seats1.GetLength(0); i++)
            {
                for (int j = 0; j < seats1.GetLength(1); j++)
                {
                    seats1s[i, j] = seats1[i, j]; // seats1 dizisindeki elemanlar seats1s dizisine kopyalanır
                }
            }
            List<string> seatList1 = new List<string>();
            for (int i = 0; i < seats1.GetLength(0); i++)
            {
                for (int j = 0; j < seats1.GetLength(1); j++)
                {
                    seatList1.Add(seats1[i, j]); // Add each element of seats1 to seatList1
                }
            }
            int occupied_seats1 = 0;
            foreach (string seat in seatList1)
            {
                if (seat == "xx")
                {
                    occupied_seats1++;
                }
            }
            return (seats1, seats1s, seatList1, occupied_seats1);
        }
        public static void printSeats1(string[,] seats1)
        {
            // Prints the seats
            Console.ForegroundColor = ConsoleColor.White;
            for (int i = 0; i < row; i++)
            {
                // Adds "-" characters per line
                for (int j = 0; j < row - i - 1; j++)
                {
                    Console.Write("----");
                }

                // Prints the seats for the left half of the row
                for (int j = 0; j < minrow + i / 2; j++)
                {
                    Console.Write(seats1[i, j] + "\t");
                }

                // Prints the seats for the right half of the row
                for (int j = minrow + i / 2; j < minrow + i; j++)
                {
                    Console.Write(seats1[i, j] + "\t");
                }

                // Adds "-" characters for the remaining seats in the row
                for (int j = 0; j < row - i - 1; j++)
                {
                    Console.Write("----");
                }
                Console.WriteLine();
            }
        }
        public static string[,] replace_seats1(string[,] seats1, string[,] seats1s)
        {
            for (int i = 0; i < seats1s.GetLength(0); i++)
            {
                for (int j = 0; j < seats1s.GetLength(1); j++)
                {
                    seats1[i, j] = seats1s[i, j]; // seats1s dizisindeki elemanlar seats1 dizisine kopyalanır
                }
            }
            return seats1s;
        }
        
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        
        public static (string[,], string[,], List<string>, int) gerenate_seats2()
        {
            //  creates a 2D array for the seats of the movie hall
            string[,] seats2 = new string[row, column];
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < minrow + i; j++)
                {
                    seats2[i, j] = (char)(i + 97) + (j + 1).ToString();
                }
            }
            Random random = new Random(Guid.NewGuid().GetHashCode());
            // determines the maximum number of occupied seats that can be
            int full_seat2 = random.Next(1, (row * (2 * minrow + row - 1) / 2) - 2); //with at least one seat left vacant
            // Marks the full_seat as "xx"
            for (int i = 0; i < full_seat2; i++)
            {
                int line = random.Next(0, row);
                int col = random.Next(0, minrow + line);
                //Console.WriteLine($"{line} {col}"); 
                seats2[line, col] = "xx";
            }
            string[,] seats2s = new string[seats2.GetLength(0), seats2.GetLength(1)]; // seats1s dizisi seats1 dizisiyle aynı boyutta oluşturulur
            for (int i = 0; i < seats2.GetLength(0); i++)
            {
                for (int j = 0; j < seats2.GetLength(1); j++)
                {
                    seats2s[i, j] = seats2[i, j]; // seats1 dizisindeki elemanlar seats1s dizisine kopyalanır
                }
            }
            List<string> seatList2 = new List<string>();
            for (int i = 0; i < seats2.GetLength(0); i++)
            {
                for (int j = 0; j < seats2.GetLength(1); j++)
                {
                    seatList2.Add(seats2[i, j]); // Add each element of seats1 to seatList1
                }
            }
            int occupied_seats2 = 0;
            foreach (string seat in seatList2)
            {
                if (seat == "xx")
                {
                    occupied_seats2++;
                }
            }
            return (seats2, seats2s, seatList2, occupied_seats2);
        }
        public static void printSeats2(string[,] seats2)
        {
            // Prints the seats
            Console.ForegroundColor = ConsoleColor.White;
            for (int i = 0; i < row; i++)
            {
                // Adds "-" characters per line
                for (int j = 0; j < row - i - 1; j++)
                {
                    Console.Write("----");
                }

                // Prints the seats for the left half of the row
                for (int j = 0; j < minrow + i / 2; j++)
                {
                    Console.Write(seats2[i, j] + "\t");
                }

                // Prints the seats for the right half of the row
                for (int j = minrow + i / 2; j < minrow + i; j++)
                {
                    Console.Write(seats2[i, j] + "\t");
                }

                // Adds "-" characters for the remaining seats in the row
                for (int j = 0; j < row - i - 1; j++)
                {
                    Console.Write("----");
                }
                Console.WriteLine();
            }
        }
        public static string[,] replace_seats2(string[,] seats2, string[,] seats2s)
        {
            for (int i = 0; i < seats2s.GetLength(0); i++)
            {
                for (int j = 0; j < seats2s.GetLength(1); j++)
                {
                    seats2[i, j] = seats2s[i, j]; // seats1s dizisindeki elemanlar seats1 dizisine kopyalanır
                }
            }
            return seats2s;
        }
        
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////        
        
        public static (string[,], string[,], List<string>, int) gerenate_seats3()
        {
            //  creates a 2D array for the seats of the movie hall
            string[,] seats3 = new string[row, column];
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < minrow + i; j++)
                {
                    seats3[i, j] = (char)(i + 97) + (j + 1).ToString();
                }
            }
            Random random = new Random(Guid.NewGuid().GetHashCode());
            // determines the maximum number of occupied seats that can be
            int full_seat3 = random.Next(1, (row * (2 * minrow + row - 1) / 2) - 2); //with at least one seat left vacant
            // Marks the full_seat as "xx"
            for (int i = 0; i < full_seat3; i++)
            {
                int line = random.Next(0, row);
                int col = random.Next(0, minrow + line);
                //Console.WriteLine($"{line} {col}"); 
                seats3[line, col] = "xx";
            }
            string[,] seats3s = new string[seats3.GetLength(0), seats3.GetLength(1)]; // seats1s dizisi seats1 dizisiyle aynı boyutta oluşturulur
            for (int i = 0; i < seats3.GetLength(0); i++)
            {
                for (int j = 0; j < seats3.GetLength(1); j++)
                {
                    seats3s[i, j] = seats3[i, j]; // seats1 dizisindeki elemanlar seats1s dizisine kopyalanır
                }
            }
            List<string> seatList3 = new List<string>();
            for (int i = 0; i < seats3.GetLength(0); i++)
            {
                for (int j = 0; j < seats3.GetLength(1); j++)
                {
                    seatList3.Add(seats3[i, j]); // Add each element of seats1 to seatList1
                }
            }

            int occupied_seats3 = 0;
            foreach (string seat in seatList3)
            {
                if (seat == "xx")
                {
                    occupied_seats3++;
                }
            }
            return (seats3, seats3s, seatList3, occupied_seats3);
        }
        public static void printSeats3(string[,] seats3)
        {
            // Prints the seats
            Console.ForegroundColor = ConsoleColor.White;
            for (int i = 0; i < row; i++)
            {
                // Adds "-" characters per line
                for (int j = 0; j < row - i - 1; j++)
                {
                    Console.Write("----");
                }

                // Prints the seats for the left half of the row
                for (int j = 0; j < minrow + i / 2; j++)
                {
                    Console.Write(seats3[i, j] + "\t");
                }

                // Prints the seats for the right half of the row
                for (int j = minrow + i / 2; j < minrow + i; j++)
                {
                    Console.Write(seats3[i, j] + "\t");
                }

                // Adds "-" characters for the remaining seats in the row
                for (int j = 0; j < row - i - 1; j++)
                {
                    Console.Write("----");
                }
                Console.WriteLine();
            }
        }
        public static string[,] replace_seats3(string[,] seats3, string[,] seats3s)
        {
            for (int i = 0; i < seats3s.GetLength(0); i++)
            {
                for (int j = 0; j < seats3s.GetLength(1); j++)
                {
                    seats3[i, j] = seats3s[i, j]; // seats1s dizisindeki elemanlar seats1 dizisine kopyalanır
                }
            }
            return seats3s;
        }
        
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        
        public static (string[,], string[,], List<string>, int) gerenate_seats4()
        {
            //  creates a 2D array for the seats of the movie hall
            string[,] seats4 = new string[row, column];
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < minrow + i; j++)
                {
                    seats4[i, j] = (char)(i + 97) + (j + 1).ToString();
                }
            }
            Random random = new Random(Guid.NewGuid().GetHashCode());
            // determines the maximum number of occupied seats that can be
            int full_seat4 = random.Next(1, (row * (2 * minrow + row - 1) / 2) - 2); //with at least one seat left vacant
            // Marks the full_seat as "xx"
            for (int i = 0; i < full_seat4; i++)
            {
                int line = random.Next(0, row);
                int col = random.Next(0, minrow + line);
                //Console.WriteLine($"{line} {col}"); 
                seats4[line, col] = "xx";
            }
            string[,] seats4s = new string[seats4.GetLength(0), seats4.GetLength(1)]; // seats1s dizisi seats1 dizisiyle aynı boyutta oluşturulur
            for (int i = 0; i < seats4.GetLength(0); i++)
            {
                for (int j = 0; j < seats4.GetLength(1); j++)
                {
                    seats4s[i, j] = seats4[i, j]; // seats1 dizisindeki elemanlar seats1s dizisine kopyalanır
                }
            }
            List<string> seatList4 = new List<string>();
            for (int i = 0; i < seats4.GetLength(0); i++)
            {
                for (int j = 0; j < seats4.GetLength(1); j++)
                {
                    seatList4.Add(seats4[i, j]); // Add each element of seats1 to seatList1
                }
            }

            int occupied_seats4 = 0;
            foreach (string seat in seatList4)
            {
                if (seat == "xx")
                {
                    occupied_seats4++;
                }
            }
            return (seats4, seats4s, seatList4, occupied_seats4);
        }
        public static void printSeats4(string[,] seats4)
        {
            // Prints the seats
            Console.ForegroundColor = ConsoleColor.White;
            for (int i = 0; i < row; i++)
            {
                // Adds "-" characters per line
                for (int j = 0; j < row - i - 1; j++)
                {
                    Console.Write("----");
                }

                // Prints the seats for the left half of the row
                for (int j = 0; j < minrow + i / 2; j++)
                {
                    Console.Write(seats4[i, j] + "\t");
                }

                // Prints the seats for the right half of the row
                for (int j = minrow + i / 2; j < minrow + i; j++)
                {
                    Console.Write(seats4[i, j] + "\t");
                }

                // Adds "-" characters for the remaining seats in the row
                for (int j = 0; j < row - i - 1; j++)
                {
                    Console.Write("----");
                }
                Console.WriteLine();
            }
        }
        public static string[,] replace_seats4(string[,] seats4, string[,] seats4s)
        {
            for (int i = 0; i < seats4s.GetLength(0); i++)
            {
                for (int j = 0; j < seats4s.GetLength(1); j++)
                {
                    seats4[i, j] = seats4s[i, j]; // seats1s dizisindeki elemanlar seats1 dizisine kopyalanır
                }
            }
            return seats4s;
        }
        
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        
        public static (string[,], string[,], List<string>, int) gerenate_seats5()
        {
            //  creates a 2D array for the seats of the movie hall
            string[,] seats5 = new string[row, column];
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < minrow + i; j++)
                {
                    seats5[i, j] = (char)(i + 97) + (j + 1).ToString();
                }
            }
            Random random = new Random(Guid.NewGuid().GetHashCode());
            // determines the maximum number of occupied seats that can be
            int full_seat5 = random.Next(1, (row * (2 * minrow + row - 1) / 2) - 2); //with at least one seat left vacant
            // Marks the full_seat as "xx"
            for (int i = 0; i < full_seat5; i++)
            {
                int line = random.Next(0, row);
                int col = random.Next(0, minrow + line);
                //Console.WriteLine($"{line} {col}"); 
                seats5[line, col] = "xx";
            }
            string[,] seats5s = new string[seats5.GetLength(0), seats5.GetLength(1)]; // seats1s dizisi seats1 dizisiyle aynı boyutta oluşturulur
            for (int i = 0; i < seats5.GetLength(0); i++)
            {
                for (int j = 0; j < seats5.GetLength(1); j++)
                {
                    seats5s[i, j] = seats5[i, j]; // seats1 dizisindeki elemanlar seats1s dizisine kopyalanır
                }
            }
            List<string> seatList5 = new List<string>();
            for (int i = 0; i < seats5.GetLength(0); i++)
            {
                for (int j = 0; j < seats5.GetLength(1); j++)
                {
                    seatList5.Add(seats5[i, j]); // Add each element of seats1 to seatList1
                }
            }

            int occupied_seats5 = 0;
            foreach (string seat in seatList5)
            {
                if (seat == "xx")
                {
                    occupied_seats5++;
                }
            }
            return (seats5, seats5s, seatList5, occupied_seats5);
        }
        public static void printSeats5(string[,] seats5)
        {
            // Prints the seats
            Console.ForegroundColor = ConsoleColor.White;
            for (int i = 0; i < row; i++)
            {
                // Adds "-" characters per line
                for (int j = 0; j < row - i - 1; j++)
                {
                    Console.Write("----");
                }

                // Prints the seats for the left half of the row
                for (int j = 0; j < minrow + i / 2; j++)
                {
                    Console.Write(seats5[i, j] + "\t");
                }

                // Prints the seats for the right half of the row
                for (int j = minrow + i / 2; j < minrow + i; j++)
                {
                    Console.Write(seats5[i, j] + "\t");
                }

                // Adds "-" characters for the remaining seats in the row
                for (int j = 0; j < row - i - 1; j++)
                {
                    Console.Write("----");
                }
                Console.WriteLine();
            }
        }
        public static string[,] replace_seats5(string[,] seats5, string[,] seats5s)
        {
            for (int i = 0; i < seats5s.GetLength(0); i++)
            {
                for (int j = 0; j < seats5s.GetLength(1); j++)
                {
                    seats5[i, j] = seats5s[i, j]; // seats1s dizisindeki elemanlar seats1 dizisine kopyalanır
                }
            }
            return seats5s;
        }
        
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        
        public static (string[,], string[,], List<string>, int) gerenate_seats6()
        {
            //  creates a 2D array for the seats of the movie hall
            string[,] seats6 = new string[row, column];
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < minrow + i; j++)
                {
                    seats6[i, j] = (char)(i + 97) + (j + 1).ToString();
                }
            }
            Random random = new Random(Guid.NewGuid().GetHashCode());
            // determines the maximum number of occupied seats that can be
            int full_seat6 = random.Next(1, (row * (2 * minrow + row - 1) / 2) - 2); //with at least one seat left vacant
            // Marks the full_seat as "xx"
            for (int i = 0; i < full_seat6; i++)
            {
                int line = random.Next(0, row);
                int col = random.Next(0, minrow + line);
                //Console.WriteLine($"{line} {col}"); 
                seats6[line, col] = "xx";
            }
            string[,] seats6s = new string[seats6.GetLength(0), seats6.GetLength(1)]; // seats1s dizisi seats1 dizisiyle aynı boyutta oluşturulur
            for (int i = 0; i < seats6.GetLength(0); i++)
            {
                for (int j = 0; j < seats6.GetLength(1); j++)
                {
                    seats6s[i, j] = seats6[i, j]; // seats1 dizisindeki elemanlar seats1s dizisine kopyalanır
                }
            }
            List<string> seatList6 = new List<string>();
            for (int i = 0; i < seats6.GetLength(0); i++)
            {
                for (int j = 0; j < seats6.GetLength(1); j++)
                {
                    seatList6.Add(seats6[i, j]); // Add each element of seats1 to seatList1
                }
            }
            int occupied_seats6 = 0;
            foreach (string seat in seatList6)
            {
                if (seat == "xx")
                {
                    occupied_seats6++;
                }
            }
            return (seats6, seats6s, seatList6, occupied_seats6);
        }
        public static void printSeats6(string[,] seats6)
        {
            // Prints the seats
            Console.ForegroundColor = ConsoleColor.White;
            for (int i = 0; i < row; i++)
            {
                // Adds "-" characters per line
                for (int j = 0; j < row - i - 1; j++)
                {
                    Console.Write("----");
                }

                // Prints the seats for the left half of the row
                for (int j = 0; j < minrow + i / 2; j++)
                {
                    Console.Write(seats6[i, j] + "\t");
                }

                // Prints the seats for the right half of the row
                for (int j = minrow + i / 2; j < minrow + i; j++)
                {
                    Console.Write(seats6[i, j] + "\t");
                }

                // Adds "-" characters for the remaining seats in the row
                for (int j = 0; j < row - i - 1; j++)
                {
                    Console.Write("----");
                }
                Console.WriteLine();
            }
        }
        public static string[,] replace_seats6(string[,] seats6, string[,] seats6s)
        {
            for (int i = 0; i < seats6s.GetLength(0); i++)
            {
                for (int j = 0; j < seats6s.GetLength(1); j++)
                {
                    seats6[i, j] = seats6s[i, j]; // seats1s dizisindeki elemanlar seats1 dizisine kopyalanır
                }
            }
            return seats6s;
        }
        
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        
        public static (string[,], string[,], List<string>, int) gerenate_seats7()
        {
            //  creates a 2D array for the seats of the movie hall
            string[,] seats7 = new string[row, column];
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < minrow + i; j++)
                {
                    seats7[i, j] = (char)(i + 97) + (j + 1).ToString();
                }
            }
            Random random = new Random(Guid.NewGuid().GetHashCode());
            // determines the maximum number of occupied seats that can be
            int full_seat7 = random.Next(1, (row * (2 * minrow + row - 1) / 2) - 2); //with at least one seat left vacant
            // Marks the full_seat as "xx"
            for (int i = 0; i < full_seat7; i++)
            {
                int line = random.Next(0, row);
                int col = random.Next(0, minrow + line);
                //Console.WriteLine($"{line} {col}"); 
                seats7[line, col] = "xx";
            }
            string[,] seats7s = new string[seats7.GetLength(0), seats7.GetLength(1)]; // seats1s dizisi seats1 dizisiyle aynı boyutta oluşturulur
            for (int i = 0; i < seats7.GetLength(0); i++)
            {
                for (int j = 0; j < seats7.GetLength(1); j++)
                {
                    seats7s[i, j] = seats7[i, j]; // seats1 dizisindeki elemanlar seats1s dizisine kopyalanır
                }
            }
            List<string> seatList7 = new List<string>();
            for (int i = 0; i < seats7.GetLength(0); i++)
            {
                for (int j = 0; j < seats7.GetLength(1); j++)
                {
                    seatList7.Add(seats7[i, j]); // Add each element of seats1 to seatList1
                }
            }
            int occupied_seats7 = 0;
            foreach (string seat in seatList7)
            {
                if (seat == "xx")
                {
                    occupied_seats7++;
                }
            }
            return (seats7, seats7s, seatList7, occupied_seats7);
        }
        public static void printSeats7(string[,] seats7)
        {
            // Prints the seats
            Console.ForegroundColor = ConsoleColor.White;
            for (int i = 0; i < row; i++)
            {
                // Adds "-" characters per line
                for (int j = 0; j < row - i - 1; j++)
                {
                    Console.Write("----");
                }

                // Prints the seats for the left half of the row
                for (int j = 0; j < minrow + i / 2; j++)
                {
                    Console.Write(seats7[i, j] + "\t");
                }

                // Prints the seats for the right half of the row
                for (int j = minrow + i / 2; j < minrow + i; j++)
                {
                    Console.Write(seats7[i, j] + "\t");
                }

                // Adds "-" characters for the remaining seats in the row
                for (int j = 0; j < row - i - 1; j++)
                {
                    Console.Write("----");
                }
                Console.WriteLine();
            }
        }
        public static string[,] replace_seats7(string[,] seats7, string[,] seats7s)
        {
            for (int i = 0; i < seats7s.GetLength(0); i++)
            {
                for (int j = 0; j < seats7s.GetLength(1); j++)
                {
                    seats7[i, j] = seats7s[i, j]; // seats1s dizisindeki elemanlar seats1 dizisine kopyalanır
                }
            }
            return seats7s;
        }
        
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        
        public static (string[,], string[,], List<string>, int) gerenate_seats8()
        {
            //  creates a 2D array for the seats of the movie hall
            string[,] seats8 = new string[row, column];
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < minrow + i; j++)
                {
                    seats8[i, j] = (char)(i + 97) + (j + 1).ToString();
                }
            }
            Random random = new Random(Guid.NewGuid().GetHashCode());
            // determines the maximum number of occupied seats that can be
            int full_seat8 = random.Next(1, (row * (2 * minrow + row - 1) / 2) - 2); //with at least one seat left vacant
            // Marks the full_seat as "xx"
            for (int i = 0; i < full_seat8; i++)
            {
                int line = random.Next(0, row);
                int col = random.Next(0, minrow + line);
                //Console.WriteLine($"{line} {col}"); 
                seats8[line, col] = "xx";
            }
            string[,] seats8s = new string[seats8.GetLength(0), seats8.GetLength(1)]; // seats1s dizisi seats1 dizisiyle aynı boyutta oluşturulur
            for (int i = 0; i < seats8.GetLength(0); i++)
            {
                for (int j = 0; j < seats8.GetLength(1); j++)
                {
                    seats8s[i, j] = seats8[i, j]; // seats1 dizisindeki elemanlar seats1s dizisine kopyalanır
                }
            }
            List<string> seatList8 = new List<string>();
            for (int i = 0; i < seats8.GetLength(0); i++)
            {
                for (int j = 0; j < seats8.GetLength(1); j++)
                {
                    seatList8.Add(seats8[i, j]); // Add each element of seats1 to seatList1
                }
            }

            int occupied_seats8 = 0;
            foreach (string seat in seatList8)
            {
                if (seat == "xx")
                {
                    occupied_seats8++;
                }
            }
            return (seats8, seats8s, seatList8, occupied_seats8);
        }
        public static void printSeats8(string[,] seats8)
        {
            // Prints the seats
            Console.ForegroundColor = ConsoleColor.White;
            for (int i = 0; i < row; i++)
            {
                // Adds "-" characters per line
                for (int j = 0; j < row - i - 1; j++)
                {
                    Console.Write("----");
                }

                // Prints the seats for the left half of the row
                for (int j = 0; j < minrow + i / 2; j++)
                {
                    Console.Write(seats8[i, j] + "\t");
                }

                // Prints the seats for the right half of the row
                for (int j = minrow + i / 2; j < minrow + i; j++)
                {
                    Console.Write(seats8[i, j] + "\t");
                }

                // Adds "-" characters for the remaining seats in the row
                for (int j = 0; j < row - i - 1; j++)
                {
                    Console.Write("----");
                }
                Console.WriteLine();
            }
        }
        public static string[,] replace_seats8(string[,] seats8, string[,] seats8s)
        {
            for (int i = 0; i < seats8s.GetLength(0); i++)
            {
                for (int j = 0; j < seats8s.GetLength(1); j++)
                {
                    seats8[i, j] = seats8s[i, j]; // seats1s dizisindeki elemanlar seats1 dizisine kopyalanır
                }
            }
            return seats8s;
        }
    }
}

