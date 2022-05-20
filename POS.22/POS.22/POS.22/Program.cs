using POS._22;
using POS._22.low_level.key.game;
using POS._22.low_level.scripting;
using Console = Colorful.Console;

// * Made by devin.
// ! Call Head.Run()
Console.Title = "Project Old SSO | 2022 | Made by devin#8415";
Printer.WriteInfo("Press ENTER when you're ready to start.");
Console.ReadKey();
Config.FetchConfig();
RYPX.BuildCodeSet();
Printer.WriteTutorial();
RYFreeCam.Setup();
await Head.Run();
await Task.Delay(-1);