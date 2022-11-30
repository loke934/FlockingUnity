# Flocking behavior in Unity

## The main focus was to make the flocking behavior modular, so it would be easy for designers to alter and adjust behaviors desired for the flock. 
Scriptable objects were used for this, making it possible to change behavior in the inspector and have different flocks have different behaviors, for example, 
basic behavior or a behavior with added rules. 

- Has the three base rules of cohesion, alignment, and separation/avoidance. 
- One rule for keeping the boids within a given radius. 
- Filtered behavior making it possible for boids to distinguish other boids from other flocks, so not grouping with them and a filter to avoid obstacles. 
