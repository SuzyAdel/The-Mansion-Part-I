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
![image](https://github.com/user-attachments/assets/876ad7aa-548e-47df-ae48-cac5ab069bd7)

![image](https://github.com/user-attachments/assets/68ddab96-d5ff-4088-be00-9d80bfb1b972)

![image](https://github.com/user-attachments/assets/9be33f65-b081-4c50-9e63-0cd147d05815)


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
![image](https://github.com/user-attachments/assets/596e5037-3aa4-4a8b-a058-76980307ed5e)



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



# Rock

# HUD on Screen 

# Detective 

# Spider 

# Cooper

# Checks 

# 7Antafa w game dev update 

