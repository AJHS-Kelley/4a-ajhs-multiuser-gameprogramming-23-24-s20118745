// Alexander Jones, Program Template, v0.5
using System;

namespace UpdateForEachProgram
{
    class UpdateForEachProgram
    {



        static void MyMethod()
        {
            Console.WriteLine("I Like Mine with lettuce and tomatoes, Heinz 57, and french fried potatoes.\n");
        }
        // static -- This method belongs to the current class, it is NOT an object
        // void -- This method has no return value.

        static int DoubleUp()
        {
            int sum = 0;
            Console.WriteLine("This method will double a number and return it.\n");
            Console.WriteLine("Please enter a number on the next line.\n");
            sum = System.Convert.ToInt32(Console.ReadLine());
            //sum *= 2;
            //Console.WriteLine(sum);
            return sum *= 2;
        }

        // Mthods with Parameters

        static void MakePancakes(int num)
        {
            for (int i = 0; i < num; i++)
            {
                Console.WriteLine("One golden, fluffy pancake coming up1\n");
            }
        }




static void MakeEggs(int num, string style)
{
    Console.WriteLine("You have ordered" + num + "eggs cooked " + style + ".\n");
}



        static void Main(string[] args
        {

            //MyMethod();
            //DoubleUp();
            MakePancakes();
            MakeEggs(10, "sunny side up");
        }
        
        
        
        )

                return 0;
            
        }


        static void Main(string[] args)
        {
            MyMethod();

        }
    }
}