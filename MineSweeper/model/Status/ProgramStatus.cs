namespace MineSweeper.Model.Status;

public static class ProgramStatus
{
    private static bool _isRunning { get; set; } = true;
    private static bool _isMenuRunning { get; set; }
    private static bool _isGameRunning { get; set; }

    public static void EnableMenu() => _isMenuRunning = true;

    public static void DisableMenu() => _isMenuRunning = false;

    public static bool GetMenuStatus() => _isMenuRunning;

    public static void CloseProgram() => _isRunning = false;

    public static bool GetStatus() => _isRunning;

    public static bool EnableGame() => _isGameRunning = true;

    public static bool DisableGame() => _isGameRunning = false;

    public static bool GetGameStatus() => _isGameRunning;
}