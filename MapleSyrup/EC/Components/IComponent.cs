using Microsoft.Xna.Framework.Graphics;

namespace MapleSyrup.EC.Components;

public interface IComponent
{
    public IEntity Parent { get; }
    public ComponentFlag Flag { get; }
    void Clear();
    public static bool operator &(IEntity entity, IComponent component)
    {
        return (entity.CFlags & component.Flag) != 0;
    }
}