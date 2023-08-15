namespace DesignPatterns.Patterns.Singleton;

// Implementación del Singleton con sincronización utilizando 'lock'
public class SingletonWithLock
{
    private static SingletonWithLock? instance = null;
    private static readonly object lockObject = new();
    public static SingletonWithLock GetInstance
    {
        get
        {
            if (instance == null)
            {
                instance = new SingletonWithLock();
            }
            return instance;
        }
    }

    public static SingletonWithLock GetInstanceWithLock
    {
        get
        {
            lock (lockObject)
            {
                if (instance == null)
                {
                    instance = new SingletonWithLock();
                }
                return instance;
            }
        }
    }

    public int Id { get; private set; }

    private SingletonWithLock()
    {
        Id = GetHashCode();
    }
}