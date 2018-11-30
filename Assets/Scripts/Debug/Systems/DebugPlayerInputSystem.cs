using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;

public class DebugPlayerInputSystem : ComponentSystem
{
    private struct DebugPlayerInputEntityFilter
    {
        public DebugPlayerInput InputComponent;
    }

    protected override void OnUpdate()
    {
        foreach( DebugPlayerInputEntityFilter entity in GetEntities<DebugPlayerInputEntityFilter>() )
        {
            DebugPlayerInput input = entity.InputComponent;

            input.Jump = false;

            input.Jump = ( Input.GetKeyDown( KeyCode.Space ) );
            input.Movement = new float2( Input.GetAxisRaw( "Horizontal" ), Input.GetAxisRaw( "Vertical" ) );
        }
    }
}