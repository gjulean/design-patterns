namespace DesignPatterns.Patterns.Singleton;

public class SingletonLogger
{
    public static void DemonstrateSingletonWithoutLock()
    {
        // En esta sección, se muestra el uso de la clase LogWithInstace que implementa el patrón Singleton sin utilizar sincronización. 
        // Esto significa que la instancia única del objeto se crea al declarar la variable estática 'log', 
        // y esta instancia se reutiliza en todo el programa. Cada vez que se accede a 'log', se obtiene la misma instancia del objeto.
        // Como resultado, los dos mensajes "Instance Id:" en la salida serán idénticos, lo que demuestra que solo existe una única instancia en todo el programa.
        var log = SingletonWithoutLock.Instance;

        Console.WriteLine(log.Id);
        Console.WriteLine(log.Id);

        Console.WriteLine();
        Console.WriteLine("------------------------------------");
        Console.WriteLine();
    }

    public static void DemonstrateSingletonWithLock()
    {
        // En esta sección, se muestran dos bloques de tareas que utilizan la clase LogWithGetInstance que también implementa el patrón Singleton. 
        // En el primer bloque, la propiedad estática GetInstance se utiliza para obtener la instancia del objeto. 
        // Sin embargo, esto puede causar problemas de concurrencia en entornos multi-hilo, 
        // porque dos hilos podrían verificar que _instance es nulo y crear nuevas instancias del objeto, lo que resultaría en múltiples instancias del objeto.
        // Para solucionar este problema, el segundo bloque de tareas utiliza la propiedad estática GetInstanceWithLock, 
        // que utiliza un bloque 'lock' para garantizar la sincronización y asegurar que solo se cree una única instancia del objeto 
        // incluso en un entorno multi-hilo.
        int firstNumThreads = 5;

        Task[] firstTasks = new Task[firstNumThreads];
        for (int i = 0; i < firstNumThreads; i++)
        {
            firstTasks[i] = Task.Run(() =>
            {
                SingletonWithLock logger = SingletonWithLock.GetInstance;
                Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} - Instance Id: {logger.Id}");
            });
        }

        Task.WaitAll(firstTasks);

        Console.WriteLine();
        Console.WriteLine("------------------------------------");
        Console.WriteLine();

        // En esta sección, se muestra cómo la propiedad GetInstanceWithLock soluciona el problema de concurrencia mencionado anteriormente.
        // Al usar el bloque 'lock' en la propiedad GetInstanceWithLock, se garantiza que solo un hilo puede acceder a la creación de la instancia a la vez. 
        // Esto previene la creación de múltiples instancias en un entorno multi-hilo, asegurando que solo exista una única instancia del objeto Singleton.
        // Cada vez que se imprime "Instance Id:", se muestra el mismo identificador, lo que demuestra que solo existe una instancia del objeto en todo el programa.
        int secondNumThreads = 5;

        Task[] secondTasks = new Task[secondNumThreads];
        for (int i = 0; i < secondNumThreads; i++)
        {
            secondTasks[i] = Task.Run(() =>
            {
                SingletonWithLock logger = SingletonWithLock.GetInstanceWithLock;
                Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} - Instance Id: {logger.Id}");
            });
        }

        Task.WaitAll(secondTasks);

        Console.WriteLine();
        Console.WriteLine("------------------------------------");
        Console.WriteLine();
    }
}
