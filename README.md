# 🕵️‍♂️ The Mansion: Part I

> A Unity-based first-person survival mystery game developed as the final project for CC447 - *Multimedia and Virtual Reality Systems (Game Programming)* under the guidance of Dr. Noureldin S. Eissa.

## 🏛️ Overview

Veteran detective Sam and his loyal dog, Cooper, arrive at the fog-shrouded Black Hollow Isle to investigate a series of mysterious disappearances. With the Ashbourne Mansion gates locked, Sam must search the island, defend himself against monstrous spiders, and uncover clues to gain access. This game combines environmental storytelling, AI interaction, real-time combat mechanics, and immersive weather and sound systems to create a compelling first-person exploration experience.

---

## 🎮 Core Features

- 🎯 **First-Person Detective Controller**  
  Smooth player movement with walking, running, jumping, and projectile-throwing mechanics. Features vertical look clamp (±60°), animation blending, footstep sounds, and realistic shadow rendering (body hidden, shadows visible).

- 🪨 **Rock-Based Combat System**  
  Throw rock projectiles at enemies with real-time aim using a red crosshair. Physics-based shatter animation, sound effects, and inventory management (pickup + limits).

- 🕷️ **AI Spider Enemies**  
  Two enemy types (Black, Brown) with full NavMeshAgent behavior: patrol, chase, attack, return-to-idle. Attack with damage delays, animation sync, and health thresholds. Features random spawn and intelligent terrain navigation.

- 🗺️ **Procedural Terrain & NavMesh**  
  1000x1000x600 terrain heightmap import with custom terrain blending, billboard grass, oak tree spawner (500+), interactable rocks, and navigation mesh support for AI agents.

- 🌧️ **Dynamic Weather & Particle Systems**  
  Real-time fog and rain effects follow the player, with thunder implemented via directional lighting and timed audio to simulate lightning delay.

- 🏠 **Mansion with Interactive Gate System**  
  Static mansion object with working collision, lighting, and a gated fence. Gates open only after key is collected, using interactable logic and smooth animations.

- 🧭 **Waypoint Arrow System**  
  A 3D arrow hovers above the player, dynamically pointing to the key, then to the mansion. Can be toggled on/off via `TAB`.

- ✨ **Magical Key Pickup with FX**  
  Randomly placed key with magical circle effect. Can only be picked up on terrain below 60° slope. Unlocks mansion gate upon collection.

- 💡 **Skybox, Lighting & Clouds**  
  Slowly rotating skybox paired with custom cloud controller and environmental directional lighting. Lightning flashes simulate thunder during storms.

- 📊 **HUD & Win/Lose States**  
  - Health bar (starts at 100, game resets on 0)
  - Stamina bar (drains while running, drops on jump, auto-recovers)
  - Rock inventory (10–50 limit)
  - Key status
  - Dynamic objective updates

- 🐕 **Bonus Companion AI – Cooper** *(Optional, implemented)*  
  Fully animated dog companion that:
  - Follows the player intelligently
  - Can be commanded to return or search for the key
  - Barks continuously when the key is found

---

## 🧩 Key Technical Systems

| System                  | Summary                                                                 |
|------------------------|-------------------------------------------------------------------------|
| 🎮 FPS Controller       | `DetectiveMovement.cs`, `MouseLook.cs`, `RockThrower.cs`, Animator setup |
| 🕹️ Input               | WASD + Jump + LMB throw + RMB pickup + TAB toggle + 1/2 Cooper commands |
| 📦 Rock Inventory      | Managed with `RockInventory.cs` and cross-referenced in UI              |
| 🕷️ Spider AI           | `SpiderController.cs`, `SpiderSpawner.cs`, animations, hit logic        |
| 🔥 Thunder & Lightning | Light-based flash, delayed sound, randomized interval system             |
| 🔑 Key Logic           | `KeyController.cs`, randomly placed, tracked with HUD                   |
| 🚪 Gate Interaction    | `GatteInteraction.cs`, conditional on key possession                    |
| 🌫️ Weather Effects     | `WeatherFollower.cs`, fog/rain particles follow player                   |
| 📡 Wayfinder Arrow     | `WayfinderArrow.cs`, direction logic toggled with TAB                   |
| 🏞️ Terrain Detailing   | `TerrianLayers.cs`, `OakTreeSpawner.cs`, `RockSpawner.cs`                |
| 💬 HUD System          | Health, Stamina, Rock Count, Objectives, Key Status                     |
| 🧠 Game Manager        | Central control for win/lose conditions, scene resets                   |

