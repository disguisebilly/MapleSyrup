using MapleSyrup.Core;
using MapleSyrup.Core.Event;
using MapleSyrup.ECS.Components;
using MapleSyrup.Subsystems;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MapleSyrup.ECS.Systems;

public class MovementSystem
{
    private readonly GameContext Context;
    public MovementSystem(GameContext context) 
    {
        Context = context;
        
        var events = Context.GetSubsystem<EventSystem>();
        events.Subscribe(this, EventType.OnSceneUpdate, OnUpdate);
    }

    private void OnUpdate(EventData eventData)
    {
        var keyboard = Keyboard.GetState();
        var scene = Context.GetSubsystem<SceneSystem>().Current;
        var camera = scene.Entities[0].GetComponent<Camera>();
        
        if (keyboard.IsKeyDown(Keys.W))
        {
            camera.Position.Y -= 5;
        }
        if (keyboard.IsKeyDown(Keys.S))
        {
            camera.Position.Y += 5;
        }
        if (keyboard.IsKeyDown(Keys.A))
        {
            camera.Position.X -= 5;
        }
        if (keyboard.IsKeyDown(Keys.D))
        {
            camera.Position.X += 5;
        }
    }
}