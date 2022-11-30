# Flocking behavior in Unity

The main focus was to make the flocking behavior modular, so it would be easy for designers to alter and adjust behaviors desired for the flock. 
Scriptable objects were used for this, making it possible to change behavior in the inspector and have different flocks have different behaviors, for example, 
basic behavior or a behavior with added rules. 

- Has the three base rules of cohesion, alignment, and separation/avoidance. 
- One rule for keeping the boids within a given radius. 
- Filtered behavior making it possible for boids to distinguish other boids from other flocks, so not grouping with them and a filter to avoid obstacles. 


![BehaviorsInspector](https://user-images.githubusercontent.com/76095991/204749025-35a684a2-7a1a-4508-a81c-a7665429da94.png)
![UnityBoids](https://user-images.githubusercontent.com/76095991/204749221-164c291e-d32b-4ecd-912a-cf75229f7951.gif)

A simplified version was implemented with C++ and Unreal 5 for a game project. 

![BoidUE5](https://user-images.githubusercontent.com/76095991/204750511-efb3f4d0-56fa-46c7-86ee-231e440fa999.gif)
