using MineSweeper.Model.Logic;

namespace MineSweeper.Model.Messages;

public static class Message
{
    public static readonly string[] WinMessage = {
        "██╗    ██╗██╗███╗   ██╗██╗",
        "██║    ██║██║████╗  ██║██║",
        "██║ █╗ ██║██║██╔██╗ ██║██║",
        "██║███╗██║██║██║╚██╗██║╚═╝",
        "╚███╔███╔╝██║██║ ╚████║██╗",
        " ╚══╝╚══╝ ╚═╝╚═╝  ╚═══╝╚═╝"
    };
    public static readonly string[] LossMessage = {
        "██╗      ██████╗ ███████╗███████╗██╗",
        "██║     ██╔═══██╗██╔════╝██╔════╝██║",
        "██║     ██║   ██║███████╗███████╗██║",
        "██║     ██║   ██║╚════██║╚════██║╚═╝",
        "███████╗╚██████╔╝███████║███████║██╗",
        "╚══════╝ ╚═════╝ ╚══════╝╚══════╝╚═╝"
    };

    public static readonly string[] MineSweeperName =
    {
        "███╗░░░███╗██╗███╗░░██╗███████╗░██████╗░██╗░░░░░░░██╗███████╗███████╗██████╗░███████╗██████╗░",
        "████╗░████║██║████╗░██║██╔════╝██╔════╝░██║░░██╗░░██║██╔════╝██╔════╝██╔══██╗██╔════╝██╔══██╗",
        "██╔████╔██║██║██╔██╗██║█████╗░░╚█████╗░░╚██╗████╗██╔╝█████╗░░█████╗░░██████╔╝█████╗░░██████╔╝",
        "██║╚██╔╝██║██║██║╚████║██╔══╝░░░╚═══██╗░░████╔═████║░██╔══╝░░██╔══╝░░██╔═══╝░██╔══╝░░██╔══██╗",
        "██║░╚═╝░██║██║██║░╚███║███████╗██████╔╝░░╚██╔╝░╚██╔╝░███████╗███████╗██║░░░░░███████╗██║░░██║",
        "╚═╝░░░░░╚═╝╚═╝╚═╝░░╚══╝╚══════╝╚═════╝░░░░╚═╝░░░╚═╝░░╚══════╝╚══════╝╚═╝░░░░░╚══════╝╚═╝░░╚═╝"
    };

    public static void DrawMessage(string[] message)
    {
        for (int i = 0; i < Console.WindowHeight; i++)
        {
            for (int j = 0; j < Console.WindowWidth; j++)
            {
                Console.SetCursorPosition(j, i);
                Console.BackgroundColor = ConsoleColor.Magenta;
                Console.Write(' ');
            }
        }
        for (int i = 0; i < message.Length; i++)
        {
            Cursor.SetCursorCenter(i + 5, Console.WindowWidth, message[i]);
            Console.WriteLine(message[i]);
        }

    }
}