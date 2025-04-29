// bool status = true;

// while(status)
// {

// }


#pragma warning disable CA1416
Console.SetWindowSize(200, 50);
Console.SetBufferSize(200, 50);

// Console.WriteLine(Console.LargestWindowHeight);
// Console.WriteLine(Console.LargestWindowWidth);
#pragma warning restore CA1416

PageMainMenu comps = new PageMainMenu();

while(ProgramStatus.GetStatus())
{
    comps.GenerateMenu();
}