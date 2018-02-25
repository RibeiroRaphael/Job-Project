using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job_Project
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime inicialDate;
            DateTime finishDate;
            int people;
            string internet;
            string WebcamTV;
            int chosenClass = -1;
            int counter = 0;
            string lines;
            string text;
            bool flag = false;
           
            // Schedule list
            List<schedule> scheduling = new List<schedule>();

            //room information
            List<meetingRoom> rooms = new List<meetingRoom>();            
            for (int count = 1; count <= 5; count++)
            {
                rooms.Add(new meetingRoom()
                {
                    ClassNumber = count,
                    Computer = true,
                    Capacity = 10,
                    InternetConection = true,
                    TvWebcam1 = true
                });
            }
            for (int count = 6; count <= 7; count++)
            {
                rooms.Add(new meetingRoom()
                {
                    ClassNumber = count,
                    Computer = false,
                    Capacity = 10,
                    InternetConection = true,
                    TvWebcam1 = false
                });
            }
            for (int count = 8; count <= 10; count++)
            {
                rooms.Add(new meetingRoom()
                {
                    ClassNumber = count,
                    Computer = true,
                    Capacity = 3,
                    InternetConection = true,
                    TvWebcam1 = true
                });
            }
            for (int count = 11; count <= 12; count++)
            {
                rooms.Add(new meetingRoom()
                {
                    ClassNumber = count,
                    Computer = false,
                    Capacity = 20,
                    InternetConection = false,
                    TvWebcam1 = false
                });
            }

            string currentDirectory = Directory.GetCurrentDirectory();
            string filePath = System.IO.Path.Combine(currentDirectory, "Nova Pasta", "Dados.txt");
            System.IO.StreamReader file = new System.IO.StreamReader(filePath);

            do
            {
                while ((lines = file.ReadLine()) != null)
                {
                    //Reading from a text file
                    System.Console.WriteLine(lines);
                    counter++;
                    text = lines.ToString();
                    flag = false;

                    chosenClass = -1;
                    //Inicializing input values
                    inicialDate = Convert.ToDateTime(text.Replace(';', ' ').Substring(0, 15));
                    finishDate = Convert.ToDateTime(text.Replace(';', ' ').Substring(17, 15));
                    people = Convert.ToInt32(text.Substring(34, 2));
                    internet = Convert.ToString(text.Substring(37, 3));
                    WebcamTV = Convert.ToString(text.Substring(41, 3));
                
                    if ((DateTime.Compare(DateTime.Now.Date, inicialDate) < 0) && (DateTime.Compare(DateTime.Now.AddDays(40), finishDate) > 0))
                    {
                        if ((inicialDate.DayOfWeek != DayOfWeek.Saturday) && (inicialDate.DayOfWeek != DayOfWeek.Sunday) && (finishDate.DayOfWeek != DayOfWeek.Saturday) && (finishDate.DayOfWeek != DayOfWeek.Sunday))
                        {
                            TimeSpan time = finishDate - inicialDate;
                            if (time.Hours > 0 && time.Hours <= 8)
                            {
                                while (!flag)
                                {
                                    foreach (var choosingRoom in rooms)
                                    {
                                        if (chosenClass != -1)
                                        {
                                            break;
                                        }

                                        if (people <= choosingRoom.Capacity)
                                        {
                                            if (internet == "Sim" && choosingRoom.InternetConection || internet == "Nao" && !choosingRoom.InternetConection)
                                            {
                                                if (WebcamTV == "Sim" && choosingRoom.TvWebcam1 || WebcamTV == "Nao" && !choosingRoom.TvWebcam1)
                                                {
                                                    if (scheduling.Count != 0)
                                                    {
                                                        foreach (var record in scheduling)
                                                        {

                                                            if (record.ClassNumber == choosingRoom.ClassNumber)
                                                            {
                                                                if (DateTime.Compare(inicialDate, record.InicialTimeMeeting) < 0 && (DateTime.Compare(finishDate, record.InicialTimeMeeting) < 0))
                                                                {
                                                                    flag = true;
                                                                }
                                                                else
                                                                {
                                                                    if (DateTime.Compare(inicialDate, record.FinishTimeMeeting) > 0)
                                                                    {
                                                                        flag = true;
                                                                    }
                                                                    else
                                                                    {
                                                                        if (DateTime.Compare(inicialDate, record.InicialTimeMeeting) == 0 && DateTime.Compare(finishDate, record.FinishTimeMeeting) == 0)
                                                                        {
                                                                            flag = false;
                                                                            break;
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                            else
                                                            {
                                                                flag = true;
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        flag = true;
                                                    }
                                                    if (flag)
                                                    {
                                                        scheduling.Add(new schedule()
                                                        {
                                                            ClassNumber = choosingRoom.ClassNumber,
                                                            InicialTimeMeeting = inicialDate,
                                                            FinishTimeMeeting = finishDate
                                                        });
                                                        chosenClass = choosingRoom.ClassNumber;
                                                        Console.WriteLine("Sala: " + chosenClass.ToString());
                                                        break;
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
                filePath = System.IO.Path.Combine(currentDirectory, "Nova Pasta", "Agendamentos.txt");
                using (TextWriter tw = new StreamWriter(filePath))
                {
                    foreach (var s in scheduling)
                    {
                        tw.Write(s.InicialTimeMeeting);
                        tw.Write(s.FinishTimeMeeting + " ");
                        tw.WriteLine(s.ClassNumber);
                    }
                }
                Console.WriteLine("Press ESC key to exit.");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);            
        }
    }
}
