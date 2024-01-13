using MapleSyrup.Map;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MapleSyrup.EC.Components;

public class AnimationComponent : IComponent
{
    public IEntity Parent { get; }
    public ComponentFlag Flag { get; }
    private List<(Vector2 position, Vector2 origin, Texture2D texture)> _frames;
    private List<int> _delays;
    private int _currentFrame = 0;
    private int _delay = 0;

    public AnimationComponent(IEntity parent)
    {
        Parent = parent;
        Flag = ComponentFlag.Animation;
        _frames = new();
        _delays = new();
    }

    public void AddFrame(Vector2 position, Vector2 origin, Texture2D texture)
    {
        _frames.Add((position, origin, texture));
    }

    public void AddDelay(int delay)
    {
        _delays.Add(delay);
    }

    public void NextFrame()
    {
        if (_currentFrame >= _frames.Count - 1)
            _currentFrame = 0;
        _currentFrame++;
        Parent.Transform.Position = _frames[_currentFrame].position;
        Parent.Transform.Origin = _frames[_currentFrame].origin;
        ((MapObj)Parent).Texture = _frames[_currentFrame].texture;
    }

    public bool Advance(float timeDelta)
    {
        if (_delay <= 0)
        {
            _delay = _delays[_currentFrame];
            return true;
        }

        _delay -= (int)timeDelta;
        return false;
    }
}