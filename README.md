# The-Mansion-Part-I
# Terrian & Cloud 
1. added materials and layers on trian using the script 'TerrianLayers'
2. cloud rotates on y axis using script 'CloudSphereController'

![image](https://github.com/user-attachments/assets/322739c3-cee9-46e0-8ee6-b7b51aaf2271)


# SkyBox
1. added skyybox that rotates using the script 'SkyboxRotator'
   
![image](https://github.com/user-attachments/assets/56796bf1-1cfe-429e-9f3c-e1c27ebb2413)

# Water Shader 

![image](https://github.com/user-attachments/assets/02728518-8770-4282-aea5-d3d5ee4bf8ce)

made it slightly overlapping 
![image](https://github.com/user-attachments/assets/39cd6313-bf05-40d4-86a9-f75cabd4f7da)


# Particale Effect 
1.  rain and fog , made them follow both the player and the camera using code 'WeatherFollower'
2.  used late update rather than update because
   
   | Method         | When it runs    | Use case                                    |
| -------------- | --------------- | ------------------------------------------- |
| `Update()`     | Before movement | For movement logic / physics inputs         |
| `LateUpdate()` | After movement  | For following / syncing with moving targets |

![image](https://github.com/user-attachments/assets/5ee2b552-4285-4ba3-81ad-c369a2a3065d)


# Thunder using LIGHT ONLY 

1. added 3 diffeernt directional lights , with different color
2. made 3 flicker ranges repetation to simulate natural and variation of thunder
3. added a random funtion to pick from 2 thunder sounds
4. added a random funtion to chose delay
5. added a soft lowering voice to the thunder sounds
6. added a 10 sec timer for repetation of thunder
7. played with intensities 
![image](https://github.com/user-attachments/assets/04484b40-ede8-45e8-84bf-a85dc0185670)

# Oak Trees 
1. script that spawns 500 trees when i attached the script 'OakTreeSpawner'

![image](https://github.com/user-attachments/assets/99b8854b-44f1-4756-8a0b-da2a82e20f67)


![image](https://github.com/user-attachments/assets/d9506f57-0f03-49e0-812c-c02821c08a66)

# Key & Magical circle 
1. down scaled the key and increased the circle sclae
2. creTated a key controller and attached script 'Key Controller' to put on sucessfull point and checks angle
3. made animation extra to give dimention to the game , rotation and postion
   
 
![image](https://github.com/user-attachments/assets/876ad7aa-548e-47df-ae48-cac5ab069bd7)

![image](https://github.com/user-attachments/assets/68ddab96-d5ff-4088-be00-9d80bfb1b972)

![image](https://github.com/user-attachments/assets/9be33f65-b081-4c50-9e63-0cd147d05815)

![image](https://github.com/user-attachments/assets/ea8756f5-62f3-4cc4-ae02-809952e9970a)

![image](https://github.com/user-attachments/assets/de11ee73-ca7f-4150-bcf5-199e139ed40a)

# Grass 
1. to allow wind i had to change to grass after picking edit material
2. added terrian wind tools 
![image](https://github.com/user-attachments/assets/939783f3-4f1a-4e8b-9ef0-05f989b19191)

![image](https://github.com/user-attachments/assets/27b8cc9f-c784-47d9-bb8f-a3b01c59c9e5)

![image](https://github.com/user-attachments/assets/a84494ac-9cc4-4e37-9ab3-5c73c93a25e4)

![image](https://github.com/user-attachments/assets/c06cdca1-a849-4326-b161-1a76a82c6242)

![image](https://github.com/user-attachments/assets/cd5a871d-6a57-49b2-8f0d-9f296b493b26)

# Rocks 
1. to spwan 150 rocks randomly from 3 , i created a rock manger
2. then attached script 'RockSpawner'
![image](https://github.com/user-attachments/assets/9c22f114-f444-4bd7-aaa6-20c0c75376cb)

# Mansion 
1. sclae and rotate
2. light spot 
![image](https://github.com/user-attachments/assets/84002f3b-d48b-414d-b825-5a644c18c711)

![image](https://github.com/user-attachments/assets/472b61c6-d7bb-4e05-a50d-56eb626313e9)


# Fence
1. scale the gate
2.  colider
3. nav mech obsticle
4. renderer for shadow

![image](https://github.com/user-attachments/assets/04032cce-1ae6-4501-bde7-d37b12a1d797)

# Gates

![image](https://github.com/user-attachments/assets/131e9713-da9c-4965-bea3-ceb574d370e8)
![image](https://github.com/user-attachments/assets/053b97e3-f47c-45c0-b0a1-39c902dfa415)
![image](https://github.com/user-attachments/assets/73af3940-ab1a-4d6f-96a6-5f372677b3b3)

1. colider
2. nav mech obsticle
3. renderer for shadow
4. code for interation 'GatteInteraction'
5. addded animation on trigger 
![image](https://github.com/user-attachments/assets/596e5037-3aa4-4a8b-a058-76980307ed5e)

![image](https://github.com/user-attachments/assets/2ba3171d-10b9-4afc-9216-b8e292fc3099)



# Sound 
![image](https://github.com/user-attachments/assets/e31e5b12-7ed6-49d1-865d-01d90327616f)

# Arrow 
![image](https://github.com/user-attachments/assets/6c209fef-051f-4785-a976-3b31ac7af87c)

![image](https://github.com/user-attachments/assets/9e6d6d83-5d91-4b15-98f8-db78afcab843)

TAB 
1. CHANGED TO OLD SETTINGS
2. HANDELED ON IN CODE
   ![image](https://github.com/user-attachments/assets/ca540789-87d5-4619-81b8-974797159677)
error: toggles in on off

![image](https://github.com/user-attachments/assets/e573bb55-a94a-4ada-be90-b600f702e3ba)
error: switchs off and thats it 

fix: do not fully disable , just visually hide it 
plus less redundant code 
![image](https://github.com/user-attachments/assets/56dea863-ddc5-48f7-8cb4-c4830bd9d642)


# Crosshair and first person Camera 

1. tagged the body parts and hands 
2. turned the vody parts invisible and render shadows only
3. tried putting them in a layer and viewing the hand layer but then it wouldnt as unchecking it in the culling mask would make the shadows also impossible to see
4. made sure there is a  60 degrree limitation by code:
   - xRotation -= mouseY;                                 // invert Y
   -xRotation = Mathf.Clamp(xRotation, -60f, 60f);       // clamp to ±60°
5. added the crosshair and made it scalble with any screen type and scaled to desktop size

![image](https://github.com/user-attachments/assets/4bd1b4c3-676f-4362-99ab-b7635178b365)

![image](https://github.com/user-attachments/assets/a51d0b03-8530-4ccd-b70b-fc2f60807ba9)

![image](https://github.com/user-attachments/assets/4404cf96-8f3e-453f-903d-55f5c3117df8)

![image](https://github.com/user-attachments/assets/645035ca-ff4b-4845-aa09-ad6377b484dd)

# Rock
scripts 
| Functionality                          | Script Component                  | Notes                                                                 |
| -------------------------------------- | --------------------------------- | --------------------------------------------------------------------- |
| Track and update number of rocks       | `RockInventory`                   | Attached to the player                                                |
| Detect left-click & throw rock forward | `RockThrower`                     | Uses camera’s forward direction to throw                              |
| Make rock fly & play shatter on impact | `RockProjectile`                  | Attached to the projectile prefab                                     |
| Play shatter **sound** & **animation** | `RockProjectile`                  | Triggered via `Animator.SetTrigger()` and `AudioSource.PlayOneShot()` |
| Refill inventory with right-click      | *(optional: `RockPickup` script)* | Placed on terrain rocks, can be added later                           |

1. added the shatter animation and sound in the `RockProjectile` script 
![image](https://github.com/user-attachments/assets/f7142d0a-8070-414b-aaf0-993e5f9f3456)

2. addded `RockThrower` to player to add throw and pick up logic
   
![image](https://github.com/user-attachments/assets/f7ba9b49-7593-4c55-9421-1791e90f46ad)

3. 


# HUD on Screen 
1. revised
2. 
   
# Detective 
1. normal animator, blend tree for walk and run , idle and throw normal states
2. rename the animations to be able to easily diferenciate
3. fixed the rigging , humaniod , and avtar from this model 
4. checked the avtar t pose to make sure there is no foot famus bug
5. removed all the has exit time
6. added a 'ThrowForce' event send int=1 at the relasing secound in the throw animation
7. and 'ThrowForce' event send int=0 at the rest arm position secound in the throw animation
8. add move logic script 'DetectiveMovement' integrating both using :

   | Component       | Assign This                                                         |
| --------------- | ------------------------------------------------------------------- |
| `Animator`      | Your detective's Animator                                           |
| `Rock Thrower`  | Reference to the same `RockThrower` script already on the character |
| `AudioSource`   | Footstep AudioSource                                                |
| `Footstep Clip` | The footstep sound                                                 |


![image](https://github.com/user-attachments/assets/2e16b2dd-349c-4322-972e-cfeb71be1c26)


![image](https://github.com/user-attachments/assets/127625f1-06ef-43e3-b8b9-92d95979fdec)

Walk/Run  is a blend tree controlled by prameter Velocity and triggered by wlak true/false , and the throw is controlled by a bol throw true/false , and there is a ThrowForce event that sends an int 1 at peack of animation and another event 0 when the hand is back to body level to simulate when the throw should actually throw

![image](https://github.com/user-attachments/assets/6c4dd7ae-7e0b-41cd-87af-24fb39acdd81)
![image](https://github.com/user-attachments/assets/36fff669-e2a5-495f-b4ee-2b6ab3dd1483)


# Spider
1. nav mesh agent on spider 
2. nav mesh surface on terrian and bake 
3. created animation
4.  created script 'Spider spawner'
5.   created script 'Spider controller'






![image](https://github.com/user-attachments/assets/edb1e4c3-3486-4440-ada1-83cafb91d31b)
![image](https://github.com/user-attachments/assets/ff409431-1c33-440f-8231-b0e9c7613af9)



Entry
│
├── Idle (Default State)
│   ├── Transition to Walk (when "IsWalking" = true)
│   
│
├── Walk/ Run (blend tree, velocity controlling)
│   ├── Transition to Idle (when "IsWalking" = false)
│   
│
├── Attack (Any State → Attack, interruptible)
│
├── Hit (Any State → Hit, interruptible)
│
├── Death1 (Any State → Death1, non-interruptible)
│
└── Death2 (Any State → Death2, non-interruptible)



Entry
│
├── Idle (Default State)
│   ├── Transition to Walk (when "IsWalking" = true)
│   
│
├── Walk/Run (Blend Tree)
│   ├── Parameter: "Velocity" (float)
│   │   - 0-5: Walk animation
│   │   - 5-10: Run animation
│   ├── Transition to Idle (when both bools false)
│   
│
├── Attack (Any State → Attack)
│   ├── Settings:
│   │   - Interruptible: Yes
│   │   - Can Transition To Self: Yes
│   │   - Has Exit Time: No
│
├── Hit (Any State → Hit)
│   ├── Settings:
│   │   - Interruptible: Yes
│   │   - Can Transition To Self: Yes
│   │   - Has Exit Time: No
│
├── Death1 (Any State → Death1)
│   ├── Settings:
│   │   - Interruptible: No
│   │   - Can Transition To Self: No
│   │   - Has Exit Time: No
│
└── Death2 (Any State → Death2)
    ├── Settings:
    │   - Interruptible: No
    │   - Can Transition To Self: No
    │   - Has Exit Time: No

![image](https://github.com/user-attachments/assets/2ed29217-38e0-4567-bce6-2633d7645ba0)
![image](https://github.com/user-attachments/assets/6b617c55-e0c9-4a43-8033-cde449f7c9c4)


#  BONUS :Cooper
1. code
2. code
3. animator 


![image](https://github.com/user-attachments/assets/bcaea6ce-3448-4837-a180-eccab4b6320d)

![image](https://github.com/user-attachments/assets/ac9cca8d-836b-413a-b919-62f815be594e)

# UI 
1. intalled the text pro packagdes 
![image](https://github.com/user-attachments/assets/2d606e23-e797-4deb-ad5e-ba9ad752d4a3)
2. creadted setup 
![image](https://github.com/user-attachments/assets/4bfdbe60-ecb4-4314-943c-47a912b9cbab)
3. created 2 graident colors for Stamina and health 
![image](https://github.com/user-attachments/assets/638311f6-74f3-43bd-b6bf-21098334318f)
![image](https://github.com/user-attachments/assets/7b667890-baa9-487e-8138-6bf50b0a6abe)
4. Final UI 
![image](https://github.com/user-attachments/assets/7a22a835-138b-4385-931e-6b55101951ba)


# Checks 
🎯 Immediate Action Plan (Step-by-step)
1.	Start with Spider-related scripts (SpiderController, SpiderSpawner, SpiderAnimationTester)
➤ Diagnose animation transitions, NavMeshAgent setup, attack triggers
2.	Then move to Cooper scripts (CooperController, CooperInputHandler)
➤ Check distance logic, input handling, bark on key find
3.	Follow with DetectiveMovement, Health, PlayerStamina
➤ Fix stamina drain, jump cost, and health-check-triggered restart
4.	Then UI/HUD logic
➤ Ensure all values dynamically update based on game events
5.	NavMesh final pass
➤ Confirm islands are baked, agents assigned, obstacles tagged
6.	Optional Bonus Checks
➤ Thunder/light delay logic
➤ Wind affecting trees visuall

1. fixed camera point of view
2.  made bark frequently even when searching , calling sound once and more smooth walk
3. fixing key to genrate clone on terrian
4. try to inegrate the entire ui sytem
5. integrate the stamena and jump logic
6. found bugs in throwing rock , no prefab and instant disaapper
7. animation full stopped after throwing the rock , try fix
8. created win and lose pannels
9. created try again putton 

# 7Antafa w game dev update 
![image](https://github.com/user-attachments/assets/b39abd34-7a14-4477-9c59-6904ee55725c)
![image](https://github.com/user-attachments/assets/cfcb8a4b-1f34-499b-9b4d-7ccc8a082470)


in game 
![image](https://github.com/user-attachments/assets/bf06c057-1696-4058-ae04-84b90f4b72c4)



