using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;

using CharacterController2D;

public class DebugPlayerJumpSystem : ComponentSystem
{
    private struct DebugPlayerMoveEntityFilter
    {
        public readonly DebugPlayerInput InputComponent;
        public readonly DebugPlayerJumpForce JumpComponent;
        public readonly CollisionData CollisionComponent;
        public Velocity VelocityComponent;
    }

    protected override void OnUpdate()
    {
        foreach( DebugPlayerMoveEntityFilter entity in GetEntities<DebugPlayerMoveEntityFilter>() )
        {
            DebugPlayerInput input = entity.InputComponent;
            DebugPlayerJumpForce jump = entity.JumpComponent;
            Velocity velocity = entity.VelocityComponent;
            CollisionData collisionData = entity.CollisionComponent;

            if( input.Jump && collisionData.Below )
            {
                velocity.Value.y = jump.Value;
            }
        }
    }
}