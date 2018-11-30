using UnityEngine;
using Unity.Entities;
using CharacterController2D;

[ UpdateAfter( typeof( GravitySystem ) ) ]
public class WallClingingSystem : ComponentSystem
{
    private struct WallClingingEntityFilter
    {
        public readonly WallClinging WallClingingComponent;
        public readonly CollisionData CollisionComponent;
        public Velocity VelocityComponent;
    }

    protected override void OnUpdate()
    {
        foreach( WallClingingEntityFilter entity in GetEntities<WallClingingEntityFilter>() )
        {
            WallClinging wallClinging = entity.WallClingingComponent;
            CollisionData collisionData = entity.CollisionComponent;
            Velocity velocity = entity.VelocityComponent;

            wallClinging.Clinging = false;

            if( !collisionData.Below && ( collisionData.Right || collisionData.Left ) )
            {
                if( velocity.Value.y < -wallClinging.MaximumVelocity )
                    velocity.Value.y = -wallClinging.MaximumVelocity;

                wallClinging.Clinging = true;
            }
        }
    }
}