# POS.22
## What is POS.22?
POS.22 (**P**roject **O**ld **S**tar **S**table **O**nline 20**22**) was a project I started a few months ago as of writing this, aimed at launching the old Star Stable Online versions (pre-2020) and at least being able to fly around in it so the old players could get some nostalgia kicks from it.
## Is it still being worked on?
No, I don't have the motiviation to continue this and I stopped updating it since I couldn't find any viable event to hook into to allow for executing scripts on-the-fly like SSOUtils did.
### Couldn't you just do what you did with SSOUtils?
No, I can't because it's hooking into a Horse Change State event, and launching the offline games means that event is never called by itself.
Plus, crafting a custom loop with PXScript is extremely difficult in general, one wrong step and the game will panic and crash.
## Will it ever be updated?
Maybe one day, but certainly not now unless something critical isn't working or similar.
## Can I contribute on the project?
Yeah, I left Pull Requests open just for that. Do note that you **have** to follow the `LICENSE` attached in the repository, and that you are modifying the game **on your own behalf, I am not responsible for anything you do.**
## How do I use it?
1. Build the project
2. Launch an old Star Stable Online version (you can ask others for a link inside the [Discord](https://discord.gg/47j28nJqnf)).
3. As soon as you see the loading screen, open `POS.22.exe` and wait for it to patch the memory
4. Done, read the console for keybindings.
## Direct Contact
Discord: devin#8415

Telegram: @relayd
