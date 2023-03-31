namespace Assets.Scripts.Interfaces
{
    public interface IUniqueGenerator<T>
    {
        T GetUnique(T min, T max);
    }
}