using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;

using CharacterController2D;

public class DebugPlayerMoveSystem : ComponentSystem
{
    private struct DebugPlayerMoveEntityFilter
    {
        public readonly DebugPlayerInput InputComponent;
        public readonly DebugPlayerMoveSpeed SpeedComponent;
        public Velocity VelocityComponent;
    }

    protected override void OnUpdate()
    {
        foreach( DebugPlayerMoveEntityFilter entity in GetEntities<DebugPlayerMoveEntityFilter>() )
        {
            DebugPlayerInput input = entity.InputComponent;
            DebugPlayerMoveSpeed speed = entity.SpeedComponent;
            Velocity velocity = entity.VelocityComponent;
            
            float targetVelocity = input.Movement.x * speed.Value;
            float acceleration = speed.GroundAcceleration;

            velocity.Value.x = Mathf.SmoothDamp( velocity.Value.x, targetVelocity, ref speed.Smoothing, acceleration );
        }
    }
}