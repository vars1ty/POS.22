using POS._22;
using POS._22.low_level.key.game;
using POS._22.low_level.scripting;
using Console = Colorful.Console;

// * Made by narcotics.
// ! Call Head.Run()
Console.Title = "Project Old SSO | 2022 | Made by narcotics#0911";
Config.FetchConfig();
RYPX.BuildCodeSet();
Printer.WriteTutorial();
RYFreeCam.Setup();
await Head.Run();
await Task.Delay(-1);