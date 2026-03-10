using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Timers;

class Program
{
    static string connectionString =
    "Server=tcp:localhost,1433; Database=biograf; User Id=Odense; Password=Password1!; Encrypt=True; TrustServerCertificate=True;";

    static void Main()
    {
        bool menu = true;

        while (menu)
        {
            Console.WriteLine("---- MENU ----");
            Console.WriteLine("1 - Vis Butikker");
            Console.WriteLine("2 - Vis Film");
            Console.WriteLine("3 - Vis Lager");
            Console.WriteLine("4 - Vis Medarbejder");
            Console.WriteLine("5 - Vis Orders");
            Console.WriteLine("6 - Vis Adresse");
            Console.WriteLine("7 - Vis Kunder");
            Console.WriteLine("8 - Stored Procedurece");
            Console.WriteLine("0 - Afslut");
            Console.Write("Vælg: ");

            string valg = Console.ReadLine();

            switch (valg)
            {

                case "1":
                    VisButiker();
                    break;

                case "2":
                    VisFilm();
                    break;

                case "3":
                    VisLager();
                    break;

                case "4":
                    VisMedarbejder();
                    break;

                case "5":
                    VisOrders();
                    break;

                case "6":
                    VisAdresse();
                    break;

                case "7":
                    VisKunder();
                    break;

                case "8":
                    visMenu2();
                    menu = false;
                    break;

                case "0":
                    menu = false;
                    break;

                default:
                    Console.WriteLine("Ugyldig valg");
                    break;


            }

            //Viser Butik Table
            static void VisButiker()
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string query = "SELECT * FROM Butik";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {

                        Console.WriteLine("butikID - adresse - postNummer");
                        while (reader.Read())
                        {
                            int butikID = reader.GetInt32(0);
                            string adresse = reader.GetString(1);
                            int postNummer = reader.GetInt32(2);

                            Console.WriteLine($"{butikID} - {adresse} - {postNummer}");
                        }
                    }
                    Console.WriteLine("Tryk 'Enter' at forsætte...");
                    Console.ReadLine();
                    Console.WriteLine("\n");
                }
            }

