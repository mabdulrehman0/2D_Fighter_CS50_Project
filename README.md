# 2D Fighter – CS50 Final Project

## 🎮 Project Overview
This is a 2D local 1v1 fighting game developed in **Unity** using **C#**, built over a focused 17-day period as part of my CS50 final project. The Project has inspiration from retro arcade fighters but aims for simplicity and clarity over complexity. The core idea was to make a 2D fighter game that still demonstrates a solid grasp of game dev fundamentals. Throughout the project, I explored Unity's ecosystem, including UI systems, input handling, animations, sound, debugging, and build optimization. Every element from concept to final polish taught me something new.

---

## ⚙️ Features
- **Two-player local combat**: Smooth movement (not that smooth to be honest) and real-time hit detection
- **Light & heavy attack system**: Both players have two unique attacks
- **Dynamic health bars**: Health UI updates in sync with actions
- **Win logic**: Automatic win detection and a custom win screen
- **Custom keybinding**: Options menu lets you rebind controls on the fly
- **UI/UX polish**: Menu transitions, animated buttons, and in-game feedback
- **Minimalist pixel art**: Clean and consistent retro-style visuals
- **Sound FX support**: All major actions have SFX feedback

---

## 🎮 Controls

### Player 1:
- Movement: Arrow keys
- Attacks: `K` (light), `L` (heavy)

### Player 2:
- Movement: `W`, `A`, `S`, `D`
- Attacks: `F` (light), `G` (heavy)

> Controls can be customized via the in-game Options menu.

---

## 🖥️ How to Run the Game

### 💻 Download & Play (Pre-built)
- Windows and Linux builds are available on the GitHub repo.
- ⚠️ **Note:** The Linux build was only tested on Manjaro Linux (Kernel 6.12). Other distros have not been tested
- Be sure to check out the `BUILD_README.md` before running.

### 🛠️ Run from Unity (Source Code)
1. Clone the repo from GitHub
   👉 [Project Repo](https://github.com/mabdulrehman0/2D_Fighter_CS50_Project)
2. Open Unity Hub and load the project folder
3. Allow Unity to regenerate necessary files
4. Open the `MainMenu` scene and hit Play!

---

## 📹 Demo Video
Coming soon! 

---

## 🧑‍💻 Development Journey
This project was basically a  crash course in game development. I started with zero Unity experience and slowly worked my way up, Below are the timestamps for my project:
- **Days 1–4:** Installing Unity, learning through Unity essentials, learning the basics of C# and 2D concepts
- **Days 5–8:** Player movement and camera logic. Somehow it took 3 days to get the movement system working with animations, 
- **Days 9–11:** This is where i started to get into flow and fixed Animation issues, and movement issues with the 2nd character. that also took 3 days to do.
- **Days 12–14:** Now this is where i really got into flow and made the health logic, Health UI and Hit detection
- **Days 15–17:** This was the final stretch, because i had set a deadline for me to submit and i was no where near done, so i spent 48 hours without sleep making the damage system and linking it to my hit detection and health logic, fixed the attack animations and timings of damage taking place, added sound which took 9 hours cause i was plugging in the wrong game object, added sounds and got them working, the UI system was not that hard, that took maybe 2 hours to do, including the scripting side as well, But the the most time taking part was the custom key bind system, i had to learn a lot more things re-code some of my code of characters to use those custom key binds, but the most logic heavy was looping through the enum values of key codes and setting the correct keys in that dict which was later transferred to playerperfs, and then playerprefs was used to set key binds in character scripts

Each phase came with errors, wins, and "why is this broken again?!" moments. But I got through it.

---

## ✨ What I Learned
- Unity scenes, canvases, and how game objects interact over frames
- C# scripting with event-driven design and object-oriented logic
- Designing interactive UI using Unity Events and transitions
- Handling serialized data and scriptable objects
- Dealing with real-world bugs like audio not working on certain OS setups
- How to debug build issues and missing assets
- How to structure and organize code for readability and scalability

Also: patience, planning, and timeboxing tasks. Super useful.

---

## ⚠️ Challenges Faced
- **Audio** This was truly a hassle to fix, i set some audio clips to a different game object
	then the others which made it work for only the 1st game object and the 2nd game object was never enabled,so it never played those sounds but in the end i found the issue after 9 HOURS OF LOOKING AT THE SCREEN.
- **Learning Unity and C#** at the same time — steep but doable
- **Pixel art issues** like blurry sprites and scaling problems

Despite all that, I kept going thanks to forums, tutorials, and brute-force testing.

---

## 🚀 Future Improvements (that i can do in the future if i want)
- Add AI so you can play solo
- More attack types and combos per character
- Player-select screen and multiple characters
- Polish the art style with higher res pixel assets

---

## 📜 Code Notes
All code was written by me unless mentioned. Sources of inspiration:
- **Brackeys tutorials** for concept reference (no code copied)
- **Unity Forums** for problem-solving and workaround ideas
- **ChatGPT** for code explanations, not code output

Any third-party influences are noted clearly in the scripts.

---

## 🗰️ License
Educational and demo use only. All assets are either self-made or CC0.

---

## 👤 Developer
**Abdul Rehman**  
GitHub: [mabdulrehman0](https://github.com/mabdulrehman0)

---

Thanks for checking out my CS50 Final Project!

