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