---

## 🗂️ Project Structure Highlights

```plaintext
Assets/
│
├── Prefabs/
│   ├── Detective
│   ├── Spider (Black & Brown)
│   ├── Cooper
│   ├── TheMansion
│   ├── Key
│   ├── Rocks (3 types)
│   ├── Gate, Fence
│   ├── MagicCircle, Arrow, Clouds
│
├── Scripts/
│   ├── DetectiveMovement.cs
│   ├── RockThrower.cs
│   ├── SpiderController.cs
│   ├── GameManager.cs
│   ├── Health.cs / PlayerHealth.cs
│   ├── WeatherFollower.cs
│   ├── CooperController.cs
│   ├── KeyController.cs
│   ├── TerrainLayers.cs
│   ├── OakTreeSpawner.cs / RockSpawner.cs
│   └── ...and more
│
├── Audio/
├── Animations/
├── Materials/
├── Shaders/
└── Scenes/
```

## 🌿 Terrain & ☁️ Cloud
- Applied materials and terrain layers using the `TerrianLayers` script.
- Cloud rotates on the Y-axis using `CloudSphereController`.

![image](https://github.com/user-attachments/assets/322739c3-cee9-46e0-8ee6-b7b51aaf2271)
---

## 🌌 Skybox
- Rotating skybox handled via `SkyboxRotator`.
 ---  
![image](https://github.com/user-attachments/assets/56796bf1-1cfe-429e-9f3c-e1c27ebb2413)

## 🌊 Water Shader
- Slight overlap applied for better terrain blending.

![image](https://github.com/user-attachments/assets/02728518-8770-4282-aea5-d3d5ee4bf8ce)

made it slightly overlapping 
![image](https://github.com/user-attachments/assets/39cd6313-bf05-40d4-86a9-f75cabd4f7da)

--- 

## 🌧️ Particle Effects: Rain & Fog
- Particles follow player & camera using `WeatherFollower`.
- Used `LateUpdate()` for smoother sync.

| Method         | When it runs    | Use case                            |
| -------------- | --------------- | ----------------------------------- |
| `Update()`     | Before movement | Movement input                      |
| `LateUpdate()` | After movement  | Camera/player syncing               |


![image](https://github.com/user-attachments/assets/5ee2b552-4285-4ba3-81ad-c369a2a3065d)

---

## ⚡ Thunder using LIGHT ONLY 

1. added 3 diffeernt directional lights , with different color
2. made 3 flicker ranges repetation to simulate natural and variation of thunder
3. added a random funtion to pick from 2 thunder sounds
4. added a random funtion to chose delay
5. added a soft lowering voice to the thunder sounds
6. added a 10 sec timer for repetation of thunder
7. played with intensities 
![image](https://github.com/user-attachments/assets/04484b40-ede8-45e8-84bf-a85dc0185670)

---

## 🌳 Oak Tree Spawner
- Spawned 500 trees using `OakTreeSpawner`.
![image](https://github.com/user-attachments/assets/99b8854b-44f1-4756-8a0b-da2a82e20f67)


![image](https://github.com/user-attachments/assets/d9506f57-0f03-49e0-812c-c02821c08a66)

## 🗝️ Key & ✨ Magical Circle
- Key scaled down; circle enlarged.
- `KeyController` manages pickup & angle checks.
- Extra animations added for realism.
 
![image](https://github.com/user-attachments/assets/876ad7aa-548e-47df-ae48-cac5ab069bd7)

![image](https://github.com/user-attachments/assets/68ddab96-d5ff-4088-be00-9d80bfb1b972)

![image](https://github.com/user-attachments/assets/9be33f65-b081-4c50-9e63-0cd147d05815)

![image](https://github.com/user-attachments/assets/ea8756f5-62f3-4cc4-ae02-809952e9970a)

![image](https://github.com/user-attachments/assets/de11ee73-ca7f-4150-bcf5-199e139ed40a)

## 🌾 Grass Wind Effect
- Used editable material to enable wind via terrain wind tools.

![image](https://github.com/user-attachments/assets/939783f3-4f1a-4e8b-9ef0-05f989b19191)

![image](https://github.com/user-attachments/assets/27b8cc9f-c784-47d9-bb8f-a3b01c59c9e5)

![image](https://github.com/user-attachments/assets/a84494ac-9cc4-4e37-9ab3-5c73c93a25e4)

![image](https://github.com/user-attachments/assets/c06cdca1-a849-4326-b161-1a76a82c6242)

![image](https://github.com/user-attachments/assets/cd5a871d-6a57-49b2-8f0d-9f296b493b26)

---

## 🪨 Rock System
- Created `RockSpawner` to randomly spawn 150 rocks from 3 prefabs.

![image](https://github.com/user-attachments/assets/9c22f114-f444-4bd7-aaa6-20c0c75376cb)

---

## 🏠 Mansion
- Rescaled and lit with spotlight.
  
![image](https://github.com/user-attachments/assets/84002f3b-d48b-414d-b825-5a644c18c711)

![image](https://github.com/user-attachments/assets/472b61c6-d7bb-4e05-a50d-56eb626313e9)
## 🚧 Fence
- Gate: collider, nav mesh obstacle, shadow renderer.

![image](https://github.com/user-attachments/assets/04032cce-1ae6-4501-bde7-d37b12a1d797)

---

## 🚪 Gates
- `GatteInteraction` script handles logic.
- Animation triggers on interaction.

![image](https://github.com/user-attachments/assets/131e9713-da9c-4965-bea3-ceb574d370e8)  
![image](https://github.com/user-attachments/assets/053b97e3-f47c-45c0-b0a1-39c902dfa415)  
![image](https://github.com/user-attachments/assets/73af3940-ab1a-4d6f-96a6-5f372677b3b3)  
![image](https://github.com/user-attachments/assets/596e5037-3aa4-4a8b-a058-76980307ed5e)  
![image](https://github.com/user-attachments/assets/2ba3171d-10b9-4afc-9216-b8e292fc3099)

---

## 🔊 Sound

![image](https://github.com/user-attachments/assets/e31e5b12-7ed6-49d1-865d-01d90327616f)

---

## 🧭 Wayfinder Arrow (TAB Toggle)
- Pressing TAB toggles visibility.
- Visual only, avoids disabling to preserve shadows.

![image](https://github.com/user-attachments/assets/6c209fef-051f-4785-a976-3b31ac7af87c)  
![image](https://github.com/user-attachments/assets/9e6d6d83-5d91-4b15-98f8-db78afcab843)  
![image](https://github.com/user-attachments/assets/ca540789-87d5-4619-81b8-974797159677)  
![image](https://github.com/user-attachments/assets/e573bb55-a94a-4ada-be90-b600f702e3ba)  
![image](https://github.com/user-attachments/assets/56dea863-ddc5-48f7-8cb4-c4830bd9d642)

---

## 🎯 Crosshair & First-Person Camera
- Render shadows only on hidden body.
- Vertical camera clamped to ±60°.
- Crosshair scales to screen size.

![image](https://github.com/user-attachments/assets/4bd1b4c3-676f-4362-99ab-b7635178b365)  
![image](https://github.com/user-attachments/assets/a51d0b03-8530-4ccd-b70b-fc2f60807ba9)  
![image](https://github.com/user-attachments/assets/4404cf96-8f3e-453f-903d-55f5c3117df8)  
![image](https://github.com/user-attachments/assets/645035ca-ff4b-4845-aa09-ad6377b484dd)

---

## 🧱 Rock Throw System

| Functionality                        | Script             | Notes                                   |
| ----------------------------------- | ------------------ | ---------------------------------------- |
| Rock inventory                      | `RockInventory`    | Tracks available rocks                  |
| Throwing rocks                      | `RockThrower`      | Uses camera direction                   |
| Shatter effect                      | `RockProjectile`   | Includes animation and audio trigger    |
| Refilling rocks (optional)         | `RockPickup`       | Ground-based pickup system              |

![image](https://github.com/user-attachments/assets/f7142d0a-8070-414b-aaf0-993e5f9f3456)  
![image](https://github.com/user-attachments/assets/f7ba9b49-7593-4c55-9421-1791e90f46ad)

---

## 🧠 Detective Character

- Animator with blend tree for walk/run.
- `DetectiveMovement` integrates movement + throw logic.
- `ThrowForce` events added for timing sync.

![image](https://github.com/user-attachments/assets/2e16b2dd-349c-4322-972e-cfeb71be1c26)  
![image](https://github.com/user-attachments/assets/127625f1-06ef-43e3-b8b9-92d95979fdec)  
![image](https://github.com/user-attachments/assets/6c4dd7ae-7e0b-41cd-87af-24fb39acdd81)  
![image](https://github.com/user-attachments/assets/36fff669-e2a5-495f-b4ee-2b6ab3dd1483)

---

## 🕷️ Spider AI

- `SpiderSpawner` and `SpiderController`
- NavMeshAgent logic and animation setup
- Blend tree for walk/run; attack, hit, death states included

![image](https://github.com/user-attachments/assets/edb1e4c3-3486-4440-ada1-83cafb91d31b)  
![image](https://github.com/user-attachments/assets/ff409431-1c33-440f-8231-b0e9c7613af9)  
![image](https://github.com/user-attachments/assets/2ed29217-38e0-4567-bce6-2633d7645ba0)  
![image](https://github.com/user-attachments/assets/6b617c55-e0c9-4a43-8033-cde449f7c9c4)

---

## 🐶 Bonus: Cooper

- Custom controller + animation logic for companion character.

![image](https://github.com/user-attachments/assets/bcaea6ce-3448-4837-a180-eccab4b6320d)  
![image](https://github.com/user-attachments/assets/ac9cca8d-836b-413a-b919-62f815be594e)

---

## 🎛️ UI & HUD

- Integrated TextMeshPro
- Gradient bars for health and stamina
- Full UI pass completed

![image](https://github.com/user-attachments/assets/2d606e23-e797-4deb-ad5e-ba9ad752d4a3)  
![image](https://github.com/user-attachments/assets/4bfdbe60-ecb4-4314-943c-47a912b9cbab)  
![image](https://github.com/user-attachments/assets/638311f6-74f3-43bd-b6bf-21098334318f)  
![image](https://github.com/user-attachments/assets/7b667890-baa9-487e-8138-6bf50b0a6abe)  
![image](https://github.com/user-attachments/assets/7a22a835-138b-4385-931e-6b55101951ba)

---

## ✅ Final Checklist

- [x] Spider AI debugged
- [x] Cooper logic functional
- [x] Rock throw bugs fixed
- [x] UI linked to gameplay
- [x] GameManager handles state transitions
- [x] Win/Lose panels and interactions tested
- [x] Collider and gameplay boundaries refined

---

## 🏁 Game Win/Lose Conditions

![image](https://github.com/user-attachments/assets/bf06c057-1696-4058-ae04-84b90f4b72c4)  
![image](https://github.com/user-attachments/assets/7a9a5f19-9956-4411-a04d-6f3f37a351cd)

---

## 📜 Key Scripts List

```text
Actionable_Rock.cs
BodyShadowCaster.cs
CloudSphereController.cs
CooperController.cs
CooperInputHandler.cs
DetectiveMovement.cs
GameManager.cs
GatteInteraction.cs
Health.cs
KeySpawner.cs
LightningController.cs
MouseLook.cs
OakTreeSpawner.cs
PlayerHealth.cs
PlayerStamina.cs
RockProjectile.cs
RockSpawner.cs
RockThrower.cs
SkyboxRotator.cs
SpiderController.cs
SpiderSpawner.cs
TerrianLayers.cs
WayfinderArrow.cs
WeatherFollower.cs

