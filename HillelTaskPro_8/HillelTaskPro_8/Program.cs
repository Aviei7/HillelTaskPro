using System.Threading;
class Program
{

    static int waiting = 0;
    static int chairs = 2;
    static Mutex mute = new Mutex();
    static SemaphoreSlim customers = new SemaphoreSlim(0); //customers – подсчитывает количество посетителей, ожидающих в очереди
    static SemaphoreSlim barbers = new SemaphoreSlim(0); //barbers – обозначает количество свободных парикмахеров(в случае одного парикмахера его значения либо 0, либо 1)

    //Процедура barber() описывает поведение парикмахера (она включает в себя бесконечный цикл – ожидание клиентов и стрижку). 
    static void barber()
    {
        customers.Wait();
        barbers.Release();
        mute.WaitOne();
        try
        {
            waiting--;
        }
        finally
        {
            mute.ReleaseMutex();
        }
        Console.WriteLine($"Log 1 - Barber is working + waiting {waiting}");
        Thread.Sleep(10000);

    }

    //Процедура customer() описывает поведение посетителя. 
    static void Customer()
    {
        bool success;
        mute.WaitOne();
        try
        {
            //Клиент пришёл, проверил очередь. Если есть место - остался и начал ждать. Если нет места то просто ушёл(ничего не происходит)
            if (waiting < chairs)
            {
                waiting++;
                customers.Release();
                Console.WriteLine($"Log 2 - Client waiting + waiting now {waiting}");
            }
        }

        finally
        {
            mute.ReleaseMutex();
        }

        //Waiting client 30 sec. Если его нет 10 секунд то ожидание прерывается и уменьшаем переменную ожиданий
        success = barbers.Wait(5000);
        if (success)
        {
            Console.WriteLine("Log 3 - Client input to barber");
        }
        else
        {
            Console.WriteLine("Log 4 - Client leave, waiting > 2");
            mute.WaitOne();
            try
            {
                waiting--;
            }
            finally
            {
                mute.ReleaseMutex();
            }
        }


    }

    static void Main()
    {
        Thread t = new Thread(() =>
        {
            while (true)
                barber();
        });
        t.Start();

        Thread generator = new Thread(() =>
        {
            while (true)
            {
                Thread.Sleep(2300);
                Thread client = new Thread(Customer);
                client.Start();
            }
        });
        generator.Start();


    }

}

