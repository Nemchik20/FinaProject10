namespace Task_2 
{
    class Program
    {
        static ILogger log = new Loger(); 
        static ICalculate calc = new Calculate(log);

        static CheckedInputForNumber ece = new CheckedInputForNumber();

        public static void Main()
        {
            ece.eventNum += Print;
            while(true)
            {
                try
                {
                    Console.WriteLine("Введите число 1");
                    var a = Console.ReadLine();
                    Console.WriteLine("Введите число 2");
                    var b = Console.ReadLine();
                    ece.Check(a, b);
                }
                catch(FormatException)
                {
                    log.Error("Ошибка не верный формат");
                }
            }
        }

        public static void Print(int a, int b)
        {
            Console.WriteLine($"Результат сложение = {calc.Addtion(a, b)}");
        }
    }

    interface ICalculate
    {
        int Addtion(int a, int b);
    }  //Интефейс калькулятора

    interface ILogger
    {
        void Succes(string message);
        void Error(string message);
    } //Интефейс логера

    class Loger : ILogger // Логер пишет 
    {
        void ILogger.Succes(string message) 
        {
            Console.BackgroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.BackgroundColor= ConsoleColor.Black;
        }
        void ILogger.Error(string message)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.BackgroundColor = ConsoleColor.Black;
        }
    } 
    class CheckedInputForNumber
    {
        public delegate void DeleNum (int a, int b);
        public event DeleNum eventNum;
        public void Check(string a, string b)
        {
            try
            {
                eventNum.Invoke(Convert.ToInt32(a), Convert.ToInt32(b));
            }
            catch
            {
                throw new FormatException();
            }
        }
    }
}