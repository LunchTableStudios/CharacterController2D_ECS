namespace CharacterController2D
{
    using UnityEngine;
    using Unity.Entities;
    using Unity.Mathematics;

    [ UpdateBefore( typeof( UnityEngine.Experimental.PlayerLoop.FixedUpdate ) ) ]
    public class TransformSystem : ComponentSystem
    {
        private struct MovementEntityFilter
        {
            public readonly Velocity VelocityComponent;
            public Transform TransformComponent;
        }

        protected override void OnUpdate()
        {
            foreach( MovementEntityFilter entity in GetEntities<MovementEntityFilter>() )
            {
                Velocity velocity = entity.VelocityComponent;
                Transform transform = entity.TransformComponent;

                Vector3 movementVector = new Vector3( velocity.Delta.x, velocity.Delta.y, 0 );

                transform.Translate( movementVector );
            }
        }
    }
}