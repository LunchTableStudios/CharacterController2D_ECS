using UnityEngine;
using Unity.Entities;
using CharacterController2D;

public class WallJumpSystem : ComponentSystem
{
    private struct WallClingingEntityFilter
    {
        public readonly WallClinging WallClingingComponent;
        public readonly WallJump WallJumpComponent;
        public readonly DebugPlayerInput InputComponent;
        public readonly CollisionData CollisionComponent;
        public Velocity VelocityComponent;
    }

    protected override void OnUpdate()
    {
        foreach( WallClingingEntityFilter entity in GetEntities<WallClingingEntityFilter>() )
        {
            WallClinging wallClinging = entity.WallClingingComponent;
            WallJump wallJump = entity.WallJumpComponent;
            DebugPlayerInput input = entity.InputComponent;
            CollisionData collisionData = entity.CollisionComponent;
            Velocity velocity = entity.VelocityComponent;

            if( wallClinging.Clinging )
            {
                float direction = ( collisionData.Left ) ? 1 : -1;

                if( input.Jump )
                {
                    wallClinging.Clinging = false;

                    velocity.Value.x += ( wallJump.Force.x ) * direction;
                    velocity.Value.y += wallJump.Force.y;
                }
            }
        }
    }
}