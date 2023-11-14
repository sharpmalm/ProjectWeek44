using System.Runtime.Intrinsics.X86;

string[] productArray = new string[0];
int index = 0;
Console.WriteLine("Enter product name in the following format: xxx-321. ");
bool hasError = false;

while (true)
{
    hasError = false;
    Console.WriteLine("Enter product name or 'exit' to see your product list:");
    string input = Console.ReadLine();
    if (input.Trim().ToLower() == "exit")
    { break; }
   
    //error checking goes here
   Console.ForegroundColor = ConsoleColor.Red;
    if (input.Length < 5)
    {
        Console.WriteLine("Incorrect format. Use the format AA-222");
        continue;
    }

    string[] split = input.Split("-");
    if (split.Length < 2)
    {
        Console.WriteLine("A hyphen is required. Use the format AA-222");
        continue;
    }
    else if (split.Length > 2)
    {
        Console.WriteLine("Don't use more than one hyphen. Use the format AA-222");
    }

    if (String.IsNullOrEmpty(split[0]) || String.IsNullOrEmpty(split[1]))
    {
        Console.WriteLine("Enter 2 letters on the left and three numbers on the right. Use the format AA-222.");
        hasError = true;
    }

    else
    {
        foreach (char c in split[0])
        {
            if (!char.IsLetter(c))
            {
                hasError = true;
            }
        }

        if (hasError)
        {
            Console.WriteLine("Only letters allowed on the left side. Use the format AA-222");
        }
    }

    bool isInt = int.TryParse(split[1], out int value);
    if (!isInt)
    {
        Console.WriteLine("Only numbers allowed on the right side. Use the format AA-222");
        hasError = true;
    }
    else if (value < 200 || value > 500)
    {
        Console.WriteLine("Number must be between 200-500.Length Use the format AA-222");
        hasError = true;
    }

    //error checking above
    
    if (!hasError)
    {
        Array.Resize(ref productArray, index + 1);
        productArray[index] = input.ToUpper();
        index++;
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Valid entry!");
    }
    
}

Console.WriteLine("***********");
Console.WriteLine("List of products");
Array.Sort(productArray);
foreach (string product in productArray)
{ Console.WriteLine(product); }
Console.WriteLine("Press enter to continue.");
Console.ReadLine();


//string[] productArray = new string[0];
//int index = 0;
//Console.WriteLine("Enter product name in the following format: xxx-321. ");

//while (true)
//{
//    Console.Write("Enter product name or 'exit' to see your product list.");
//    string input = Console.ReadLine();
//    if (input.Trim().ToLower() == "exit")
//    { break; }
//    Array.Resize(ref productArray, index + 1);
//    productArray[index] = input.ToUpper();
//    index++;
//}

//Array.Sort(productArray);
//foreach (string product in productArray)
//{ Console.WriteLine(product); }
//Console.ReadLine();