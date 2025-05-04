using MineSweeper.Model.Components;
using MineSweeper.Model.Pages;

#pragma warning disable CA1416
Console.SetWindowSize(200, 49);
Console.SetBufferSize(209, 51);
#pragma warning restore CA1416

PageMainMenu page = new PageMainMenu();
var components = new ComponentsOfMenuPage();

while(ProgramStatus.GetStatus())
{
    page.Generate(components);
}