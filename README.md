Pixel Animation DFA ⚔️🛡️

A C# Windows Forms project simulating a knight’s animation using a Deterministic Finite Automaton (DFA).
An interactive experience combining game development and theoretical computer science — all in real time.

✨ Features
🎥 Smooth Knight Animations: Idle, Running, Crouching, Rolling, Attacking

🧠 DFA-Based State Machine: Transitions controlled strictly by DFA logic

🖥️ Responsive UI: Scales across different screen sizes

🎛️ Toggle Visualization: Knight animation ↔ DFA State Diagram

🛠️ Modular Architecture: Clean code structure for easy maintenance and expansion

📸 Preview
Knight Animation

State Diagram View

Tip: Replace these placeholders with your actual previews for best effect!

📂 Project Structure
graphql
Copy
Edit
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
🚀 Getting Started
Requirements
Windows OS

.NET Framework (already included with Visual Studio builds)

Run Instructions
Download the latest release from the Releases section.

Unzip the downloaded file.

Open the Release/ folder.

Launch PixelAnimationDFA.exe.

✅ No installation needed — just launch and enjoy!

🎮 Controls

Key	Action
A	Move Left
D	Move Right
C	Crouch
Z	Roll
V	Attack
Space	Jump
9	Toggle between Knight ↔ State Diagram View
0	Exit Application
📖 Technical Insights
This project implements a Deterministic Finite Automaton (DFA) model to govern the knight’s state transitions based on player input.
Each input event triggers a transition, keeping behavior predictable, structured, and mathematically sound — mirroring real-world finite automaton behavior used in AI, language parsing, and embedded systems.

📜 License
This project is available for educational purposes only.

See License for more details.

📦 Releases
🔖 Download Latest Release

(Coming Soon: If you upload to GitHub, you can update this with the actual link.)

🤝 Acknowledgements
Pixel Art Inspirations (If applicable — insert credit)

Open-source community for tools and libraries

🌟 Contributing
Interested in contributing animations, enhancements, or ideas?
Feel free to open an issue or submit a pull request!