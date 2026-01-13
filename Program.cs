
internal class Program

{
    static void Main(string[] args)
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

        //main data list
        List<string> MainData = new List<string> { };

        Console.Write("Enter menu number: ");
        int menuSelect = Convert.ToInt32(Console.ReadLine());

        switch (menuSelect)
        {
            case 1:
                Console.WriteLine("Adding New Application");
                string comName = "", roleTitle = "", jobNote = "", jobDate = "";
                int jobStatus;

                comName = validInputString("Enter Company Name: ");

                roleTitle = validInputString("Enter Role Title: ");

                jobStatus = validInputInt("Enter job Status (1. Applied, 2. Interview , 3.Rejected , 4.Offer):");

                jobNote = validInputString("Enter Notes: ");

                jobDate = validInputString("Enter Date(DD/MM/YYYY): ");


                if (!string.IsNullOrWhiteSpace(comName) &&
                    !string.IsNullOrWhiteSpace(roleTitle) &&
                    jobStatus != 0 &&
                    !string.IsNullOrWhiteSpace(jobNote) &&
                    !string.IsNullOrWhiteSpace(jobDate))
                {
                    string entry = $"Company={comName} | Role={roleTitle} | Status={jobStatus} | Note={jobNote} | Date={jobDate}";

                    MainData.Add(entry);

                    Console.WriteLine("Successful application entry\n");
                }
                else
                {
                    Console.WriteLine("One or more fields are empty.\n");
                }

                foreach (var item in MainData)
                {
                    Console.WriteLine(item);
                }

                break;

            case 2:
                Console.WriteLine("list Application");
                break;

            case 3:
                Console.WriteLine("Search");
                break;

            case 4:
                Console.WriteLine("Update status");
                break;

            case 5:
                Console.WriteLine("Delete");
                break;

            case 6:
                Console.WriteLine("Exit");
                break;


            default:
                System.Console.WriteLine("invalid input");
                break;
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

        static int validInputInt(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string IntInput = Console.ReadLine();

                if (int.TryParse(IntInput, out int input))
                {
                    return input;
                }
                Console.WriteLine("Invalid number. Please enter a whole number.\n");

            }
        }


    }

}