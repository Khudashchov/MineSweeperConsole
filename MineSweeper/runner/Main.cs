using MineSweeper.Model.Pages.Components;
using MineSweeper.Model.Pages;

#pragma warning disable CA1416
// Console.SetWindowSize(200, 49);
// Console.SetBufferSize(209, 51);

Console.SetWindowSize(170, 46);
Console.SetBufferSize(179, 47);
#pragma warning restore CA1416

PageMainMenu page = new PageMainMenu();
var components = new ComponentsOfMenuPage();

while(ProgramStatus.GetStatus())
{
    page.Generate(components);
}