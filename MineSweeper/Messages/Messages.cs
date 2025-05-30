using MineSweeper.Logic;

namespace MineSweeper.Messages;

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
}