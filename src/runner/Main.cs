// bool status = true;

// while(status)
// {

// }


#pragma warning disable CA1416
Console.SetWindowSize(209, 54);
Console.SetBufferSize(209, 55);
#pragma warning restore CA1416

PageMainMenu comps = new PageMainMenu();

while(ProgramStatus.IsRunning)
{
    comps.GenerateMenu();
}