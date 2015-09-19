namespace NpcGen.Interfaces
{
    public interface IAttribute<out T>
    {
        T Value { get; }
    }
}