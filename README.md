
# Pixel Animation DFA ⚔️🛡️

[![Made with C#](https://img.shields.io/badge/Made%20with-C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)](https://learn.microsoft.com/en-us/dotnet/csharp/)
[![Platform](https://img.shields.io/badge/Platform-Windows-blue?style=for-the-badge&logo=windows&logoColor=white)](https://www.microsoft.com/en-us/windows)
[![License: Educational](https://img.shields.io/badge/License-Educational-lightgrey?style=for-the-badge)](#license)
![StateMachine Simulation](https://img.shields.io/badge/StateMachine-Simulation-%23FFA500?style=for-the-badge)

---

A **C# Windows Forms** project simulating a knight’s animation using a **State Machine**.  
An interactive experience combining **game development** and **theory of computation** — all in real time.

---

## ✨ Features

- 🎥 **Smooth Knight Animations:** Idle, Running, Crouching, Rolling, Attacking
- 🧠 **DFA-Based State Machine:** Transitions controlled strictly by DFA logic
- 🖥️ **Responsive UI:** Scales across different screen sizes
- 🎛️ **Toggle Visualization:** Knight animation ↔ DFA State Diagram
- 🛠️ **Modular Architecture:** Clean code structure for easy maintenance and expansion

---

## 📸 Preview

### Knight Animation
![Knight Animation Preview](assets/knight-preview.gif)

### State Diagram View
![State Diagram Preview](Assets/State-Diagram-light.png)

> *IdleRight is the start state*

---

## 📂 Project Structure

```
PixelAnimationDFA/
├── Animations/
│   ├── AnimateKnight.cs             # Knight frame animations
│   ├── IAnimationController.cs      # Animation controller interface
│   └── KnightAnimationController.cs # Animation controller implementation
├── Forms/
│   ├── Form1.cs                      # Main UI logic
│   └── Form1.Designer.cs             # Auto-generated layout
├── InputHandling/
│   └── InputHandler.cs               # Input mapping and UI toggling
├── Models/
│   ├── Input.cs                      # Input actions enumeration
│   └── State.cs                      # Knight states enumeration
├── StateMachine/
│   ├── IStateMachine.cs              # State machine interface
│   └── StateMachine.cs               # DFA state management
├── Assets/                           # Sprites, diagrams, and resources
├── Program.cs                        # Application entry point
└── README.md                         # This documentation
```

---

## 🚀 Getting Started

### Requirements

- Windows OS
- .NET Framework (already included with Visual Studio builds)

### Run Instructions

1. **Download** the latest release from the [Releases](#releases) section.
2. **Unzip** the downloaded file.
3. **Open** the `Release/` folder.
4. **Launch** `PixelAnimationDFA.exe`.

✅ No installation needed — just launch and enjoy!

---

## 🎮 Controls

| Key         | Action                              |
|:------------|:------------------------------------|
| `A`         | Move Left                           |
| `D`         | Move Right                          |
| `C`         | Crouch                              |
| `Z`         | Roll                                |
| `V`         | Attack                              |
| `Space`     | Jump                                |
| `9`         | Toggle between Knight ↔ State Diagram View |
| `0`         | Exit Application                    |

---

## 📖 Technical Insights

This project implements a **Deterministic Finite Automaton (DFA)** model to govern the knight’s state transitions based on player input.  
Each input event triggers a transition, keeping behavior **predictable, structured, and mathematically sound** — mirroring real-world finite automaton behavior used in AI, language parsing, and embedded systems.

---

## 📜 License

This project is available **for educational purposes only**.

See [License](#license) for more details.

---

## 📦 Releases

- 🔖 **[Download Latest Release](#)**

> *(Coming Soon: If you upload to GitHub, you can update this with the actual link.)*

---

## 🤝 Acknowledgements

- Pixel Art Inspirations (If applicable — insert credit)
- Open-source community for tools and libraries

---

## 🌟 Contributing

Interested in contributing animations, enhancements, or ideas?  
Feel free to open an issue or submit a pull request!

---
