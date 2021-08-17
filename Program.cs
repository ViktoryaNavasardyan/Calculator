using System;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            bool endApp = false;
            Console.WriteLine("Console Calculator in C#");
            Console.WriteLine("------------------------\n");
            while (!endApp)
            {
                Console.WriteLine("Enter first number");
                double num1;
                String UserInput = Console.ReadLine();
                while (!double.TryParse(UserInput, out num1))
                {
                    Console.WriteLine("Not a valid number, try again.");

                    UserInput = Console.ReadLine();
                }
               
                string operation = EnterOperation();
                //Factorial_check
                if(operation == "!")
                    while (num1 < 0)
                    {
                        Console.WriteLine(@"The factorial of negative number doesn't exist.
Please enter number > 0.");
                        UserInput = Console.ReadLine();
                        while (!double.TryParse(UserInput, out num1))
                        {
                            Console.WriteLine("Not a valid number, try again.");

                            UserInput = Console.ReadLine();
                        }
                    }
                //second number
                double num2 = default;
                switch (operation)
                {
                    case "+":
                    case "-":
                    case "*":
                    case "/":
                    case "%":
                    case "mod":
                    case "^":
                        Console.WriteLine("Enter second number");
                        UserInput = Console.ReadLine();
                        while (!double.TryParse(UserInput, out num2))
                        {
                            Console.WriteLine("Not a valid number, try again.");

                            UserInput = Console.ReadLine();
                        }
                        break;
                }
           
                double result = 0;
                //calculate
                switch (operation)
                {
                    case "+":
                        result = Add(num1, num2);
                        break;
                    case "-":
                        result = Sub(num1, num2);
                        break;
                    case "*":
                        result = Multiply(num1, num2);
                        break;
                    case "/":
                        result = Divide(num1, num2);
                        break;
                    case "%":
                        result = Percent(num1, num2);
                        break;
                    case "mod":
                        result = Mod(num1, num2);
                        break;
                    case "sin":
                        result = Sin(num1);
                        break;
                    case "cos":
                        result = Cos(num1);
                        break;
                    case "tan":
                        result = Tan(num1);
                        break;
                    case "ctan":
                        result = CTan(num1);
                        break;
                    case "^":
                        result = Deg(num1, num2);
                        break;
                    case "sqrt":
                        result = Sqrt(num1);
                        break;
                    case "!":
                        result = Fac(num1);
                        break;
                    default:
                        break;
                }

                //print
                PrintResult(operation, num1, num2, result);

                Console.WriteLine("If you want to end calculating press 'e'. If not, press enter");
                string key = Console.ReadLine();
                if(Equals(key,"e"))
                {
                    endApp = true;
                }
            }
        }
        static double Add(double x, double y)
        {
            return x + y;
        }
        static double Sub(double x, double y)
        {
            return x - y;
        }
        static double Multiply(double x, double y)
        {
            return x * y;
        }
        static double Divide(double x, double y)
        {
            return x / y;
        }
        static double Percent(double x, double y)
        {
            return (x/100)*y;
        }
        static double Mod(double x, double y)
        {
            return x % y;
        }
        static double Sin(double x)
        {
            double radian = x * Math.PI / 180;
            return Math.Sin(radian);
        }
        static double Cos(double x)
        {
            double radian = x * Math.PI / 180;
            return Math.Cos(radian);
        }
        static double Tan(double x)
        {
            double radian = x * Math.PI / 180;
            return Math.Tan(radian);
        }
        static double CTan(double x)
        {
            return 1 / Tan(x);
        }
        static double Deg(double x, double y)
        {
            for(int i = 0; i < y - 1; i++)
            {
                x *= x;
            }
            return x;
        }
        static double Sqrt(double x)
        {
            return Math.Sqrt(x);
        }
        static double Fac(double x)
        {
            int fact = 1;
            for (int i = 1; i <= x; i++)
            {
                fact = fact * i;
            }
            return fact;
        }
        static string EnterOperation()
        {
            Console.WriteLine(@"Select operation:
                                             +   ->(x + y)
                                             -  ->(x - y)
                                             *   ->(x * y)
                                             /   ->(x / y)
                                             %   ->(y precent to x)
                                            mod  ->(x mod y)
                                            sin  ->(sin(x))
                                            cos  ->(cos(x))
                                            tan  ->(tan(x))
                                            ctan ->(ctan(x))
                                             ^   ->(x^y)
                                            sqrt ->(sqrt(x))
                                              !  ->(x!)");
            string operation = Console.ReadLine();
            while(operation != "+" && operation != "-" && operation != "*" && operation !="/"
                && operation != "%" && operation != "mod" && operation != "sin" && operation != "cos" && operation != "tan" && operation != "ctan"
                && operation != "^" && operation != "sqrt" && operation != "!")
            {
                Console.WriteLine("This is not an operation.Try again.");
                operation = Console.ReadLine();
            }
            return operation;
        }
        static void PrintResult(string operation, double num1, double num2, double result)
        {
            switch (operation)
            {
                case "+":
                case "-":
                case "*":
                case "/":
                case "%":
                case "mod":
                case "^":
                    Console.WriteLine($"{num1} {operation} {num2} = {result} ");
                    break;
                case "sin":
                case "cos":
                case "tan":
                case "ctan":
                case "sqrt":
                    Console.WriteLine($"{operation}({num1}) = {result} ");
                    break;
                case "!":
                    Console.WriteLine($"{num1}{operation} = {result} ");
                    break;
            }
        }
    }
    
}
