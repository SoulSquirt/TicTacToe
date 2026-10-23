
using System;

public class Program
{
    static char[] board = new char[9];

    public static void Main()
    {
        bool playAgain = true;

        while (playAgain)
        {
            for (int i = 0; i < 9; i++)
                board[i] = ' ';

            char player = 'X';
            bool gameOver = false;

            while (!gameOver)
            {
                Console.Clear();
                DrawBoard();

                Console.WriteLine("Ход игрока " + player);
                Console.Write("Выбери клетку от 1 до 9: ");

                int move;
                if (!int.TryParse(Console.ReadLine(), out move) ||
                    move < 1 || move > 9)
                {
                    Console.WriteLine("Ошибка! Введи число от 1 до 9.");
                    Console.ReadKey();
                    continue;
                }

                if (board[move - 1] != ' ')
                {
                    Console.WriteLine("Клетка занята! Выбери другую.");
                    Console.ReadKey();
                    continue;
                }

                board[move - 1] = player;

                if (CheckWin(player))
                {
                    Console.Clear();
                    DrawBoard();
                    Console.WriteLine("Победил игрок " + player + "!");
                    gameOver = true;
                }
                else if (CheckDraw())
                {
                    Console.Clear();
                    DrawBoard();
                    Console.WriteLine("Ничья!");
                    gameOver = true;
                }
                else
                {
                    player = player == 'X' ? 'O' : 'X';
                }
            }

            Console.Write("Сыграть ещё раз? (да/нет): ");
            playAgain = Console.ReadLine().Trim().ToLower() == "да";
        }

        Console.WriteLine("Игра завершена!");
    }

    static void DrawBoard()
    {
        for (int i = 0; i < 9; i++)
        {
            string cell = board[i] == ' '
                ? (i + 1).ToString()
                : board[i].ToString();

            Console.Write(" " + cell + " ");

            if (i % 3 != 2)
                Console.Write("|");
            else if (i != 8)
                Console.WriteLine("\n---+---+---");
        }

        Console.WriteLine();
    }

    static bool CheckWin(char player)
    {
        int[,] lines = {
            {0, 1, 2}, {3, 4, 5}, {6, 7, 8},
            {0, 3, 6}, {1, 4, 7}, {2, 5, 8},
            {0, 4, 8}, {2, 4, 6}
        };

        for (int i = 0; i < 8; i++)
        {
            if (board[lines[i, 0]] == player &&
                board[lines[i, 1]] == player &&
                board[lines[i, 2]] == player)
                return true;
        }

        return false;
    }

    static bool CheckDraw()
    {
        foreach (char cell in board)
        {
            if (cell == ' ')
                return false;
        }

        return true;
    }
}
