namespace Task_1
{
    class Program
    {
        static ICalculate calculate = new Calculate();
        static Calc calc = new Calc(calculate);
        static Excep exxxxx = new Excep();

        public static void Main()
        { 
            exxxxx.EventsDel += Prints;

            while (true)
            {
                try
                {
                    Console.WriteLine("Введите первое число для сложение");
                    var a = Console.ReadLine();
                    Console.WriteLine("Введите второе число для сложение");
                    var b = Console.ReadLine();
                    exxxxx.Excc(int.Parse(a), int.Parse(b));

                }
                catch (FormatException ed)
                {
                    Console.WriteLine("Не корректный формат");
                }
            }
        }
        public static void Prints(int a , int b)
        {
            calc.Addtion(a, b);
        }
    }

    class Excep
    {
        public delegate void DeleExce(int a, int b); // delegat
        public event DeleExce EventsDel; //event
        public void Excc(int a, int b)
        {
            if (a.GetType() != typeof(int) && b.GetType() != typeof(int)) throw new FormatException();
            else EventsDel.Invoke(a, b);
        }
    }

    interface ICalculate // Интерфейс
    {
        void Addtions(int a, int b, int result);
    }
    class Calculate : ICalculate //Эта прокладка))
    {
        void ICalculate.Addtions(int a, int b, int result)
        {
            Console.WriteLine($"Результат сложение числа {a} и числа {b} равно {result}");
        }
    }
    class Calc // Метод исполнение <-
    {
        ICalculate calculate { get; }
        public Calc(ICalculate calculate) 
        {
            this.calculate = calculate;
        }

        public void Addtion(int a, int b) 
        {
            calculate.Addtions(a, b, a + b);
        }
    }
}