namespace Task_2
{
    internal class Calculate : ICalculate
    {
        ILogger logger { get; }
        public Calculate(ILogger logger) 
        {
            this.logger = logger;
        }
        int ICalculate.Addtion(int a, int b)
        {
            logger.Succes("Успех");
            return a + b;
        }
    }
}
