namespace MathGame;

public class Game
{
    private readonly List<GameRound> _gameRounds = [];

    public void Run()
    {
        Console.WriteLine("Welcome to Math Game!");
        bool playerPlayed;
        do
        {
            playerPlayed = PlayOneRound();
        } while (playerPlayed);
        
        Console.WriteLine("\nGame Over.");
        Console.WriteLine("Thank you for playing!");
    }

    private bool PlayOneRound()
    {
        string? choice;
        int selection;
        do
        {
            UserInterface.DisplayMenu();
            choice = Console.ReadLine();
        } while (!int.TryParse(choice, out selection) || selection is > 6 or < 1);
        
        switch (selection)
        {
            case 6:
                return false;
            case 5:
                UserInterface.DisplayHistory(_gameRounds);
                return true;
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

        UserInterface.DisplayRoundResult(question, result, answer);
        _gameRounds.Add(new GameRound(question, result, answer));
        return true;
    }
}

enum Operation
{
    Addition = 1,
    Subtraction,
    Multiplication,
    Division
}

public record GameRound(string Question, int Result, int UserAnswer);
