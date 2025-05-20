using MineSweeper.Model.Pages;
using MineSweeper.Model.Status;

#pragma warning disable CA1416
Console.SetWindowSize(170, 46);
Console.SetBufferSize(179, 47);
#pragma warning restore CA1416

PageMainMenu page = new PageMainMenu();
// var components = new ComponentsOfMenuPage();

while(ProgramStatus.GetStatus())
{
    page.Generate();
}