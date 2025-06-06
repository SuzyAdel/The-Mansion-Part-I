# The-Mansion-Part-I
# Terrian & Cloud 
1. added materials and layers on trian using the script 'TerrianLayers'
2. cloud rotates on y axis using script 'CloudSphereController'

![image](https://github.com/user-attachments/assets/322739c3-cee9-46e0-8ee6-b7b51aaf2271)


# SkyBox
1. added skyybox that rotates using the script 'SkyboxRotator'
   
![image](https://github.com/user-attachments/assets/56796bf1-1cfe-429e-9f3c-e1c27ebb2413)

#Water Shader 

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

