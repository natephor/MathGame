
List<GameRound> gameRounds = new List<GameRound>();

Console.WriteLine("Welcome to Math Game!");
while (true)
{
    string? choice;
    int selection;
    do
    {
        DisplayMenu();
        choice = Console.ReadLine();
    } while (!int.TryParse(choice, out selection) || selection is > 6 or < 1);

    if (selection == 6)
    {
        Console.WriteLine("\nGame Over.");
        break;
    }

    if (selection == 5)
    {
        DisplayHistory(gameRounds);
        continue;
    }

    var random = new Random();
    var firstNumber = random.Next(0, 101);
    var secondNumber = random.Next(0, 101);
    
    var result = 0;
    var question = "";
    var operation = (Operation)selection;
    switch (operation)
    {
        case Operation.Addition:
            result = firstNumber + secondNumber;
            question = $"{firstNumber} + {secondNumber}";
            break;
        case Operation.Subtraction:
            result = secondNumber - firstNumber;
            question = $"{secondNumber} - {firstNumber}";
            break;
        case Operation.Multiplication:
            result = firstNumber * secondNumber;
            question = $"{firstNumber} * {secondNumber}";
            break;
        case Operation.Division:
            secondNumber = random.Next(1, 101);
            while (firstNumber % secondNumber != 0)
            {
                firstNumber = random.Next(0, 101);
                secondNumber = random.Next(1, 101);
            }

            result = firstNumber / secondNumber;
            question = $"{firstNumber} / {secondNumber}";
            break;
    }

    int answer;
    string? userInput;
    do
    {
        Console.Write($"{question} = ");
        userInput = Console.ReadLine();
    } while (!int.TryParse(userInput, out answer));

    Console.Write(answer == result ? "That was correct!" : $"That was incorrect!");
    Console.WriteLine($" {question} = {result}");
    gameRounds.Add(new GameRound(question, result, answer));
}

Console.WriteLine("Thank you for playing!");

void DisplayHistory(List<GameRound> rounds)
{
    if (rounds.Count == 0)
    {
        Console.WriteLine("You haven't played any games this session.");
        return;
    }
    
    Console.WriteLine("Printing Game History:");
    foreach (var round in rounds)
        Console.WriteLine($"{round.Question} = {round.Result} (you answered: {round.UserAnswer}).");
}


void DisplayMenu()
{
    Console.WriteLine("\nSelect an operation (1-4):");
    Console.WriteLine("1. Addition");
    Console.WriteLine("2. Subtraction");
    Console.WriteLine("3. Multiplication");
    Console.WriteLine("4. Division");
    Console.WriteLine("5. Show History");
    Console.WriteLine("6. End Game");
    Console.Write("Select an option: ");
}

enum Operation
{
    Addition = 1,
    Subtraction,
    Multiplication,
    Division
}

record GameRound(string Question, int Result, int UserAnswer);


