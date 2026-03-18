# Simple 2D Platformer 🎮

A crisp, physics-based 2D platformer controller built to demonstrate core mechanics in Unity and C#.

![2d_platformer_gif](https://github.com/user-attachments/assets/f8266008-fd97-4f6c-a5da-d3308d0c6d6c)


## 🛠️ Technical Highlights
* **Modern Input System:** Implemented Unity's new `InputSystem` package with programmatic action bindings and memory management (`OnEnable`/`OnDisable`).
* **Physics & Collisions:** Utilized `Rigidbody2D` and `LayerMasks` for precise physics-based movement (`linearVelocity`) and accurate ground detection.
* **Camera Mathematics:** Created a camera follow script using `Vector3.Lerp` for smooth, framerate-independent tracking.
* **Game Loop:** Includes functional boundaries and scene-reloading mechanics.

## 💻 Tech Stack
* **Engine:** Unity 6 
* **Language:** C#
* **Concepts:** Component-based Architecture, Physics Polling, Input Actions.
