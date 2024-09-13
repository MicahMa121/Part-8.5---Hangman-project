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

            for (int i = 0; i < wordbank.Count; i++)
            {
                wordbank[i] = wordbank[i].ToUpper();
            }

            Random gen = new Random();

            //Game Start
            int state = 0;
            string answer = wordbank[gen.Next(wordbank.Count)];
            StringBuilder display_word = new StringBuilder(answer.Length);
            List<string> letters_guessed = new List<string>();
            foreach (char c in answer)
            {
                display_word.Append('-');
            }
            Console.WriteLine(display_word.ToString());
            DrawHangman(state);
            Console.WriteLine("Please save the hangman!");
            Console.WriteLine("Letter guessed: " + string.Join(", ", letters_guessed));
            Console.WriteLine("Guess the word or a letter!");
            string user_guess = Console.ReadLine().ToUpper();
            while (string.IsNullOrEmpty(user_guess)||(user_guess.Length != 1&& user_guess.Length !=answer.Length))
            {
                Console.WriteLine("Invalid Input");
                Console.WriteLine("Guess the word or a letter!");
                user_guess = Console.ReadLine();
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

                    }
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
