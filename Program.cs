public class Program
{
    public static void Main()
    {
        Semaphore semaphoreObject = new Semaphore(initialCount: 3, maximumCount: 3, name: "PrinterApp");
        Printer printerObject = new Printer();

        Console.WriteLine("Press enter to exit\n");
        for (int i = 0; i < 20; ++i)
        {
            int j = i;
            Task.Factory.StartNew(() =>
            {
                semaphoreObject.WaitOne();
                printerObject.Print(j);
                semaphoreObject.Release();
            });
        }
        Console.ReadLine();
    }
}

class Printer
{
    public void Print(int documentToPrint)
    {
        Console.WriteLine("Printing document: " + documentToPrint);
        Thread.Sleep(TimeSpan.FromSeconds(5));
    }
}