# Funny platformer
2D platformer about TF2 characters (scout & heavy there)

Entry point location: ```Assets/Source/Code/Runtime/Infrastructure/Bootstrapper/LevelBootstrapper.cs```

## Idea of monobehaviour architecture
The point of monobehaviour architecture is that the game designer will assemble the components by himself.
F.i. Enemy is going to move via physics movement - game designer put ```PhysicsMovement``` component

### __Third party:__
   + VContainer
   + UniTask
   + Interfaces wrapper https://github.com/Thundernerd/Unity3D-SerializableInterface 
   + Scriptable objects
   + TextMeshPro
     
### ____Patterns:____ 
    - Observer
    - Finate state machine
    - Dependency injection
    - MVC
    - Template method
    - Strategy
