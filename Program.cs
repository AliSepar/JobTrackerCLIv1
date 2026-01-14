using System.IO;
internal class Program

{
    static void Main(string[] args)
    {
        List<string> MainData = new List<string>();

        string filePath = "/home/alisabah/Main Files/C#/JobTrackerCLIv1/applications.txt";

        // string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
        //         "JobTrackerCLIv1", "applications.txt");

        // Make sure the folder exists (important!)
        Directory.CreateDirectory(Path.GetDirectoryName(filePath)!);

        if (!File.Exists(filePath))
        {
            // Create the file and close it immediately
            using (File.Create(filePath)) { }
        }
        else
        {
            //TODO: here it has to read from the file and add it to memory (list)
            // using (var sr = new StreamReader(filePath))
            // {
            //     while (sr.Peek() >= 0)
            //         MainData.Add(sr.ReadLine());
            // }

            var lines = File.ReadAllLines(filePath);
            MainData.AddRange(lines.Where(l => !string.IsNullOrWhiteSpace(l)));
        }


        //main data list

        bool running = true;
        while (running)
        {

            Console.WriteLine("Job Tracker CLI Application");
            string menu =
                 "1. Add application\n" +
                 "2. List applications\n" +
                 "3. Search\n" +
                 "4. Update status\n" +
                 "5. Delete\n" +
                 "6. Exit";

            Console.WriteLine("\n" + menu);

            int menuSelect = validInputIntRange("Enter menu number (1-6): ", 1, 6);

            switch (menuSelect)
            {
                case 1:
                    Console.WriteLine("\nAdding New Application");
                    // string comName = "", roleTitle = "", jobNote = "", jobDate = "";
                    // int jobStatus;

                    string comName = validInputString("Enter Company Name: ");
                    string roleTitle = validInputString("Enter Role Title: ");
                    int jobStatus = validInputIntRange("Enter job Status (1. Applied, 2. Interview , 3.Rejected , 4.Offer):", 1, 4);

                    Console.Write("Enter Notes (optional, press Enter to skip): ");
                    string jobNote = Console.ReadLine();//can be empty
                    Console.Write("Enter Date (optional, DD/MM/YYYY, press Enter to skip): ");
                    string jobDate = Console.ReadLine();//can be empty


                    if (!string.IsNullOrWhiteSpace(comName) &&
                        !string.IsNullOrWhiteSpace(roleTitle))
                    {
                        string entry = $"Company={comName} | Role={roleTitle} | Status={jobStatus} | Note={jobNote} | Date={jobDate}";

                        MainData.Add(entry);

                        Console.WriteLine("Saved.\n");
                        File.AppendAllText(filePath, entry + Environment.NewLine); //save the new data in file
                        break;
                    }
                    else
                    {
                        Console.WriteLine("One or more fields are empty.\n");
                    }

                    break;

                case 2:
                    Console.WriteLine("\nlist Application");
                    if (MainData.Count == 0)
                    {
                        Console.WriteLine("No applications yet.\n");
                    }
                    else
                    {
                        for (int i = 0; i < MainData.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}) {MainData[i]}");
                        }
                        Console.WriteLine();
                    }
                    break;

                case 3:
                    Console.WriteLine("Search");
                    string keyword = validInputString("Search for application: ").Trim().ToLower();
                    var results = new List<string>();
                    foreach (var item in MainData)
                    {
                        if (item.ToLower().Contains(keyword))
                            results.Add(item);

                    }
                    if (results.Count == 0)
                    {
                        System.Console.WriteLine("No matches found.\n");
                    }
                    else
                    {
                        Console.WriteLine($"found {results.Count} match(es):");
                        for (int i = 0; i < results.Count; i++)
                        {
                            Console.WriteLine($"{i + 1} {results[i]}");
                        }
                        Console.WriteLine();
                    }

                    break;

                case 4:
                    Console.WriteLine("Update status");
                    break;

                case 5:
                    Console.WriteLine("Delete");
                    break;

                case 6:
                    Console.WriteLine("Goodbye!");
                    return;


                default:
                    Console.WriteLine("Not implemented yet.\n");
                    break;
            }

        }

        static string validInputString(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();

                if (!String.IsNullOrWhiteSpace(input))
                {
                    return input;
                }
                System.Console.WriteLine("Input invalid. please try again.\n");
            }
        }

        static int validInputIntRange(string prompt, int min, int max)
        {
            while (true)
            {
                Console.Write(prompt);
                string s = Console.ReadLine();

                if (int.TryParse(s, out int value) && value >= min && value <= max)
                    return value;

                Console.WriteLine($"Invalid number. Enter a number from {min} to {max}.\n");
            }
        }


    }

}