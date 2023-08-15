namespace DesignPatterns.Patterns.Singleton;

// Implementación del Singleton sin sincronización
public class SingletonWithoutLock
{
    private static SingletonWithoutLock instance = new SingletonWithoutLock();
    public static SingletonWithoutLock Instance => instance;
    public int Id { get; private set; }

    private SingletonWithoutLock()
    {
        Id = GetHashCode();
    }
}
