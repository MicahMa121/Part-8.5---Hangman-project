using System.Text;

namespace Part_8._5___Hangman_project
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Initialize
            List<string> wordbank = new List<string>();
            wordbank.Add("computer");
            wordbank.Add("window");
            wordbank.Add("apple");
            wordbank.Add("keyboard");

            for (int i = 0; i < wordbank.Count; i++)
            {
                wordbank[i] = wordbank[i].ToUpper();
            }

            Random gen = new Random();

            //Game Start
            Console.WriteLine("1 - Single Player\n2 - Two Player");
            int mode;
            while (!int.TryParse(Console.ReadLine(),out mode))
            {
                Console.WriteLine("Please enter a valid value.");

            }
            if (mode == 0)
            {
                do
                {
                    int state = 0;
                    string answer = wordbank[gen.Next(wordbank.Count)];
                    StringBuilder display_word = new StringBuilder(answer.Length);
                    List<string> letters_guessed = new List<string>();
                    foreach (char c in answer)
                    {
                        display_word.Append('-');
                    }

                    do
                    {
                        Console.WriteLine("Please save the hangman!");
                        Console.WriteLine("Word: " + display_word.ToString());
                        DrawHangman(state);
                        Console.WriteLine("Letter guessed: " + string.Join(", ", letters_guessed));
                        Console.WriteLine("Guess the word or a letter!");
                        string user_guess = Console.ReadLine().ToUpper();
                        while (string.IsNullOrEmpty(user_guess) || (user_guess.Length != 1 && user_guess.Length != answer.Length) || letters_guessed.Contains(user_guess))
                        {
                            Console.WriteLine("Invalid Input");
                            Console.WriteLine("Guess the word or a letter!");
                            user_guess = Console.ReadLine().ToUpper();
                        }
                        if (user_guess.Length == 1)
                        {
                            letters_guessed.Add(user_guess);
                            if (answer.Contains(user_guess))
                            {
                                Console.WriteLine(user_guess + " is a correct guess!");
                                List<int> indices = new List<int>();
                                for (int i = 0; i < answer.Length; i++)
                                {
                                    if (answer[i].ToString() == user_guess)
                                    {
                                        indices.Add(i);
                                    }
                                }
                                foreach (int i in indices)
                                {
                                    display_word.Remove(i, 1);
                                    display_word.Insert(i, user_guess);
                                }
                                if (answer == display_word.ToString())
                                {
                                    Console.WriteLine("You guessed it, the word is " + answer + ", hangman is saved!");
                                    state = -1;
                                }
                            }
                            else
                            {
                                Console.WriteLine(user_guess + " is not a correct guess!");
                                state++;
                            }
                        }
                        else if (user_guess.Length == answer.Length)
                        {
                            if (user_guess == answer)
                            {
                                Console.WriteLine("You guessed it, hangman is saved!");
                                state = -1;
                                display_word = new StringBuilder(answer);
                            }
                            else
                            {
                                Console.WriteLine("Oops, wrong guess.");
                                state++;
                            }
                        }
                        Thread.Sleep(1500);
                        Console.Clear();
                    }
                    while (state < 6 && state != -1);
                    if (state >= 6)
                    {
                        Console.WriteLine("YOU KILLED THE HANGMAN!!!");
                        Console.WriteLine("The word is " + answer + "!");
                    }
                    Console.WriteLine("Do you want to play again? Or enter \"No\" to exit.");
                }
                while (Console.ReadLine().ToLower() == "no");
            }
            else
            {
                do
                {
                    int state = 0;
                    Console.WriteLine("Player 1, please enter a word without numbers, spaces, nor special symbols!");
                    string answer = Console.ReadLine().ToUpper();
                    while (string.IsNullOrEmpty(answer))
                    {
                        Console.WriteLine("Please enter a word.");
                        answer = Console.ReadLine().ToUpper();
                    }
                    Console.WriteLine("The word you choose is "+answer+"! The game will start in 5 seconds");
                    Thread.Sleep(1000);
                    for (int i = 0; i< 4; i++)
                    {
                        Thread.Sleep(1000);
                        Console.WriteLine("The game will start in "+ (4-i)+" seconds");
                    }
                    Console.Clear();
                    StringBuilder display_word = new StringBuilder(answer.Length);
                    List<string> letters_guessed = new List<string>();
                    foreach (char c in answer)
                    {
                        display_word.Append('-');
                    }

                    do
                    {
                        Console.WriteLine("Player 2, please save the hangman!");
                        Console.WriteLine("Word: " + display_word.ToString());
                        DrawHangman(state);
                        Console.WriteLine("Letter guessed: " + string.Join(", ", letters_guessed));
                        Console.WriteLine("Guess the word or a letter!");
                        string user_guess = Console.ReadLine().ToUpper();
                        while (string.IsNullOrEmpty(user_guess) || (user_guess.Length != 1 && user_guess.Length != answer.Length) || letters_guessed.Contains(user_guess))
                        {
                            Console.WriteLine("Invalid Input");
                            Console.WriteLine("Guess the word or a letter!");
                            user_guess = Console.ReadLine().ToUpper();
                        }
                        if (user_guess.Length == 1)
                        {
                            letters_guessed.Add(user_guess);
                            if (answer.Contains(user_guess))
                            {
                                Console.WriteLine(user_guess + " is a correct guess!");
                                List<int> indices = new List<int>();
                                for (int i = 0; i < answer.Length; i++)
                                {
                                    if (answer[i].ToString() == user_guess)
                                    {
                                        indices.Add(i);
                                    }
                                }
                                foreach (int i in indices)
                                {
                                    display_word.Remove(i, 1);
                                    display_word.Insert(i, user_guess);
                                }
                                if (answer == display_word.ToString())
                                {
                                    Console.WriteLine("You guessed it, the word is " + answer + ", hangman is saved!");
                                    Console.WriteLine("Player 2 won!");
                                    state = -1;
                                }
                            }
                            else
                            {
                                Console.WriteLine(user_guess + " is not a correct guess!");
                                state++;
                            }
                        }
                        else if (user_guess.Length == answer.Length)
                        {
                            if (user_guess == answer)
                            {
                                Console.WriteLine("You guessed it, hangman is saved!");
                                Console.WriteLine("Player 2 won!");
                                state = -1;
                                display_word = new StringBuilder(answer);
                            }
                            else
                            {
                                Console.WriteLine("Oops, wrong guess.");
                                state++;
                            }
                        }
                        Thread.Sleep(1500);
                        Console.Clear();
                    }
                    while (state < 6 && state != -1);
                    if (state >= 6)
                    {
                        Console.WriteLine("YOU KILLED THE HANGMAN!!!");
                        Console.WriteLine("The word is " + answer + "!");
                        Console.WriteLine("Player 1 won!");
                    }
                    Console.WriteLine("Do you want to play again? Or enter \"No\" to exit.");
                }
                while (Console.ReadLine().ToLower() != "no");
            }
        }
        public static void DrawHangman(int state)
        {
            Console.WriteLine();
            switch (state)
            {
                case 0:
                    Console.WriteLine("  +---+\r\n  |   |\r\n      |\r\n      |\r\n      |\r\n      |\r\n=========");
                    break;
                case 1:
                    Console.WriteLine("  +---+\r\n  |   |\r\n  O   |\r\n      |\r\n      |\r\n      |\r\n=========");
                    break;
                case 2:
                    Console.WriteLine("  +---+\r\n  |   |\r\n  O   |\r\n  |   |\r\n      |\r\n      |\r\n=========");
                    break;
                case 3:
                    Console.WriteLine("  +---+\r\n  |   |\r\n  O   |\r\n /|   |\r\n      |\r\n      |\r\n=========");
                    break;
                case 4:
                    Console.WriteLine("  +---+\r\n  |   |\r\n  O   |\r\n /|\\  |\r\n      |\r\n      |\r\n=========");
                    break;
                case 5:
                    Console.WriteLine(" +---+\r\n  |   |\r\n  O   |\r\n /|\\  |\r\n /    |\r\n      |\r\n=========");
                    break;
                case 6:
                    Console.WriteLine("  +---+\r\n  |   |\r\n  O   |\r\n /|\\  |\r\n / \\  |\r\n      |\r\n=========");
                    break;
                case -1:
                    Console.WriteLine("  +---+\r\n      |\r\n      | \r\n \\O/  |\r\n  |   |\r\n / \\  |\r\n=========");
                    break;
            }
            Console.WriteLine();
        }
    }
}
