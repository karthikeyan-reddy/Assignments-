using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Assignments
{
    namespace Entries
    {
        class Entities
        {

            public int MovieId { get; set; }
            public string MovieName { get; set; }
            public string CrewCast { get; set; }
            public DateTime ReleaseDate { get; set; }
            public string MovieContent { get; set; }
        }
    }
    namespace DataBaseLayer
    {
        using Entries;
        class Data
        {
            const int size = 100;
            Entities[] entries = new Entities[size];
            public void AddNewMovie(Entities entity)
            {
                for (int i = 0; i < size; i++)
                {
                    //find the first index having null
                    if (entries[i] == null)
                    {
                        entries[i] = new Entities
                        {
                            //set the values to that index of array
                            MovieId = entity.MovieId,
                            MovieName = entity.MovieName,
                            CrewCast = entity.CrewCast,
                            ReleaseDate = entity.ReleaseDate,
                            MovieContent = entity.MovieContent
                        };
                        //exit the code
                        return;
                    }
                }

            }
            public bool UpdateMovieData(Entities entities)
            {
                bool Success = true;
                int count = 0;
                for (int i = 0; i < size; i++)
                {
                    if (entries[i] != null && entries[i].MovieId == entities.MovieId)
                    {
                        entries[i].MovieId = entities.MovieId;
                        entries[i].MovieName = entities.MovieName;
                        entries[i].ReleaseDate = entities.ReleaseDate;
                        entries[i].CrewCast = entities.CrewCast;
                        entries[i].MovieContent = entities.MovieContent;
                        count++;
                    }

                }
                if (count != 0)
                {
                    Success = true;
                }
                else
                {
                    Success = false;
                }
                return Success;
            }
            public Entities[] FindTheMovie(string MovieName)
            {
                int count = 0;

                foreach (Entities item in entries)
                {
                    if (item != null && item.MovieName == MovieName)
                    {
                        count++;
                    }
                }
                if (count != 0)
                {
                    int tempVariable = 0;
                    Entities[] FoundExpenses = new Entities[count];
                    foreach (Entities item in entries)
                    {
                        if (item != null && item.MovieName.Contains(MovieName))
                        {
                            FoundExpenses[tempVariable] = item;
                            tempVariable++;
                        }
                    }
                    return FoundExpenses;
                }
                else
                {
                    return null;
                }
            }
            public bool RemoveMovie(int MovieId)
            {
                bool success = true;
                int count = 0;
                for (int i = 0; i < size; i++)
                {
                    if (entries[i].MovieId == MovieId)
                    {
                        entries[i] = null;
                        count++;
                    }
                }
                if (count != 0)
                    success = true;
                else
                    success = false;
                return success;

            }
        }
    }
        namespace UILayer
        {
            using Entries;
            using DataBaseLayer;


            class Assignment5CRUD
            {
                static Data datalayer = new Data();
                const string UI = @"C:\MyTraining\Assignments\Assignments\MovieDataBase.txt";
                static Entities entityobj = new Entities();
                static void Main(string[] args)
                {
                    bool response = true;
                    do
                    {
                        Console.WriteLine(File.ReadAllText(UI));
                        string entry = UIConsole.GetString("WATING FOR YOUR RESPONSE!!!!!!!!!!");
                        response = TrackResponse(entry);
                        Console.ReadKey();
                        Console.Clear();
                    } while (response);
                }

                private static bool TrackResponse(string entry)
                {
                    switch (entry)
                    {
                        case "N":
                            addMovie();
                            return true;
                        case "U":
                            UpdateMovie();
                            return true;
                        case "F":
                            Findmovie();
                            return true;
                        case "R":
                            RemoveMovie();
                            return true;
                        default:
                            Console.WriteLine("Invalid Entry!! Closing the Application.....");
                            return false;
                    }
                }

                private static void RemoveMovie()
                {
                    Entities entityobj = new Entities();
                    entityobj.MovieId = UIConsole.GetNumber("Enter The Movie Id That to be Deleted From DataBase..");
                    bool check = datalayer.RemoveMovie(entityobj.MovieId);
                    if (check == true)
                    {
                        UIConsole.PrintMessage("Movie Deletion Successful.");
                    }
                    else
                    {
                        UIConsole.NegativeMessage("No Data Found Under This id To Delete!!!!");
                    }
                    

                }

                private static void Findmovie()
                {

                    try
                    {
                        string MovieName = UIConsole.GetString("Enter The Movie Name to Find The Movie Details...");

                        Entities[] finding = datalayer.FindTheMovie(MovieName);
                        if (finding != null)
                        {
                            foreach (Entities found in finding)
                            {
                                Console.WriteLine($"The Found Movie As per Name is with id {found.MovieId} with Movie Name has {found.MovieName} Released on the date of {found.ReleaseDate} with Crew and Cast of {found.CrewCast} with the Content Based On {found.MovieContent}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("No Movie Found ........");
                        }
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Enter The Movie Name !! No Numbers and DateTime are Allowed");
                    }
                }

                private static void UpdateMovie()
                {
                    Entities entityobj = new Entities();
                    entityobj.MovieId = UIConsole.GetNumber("Enter the Movie Id That to be Updated ");
                    entityobj.MovieName = UIConsole.GetString("Enter The Movie Name to Update");
                    entityobj.ReleaseDate = UIConsole.GetDate("Enter The Release Date That to be Updated.. in mm/dd/yyyy Format");
                    entityobj.CrewCast = UIConsole.GetString("Enter The Crew And Cast in The Movie");
                    entityobj.MovieContent = UIConsole.GetString("Provide The Short Content on Movie...");
                    bool Success = datalayer.UpdateMovieData(entityobj);
                    if (Success == true)
                    {
                        UIConsole.PrintMessage($"Movie Data with id Number {entityobj.MovieId} is Updated Successfully.......");
                    }
                    else
                    {
                        UIConsole.NegativeMessage("No Data Found With The ID Number Entered ........");
                    }
                }

                private static void addMovie()
                {
                    Entities entityobj = new Entities();
                    entityobj.MovieId = UIConsole.GetNumber("Enter The Movie Id");
                    entityobj.MovieName = UIConsole.GetString("Enter The Movie Name");
                    entityobj.ReleaseDate = UIConsole.GetDate("Enter The Release Date in MM/DD/YYYY");
                    entityobj.CrewCast = UIConsole.GetString("Entry The Main Crew And Cast in Movie");
                    entityobj.MovieContent = UIConsole.GetString("Provide Movie Content In Short !!!!!");
                    datalayer.AddNewMovie(entityobj);
                    UIConsole.PrintMessage("Movie Added Successfully!!!!! Thank you for Providing details ##");
                }
            }
        }
    }
