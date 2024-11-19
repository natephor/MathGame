Console.WriteLine("Welcome to Math Game!");

string? choice;
int selection;
do
{
    DisplayMenu();
    choice = Console.ReadLine();
} while (!int.TryParse(choice, out selection) || selection is > 4 or < 1);

var random = new Random();
var firstNumber = random.Next(0, 101);
var secondNumber = random.Next(0, 101);
int result = 0;
string output = "";
var operation = (Operation)selection;
switch (operation)
{
    case Operation.Addition:
        result = firstNumber + secondNumber;
        output = $"{firstNumber} + {secondNumber} = ";
        break;
    case Operation.Subtraction:
        result = secondNumber - firstNumber;
        output = $"{secondNumber} - {firstNumber} = ";
        break;
    case Operation.Multiplication:
        result = firstNumber * secondNumber;
        output = $"{firstNumber} * {secondNumber} = ";
        break;
    case Operation.Division:
        secondNumber = random.Next(1, 101);
        while (firstNumber % secondNumber != 0)
        {
            firstNumber = random.Next(0, 101);
            secondNumber = random.Next(1, 101);
        }

        result = firstNumber / secondNumber;
        output = $"{firstNumber} / {secondNumber} = ";
        break;
}

int answer;
string? userInput;
do
{
    Console.Write(output);
    userInput = Console.ReadLine();
} while (!int.TryParse(userInput, out answer));

Console.WriteLine(answer == result ? "You are correct!" : "You are wrong!");
Console.WriteLine($"The correct answer of {output} was {result}.");
Console.WriteLine("Thank you for playing!");

// Randomize operation
// var random = new Random();
// var operation = (Operations) random.Next(1, 5);
// Console.WriteLine(operation);
       
// Decide on operands
// DisplayProblem();
// Get answer
// Verify answer


void DisplayMenu()
{
    Console.WriteLine("Select an operation (1-4):");
    Console.WriteLine("1. Addition");
    Console.WriteLine("2. Subtraction");
    Console.WriteLine("3. Multiplication");
    Console.WriteLine("4. Division");
}

enum Operation
{
    Addition = 1,
    Subtraction,
    Multiplication,
    Division
}
