namespace MapleSyrup.Resources.Nx;

public class NxVectorNode : NxNode
{
    private int x, y;
    public NxVectorNode(string name, int childId, int count, NodeType nType, int pointOne, int pointTwo)
        : base(name, childId, count, nType)
    {
        x = pointOne;
        y = pointTwo;
    }

    public int GetX()
    {
        return x;
    }

    public int GetY()
    {
        return y;
    }
}