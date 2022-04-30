using System;

namespace GeekBrains.Learn.Cross
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = new CrossGame(15, 16, 5);

            // иницируем и выводим на печать
            game.InitField();
            game.PrintField();

            // 15 Основной ход программы

            while (true) {
                game.PlayerStep();
                game.PrintField();
                if (game.CheckWin(game.PLAYER_DOT)) {
                    Console.WriteLine("Вы победили!");
                    break;
                }
                if (game.IsFieldFull()) {
                    Console.WriteLine("Поле заполнено. Ничья");
                    break;
                }

                game.AiSteps();
                game.PrintField();
                if (game.CheckWin(game.AI_DOT)) {
                    Console.WriteLine("Вы проиграли!");
                    break;
                }
                if (game.IsFieldFull()) {
                    Console.WriteLine("Поле заполнено. Ничья");
                    break;
                }
            }
        }
    }
}
