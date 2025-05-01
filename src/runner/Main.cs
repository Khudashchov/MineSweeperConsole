#pragma warning disable CA1416
Console.SetWindowSize(200, 49);
Console.SetBufferSize(209, 51);
#pragma warning restore CA1416

PageMainMenu comps = new PageMainMenu();

while(ProgramStatus.GetStatus())
{
    comps.Generate();
}