            // Viser film Table
            static void VisFilm()
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string query = "SELECT * FROM Film";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        Console.WriteLine("Flim_ID - Film_navn - Film_Pris - Film_datetime");
                        while (reader.Read())
                        {
                            int Flim_ID = reader.GetInt32(0);
                            string Film_navn = reader.GetString(1);
                            int Film_Pris = reader.GetInt32(2);
                            DateTime Film_datetime = reader.GetDateTime(3);

                            Console.WriteLine($"{Flim_ID} - {Film_navn} - {Film_Pris} - {Film_datetime}");
                        }
                    }
                    Console.WriteLine("Tryk 'Enter' at forsætte...");
                    Console.ReadLine();
                    Console.WriteLine("\n");
                }
            }

            // Viser Lager Table
            static void VisLager()
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string query = "SELECT * FROM Lager";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        Console.WriteLine("LagerID - ButikId - Film_ID - Film_navn");
                        while (reader.Read())
                        {
                            int LagerID = reader.GetInt32(0);
                            int ButikId = reader.GetInt32(1);
                            int Film_ID = reader.GetInt32(2);
                            string Film_navn = reader.GetString(3);

                            Console.WriteLine($"{LagerID} - {ButikId} - {Film_ID} - {Film_navn}");

                        }
                    }
                    Console.WriteLine("Tryk 'Enter' at forsætte...");
                    Console.ReadLine();
                    Console.WriteLine("\n");
                }
            }

            // Viser Medarbejder Table
            static void VisMedarbejder()
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string query = "SELECT * FROM Medarbejder";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {

                        Console.WriteLine("MedarbejderID - ButikID - (ForNavn, Efternavn) - Adresse - Post_nummer");
                        while (reader.Read())
                        {
                            int MedarbejderID = reader.GetInt32(0);
                            int ButikID = reader.GetInt32(1);
                            string ForNavn = reader.GetString(2);
                            string Efternavn = reader.GetString(3);
                            string Adresse = reader.GetString(4);
                            int Post_nummer = reader.GetInt32(5);

                            Console.WriteLine($"{MedarbejderID} - {ButikID} - ({ForNavn}, {Efternavn}) - {Adresse} - {Post_nummer}");

                        }
                    }
                    Console.WriteLine("Tryk 'Enter' at forsætte...");
                    Console.ReadLine();
                    Console.WriteLine("\n");
                }
            }

            // Viser Orders Table
            static void VisOrders()
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string query = "SELECT * FROM Orders";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        Console.WriteLine("Order_ID - KundeID - Butik_Id - Antal_billeddeter - Film_ID - Film_navn - Mail");
                        while (reader.Read())
                        {
                            int Order_ID = reader.GetInt32(0);
                            int KundeID = reader.GetInt32(1);
                            int ButikId = reader.GetInt32(2);
                            int Antal_billedeter = reader.GetInt32(3);
                            int Film_ID = reader.GetInt32(4);
                            string Film_navn = reader.GetString(5);
                            string Mail = reader.GetString(5);


                            Console.WriteLine($"{Order_ID} - {KundeID} - {ButikId} - {Antal_billedeter} - {Film_ID} - {Film_navn} - {Mail}");
                        }
                    }
                    Console.WriteLine("Tryk 'Enter' at forsætte...");
                    Console.ReadLine();
                    Console.WriteLine("\n");
                }
            }


            // Viser Adresse Table
            static void VisAdresse()
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string query = "SELECT * FROM Kunder.Adresse";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        Console.WriteLine("Post Nummer - Bynavn");
                        while (reader.Read())
                        {
                            int Post_Nummer = reader.GetInt32(0);
                            string bynavn = reader.GetString(1);


                            Console.WriteLine($"{Post_Nummer} - {bynavn}");
                        }
                    }
                    Console.WriteLine("Tryk 'Enter' at forsætte...");
                    Console.ReadLine();
                    Console.WriteLine("\n");
                }
            }

            // Viser Kunder Table
            static void VisKunder()
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string query = "SELECT * FROM Kunder.Kunder";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        Console.WriteLine("Kunde_ID - (Fornavn, Efternavn) - Mail - Adresse - Post_Nummer");
                        while (reader.Read())
                        {
                            int Kunde_ID = reader.GetInt32(0);
                            string Fornavn = reader.GetString(1);
                            string Efternavn = reader.GetString(2);
                            string Mail = reader.GetString(3);
                            string Adresse = reader.GetString(4);
                            int Post_Nummer = reader.GetInt32(5);


                            Console.WriteLine($"{Kunde_ID} - ({Fornavn}, {Efternavn}) - {Mail} - {Adresse} - {Post_Nummer}");
                        }
                    }
                    Console.WriteLine("Tryk 'Enter' at forsætte...");
                    Console.ReadLine();
                    Console.WriteLine("\n");
                }
            }

            //Viser Stored Procedures...
            static void visMenu2()
            {
                Console.Clear();
                bool menu2 = true;

                while (menu2)
                {
                    Console.WriteLine("---- MENU ----");
                    Console.WriteLine("1 - Film data Overall");
                    Console.WriteLine("2 - kunder by");
                    Console.WriteLine("0 - Afslut");


                    string valg2 = Console.ReadLine();

                    switch (valg2)
                    {

                        case "1":
                            visspfilmdataoverall();
                            break;

                        case "2":
                            visspkunderby();
                            break;

                        case "0":
                            menu2 = false;
                            break;


                        default:
                            Console.WriteLine("Ugyldig valg");
                            break;


                    }
                }
            }

            // Viser visspfilmdataoverall Stored Procedure
            static void visspfilmdataoverall()
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string query = "dbo.spFilmdataTotalOverall"; 

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            Console.WriteLine("GrandTotal - Total Billederter - Film ID - Film navn");

                            while (reader.Read())
                            {
                                int GrandTotal = reader.GetInt32(0);
                                int Total_Billederter = reader.GetInt32(1);
                                int film_ID = reader.GetInt32(2);
                                string Film_navn = reader.GetString(3);
                                

                                Console.WriteLine($"{GrandTotal} - {Total_Billederter} - {film_ID} - {Film_navn}");
                            }
                        }
                    }

                    Console.WriteLine("Tryk 'Enter' at forsætte...");
                    Console.ReadLine();
                    Console.WriteLine("\n");
                }
            }

            // Viser kunder efter postnummer
            static void visspkunderby()
            {
                Console.Write("Indtast postnummer: ");
                int postnummer = int.Parse(Console.ReadLine());

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string query = "dbo.spKunder_by";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@Post_Nummer", postnummer);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            Console.WriteLine("Order ID - (Fornavn - Efternavn) - Film navn - Film datetime - Film Pris - Antal billeder - Total Pris");

                            while (reader.Read())
                            {
                                int Order_ID = reader.GetInt32(0);
                                string Fornavn = reader.GetString(1);
                                string Efternavn = reader.GetString(2);
                                string Film_navn = reader.GetString(3);
                                DateTime Film_datetime = reader.GetDateTime(4);
                                int Film_Pris = reader.GetInt32(5);
                                int Antal_billedter = reader.GetInt32(6);
                                int TotalPris = reader.GetInt32(7);

                                Console.WriteLine($"{Order_ID} - ({Fornavn} - {Efternavn}) - {Film_navn} - {Film_datetime} - {Film_Pris} - {Antal_billedter} - {TotalPris}");
                            }
                        }
                    }

                    Console.WriteLine("Tryk 'Enter' at fortsætte...");
                    Console.ReadLine();
                    Console.WriteLine("\n");
                }
            }



        }
    }
}
