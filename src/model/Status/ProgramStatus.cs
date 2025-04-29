public static class ProgramStatus
{
    private static bool IsRunning {get; set;} = true;
    private static bool _isMenuRunning {get; set;}

    public static void EnableMenu()
    {
        _isMenuRunning = true;
    }

    public static void DisableMenu()
    {
        _isMenuRunning = false;
    }

    public static void CloseProgram()
    {
        IsRunning = false;
    }

    public static bool GetMenuStatus()
    {
        return _isMenuRunning;
    }

    public static bool GetStatus()
    {
        return IsRunning;
    }
}