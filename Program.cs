using System.ComponentModel;

Console.WriteLine("Hello, World!");
Console.WriteLine("[S]ee all todos");
Console.WriteLine("[A]dd a TODO");
Console.WriteLine("[R]emove a TODO");
Console.WriteLine("[E]xit");

bool isValid = false;
List<string> userChoices = new List<string>();

do {
    string userChoice = Console.ReadLine().ToUpper();

    switch (userChoice)
    {
        case "S":
            PrintSelectedOption(userChoice);
            if(userChoices.Count == 0)
            {
                Console.WriteLine("Not todos has been added, press enter to show the options again");
            }
            else { 
            foreach (var item in userChoices)
            {
                int index = userChoices.IndexOf(item);
                Console.WriteLine($"{index + 1} {item}");

            }
            }
            break;
        case "A":
            PrintSelectedOption(userChoice);
            string todoAdd;

            do
            {
                Console.WriteLine("Enter the TODO description.");
                todoAdd = Console.ReadLine();

                if (todoAdd.Length == 0 || todoAdd == "")
                {
                    Console.WriteLine("The description cannot be empty.");
                }
                else if (userChoices.Contains(todoAdd))
                {
                    Console.WriteLine("The description must be unique.");
                }
            } while (todoAdd.Length == 0 || todoAdd == "" || userChoices.Contains(todoAdd));
            Console.WriteLine("New TODO has been added =>"  + todoAdd  );
            Console.WriteLine("Press enter to show the options again");
            userChoices.Add(todoAdd);
            break;
        case "R":
            PrintSelectedOption(userChoice);
            if (userChoices.Count == 0)
            {
                Console.WriteLine("Not todos has been added, press enter to show the options again");
            } 
            else
            {
                Console.WriteLine("Which TODO want to delete, Only write the index");
                foreach (var item in userChoices)
                {
                    int index = userChoices.IndexOf(item);
                    Console.WriteLine($"{index + 1} {item}");
                }
                int option;
                bool validOption = false;

                do
                {
                    if (!int.TryParse(Console.ReadLine(), out option) || option < 1 || option > userChoices.Count)
                    {
                        Console.WriteLine("Invalid index. Please enter a valid index.");
                    }
                    else
                    {
                        validOption = true;
                    }
                } while (!validOption);

                // Now 'option' contains the valid index selected by the user
                userChoices.RemoveAt(option - 1);
                Console.WriteLine($"TODO at index {option} has been deleted.");


            }

            break;
        case "E":
            PrintSelectedOption(userChoice); 
            Console.WriteLine("Press any key to clsoe the program");
            isValid = true;
            break;
        default:
            Console.WriteLine("Invalid choice, enter a correct option");
            Console.WriteLine("[S]ee all todos");
            Console.WriteLine("[A]dd a TODO");
            Console.WriteLine("[R]emove a TODO");
            Console.WriteLine("[E]xit");
            break;
    }
} while (!isValid);


void PrintSelectedOption(string option)
{
    Console.WriteLine("Selected option: " + option);
}



Console.ReadKey();