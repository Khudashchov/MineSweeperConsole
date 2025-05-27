using MineSweeper.Abstracts;
using MineSweeper.Pages;
using MineSweeper.Pages.Components;
using MineSweeper.Status;

#pragma warning disable CA1416
Console.SetWindowSize(120, 25);
Console.SetBufferSize(129, 26);
#pragma warning restore CA1416

Console.CursorVisible = false;  

PageBase<ComponentsOfMenuPage> page = new PageMainMenu();

while(ProgramStatus.GetStatus())
{
    page.Generate();
}