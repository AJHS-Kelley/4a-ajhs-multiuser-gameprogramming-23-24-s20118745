// Example Game Methods, Alexander Jones, 12-19-2023 v0.0
using System;

/*
Your code should include the following items:
· At least five different variables that are correctly named. [10 Points Each / 50 Total]
o At least one integer variable.
o At least one float variable.
o At least one string variable.
o At least one Boolean variable.
o At least one variable must be an array.
· Use of at least two different assignment operators. [10 Points Each / 20 Total]
o Assignment Operators: =, +=, -=, *=, /=, and %=
· At least four different methods. [25 Points Each / 100 Total]
o Each method should have a comment with a brief description of what the method does, what parameters it requires, and what value it returns.
o At least one method should have no return value.
o At least one method should have a return value.
o At least one method should require output from another method to execute.
o At least one method must require at least two parameters.
o At least one method should have a default parameter defined.
o For each method, the first time you define it, use the pass keyword in the method body before you write any code. MAKE SURE YOUR GITHUB COMMIT SHOWS the pass keyword in your method.
· Use of at least one if / elif / else block to allow code to make decisions. [25 Points]
o The logic in your if / elif / else block should be correct.
· Use at least one while loop. [25 Points]
· Use at least one for loop to iterate through an array. [25 Points]
· Frequent use of comments to explain variables and methods. [25 Points]

*/



namespace ExampleGameMethods
{
    class ExampleGameMethods
    {
        static int Move(int height, int code)
        {
            //uses "code" to pick which move to make
            if (code == 1) {
                //jump
                height += RandomInt(10,30);
            } else if (code == 0) {
                //fall
                height -= RandomInt(10,30);
            } else if (code == 2) {
                //glide
                height -= RandomInt(0, 15);
            }

            return height;
        }

        static void Instructions()
        {
            Console.WriteLine(
                "Welcome to Text Flappy Bird\n"+
                "Here you must make sure you fly through a series of pipes without being hit\n"+
                "The controls are simple:\n"+
                "'W' to Fly up a random number from 10 - 30\n"+
                "'S' to Fall down a random number from 10 - 30\n"+
                "'D' to Glide, falling by a random number from 0 - 15\n"+
                "'Q' to Quit\n"+
                "You'll get 3 turns to change your position\n"+
                "If you get hit once, you lose!\n\n"

            );
        }

        static int RandomInt(int min = 0, int max = 30)
        {
            //random number generator
            int randomNumber;
            Random rndNum = new Random();
            randomNumber = rndNum.Next(min, max);
            // Console.WriteLine(randomNumber);

            return randomNumber;
        }

        static bool CheckPipe(int[] pipes, int score, int height, int gap)
        {
            //check if player height is within pipe minimum and gap
            int newPipe = pipes[score+1];
            if (height > newPipe && height < (newPipe+gap)) {
                Console.WriteLine("You made it through the pipe!");
                return true;
            } else {
                Console.WriteLine("You hit the pipe! Game Over");
                return false;
            }
        }

        static void Main(string[] args)
        {
            int height = 50;
            int score = 0;
            int gap = 60;
            int turn = 0;
            bool win = true;
            int[] pipes = {0, RandomInt(20,70), RandomInt(20,70), RandomInt(20,70), RandomInt(20,70), RandomInt(20,70), RandomInt(20,70), RandomInt(20,70)};

            Instructions();
            
            while (true) {
                

                if (turn == 0) {
                    //show next pipe gap every first turn
                    Console.WriteLine($"The next pipe has a gap of {pipes[score+1]} to {pipes[score+1]+gap}");
                } else if (turn == 3) {
                    win = CheckPipe(pipes,score,height,gap);
                    //lose game if you don't make it through the pipe
                    if (win == false) {
                        Console.WriteLine($"Your final score is {score}");
                        break;
                    } else {
                        score++;
                        Console.WriteLine(score);
                    }
                    turn = 0;
                    Console.WriteLine($"The next pipe has a gap of {pipes[score+1]} to {pipes[score+1]+gap}");
                }
                
                //key presses
                char key = Char.ToLower(Console.ReadKey(true).KeyChar);
                if (key == 'w') {
                    height = Move(height, 1);
                    Console.WriteLine($"Your current height is {height}");
                    // CheckPipe(pipes,score,height,gap);
                    turn++;
                } else if (key == 's') {
                    height = Move(height, 0);
                    Console.WriteLine($"Your current height is {height}");
                    // CheckPipe(pipes,score,height,gap);
                    turn++;
                } else if (key == 'd') {
                    height = Move(height, 2);
                    Console.WriteLine($"Your current height is {height}");
                    // CheckPipe(pipes,score,height,gap);
                    turn++;
                } else if (key == 'q') {
                    break;
                }



            }

        }
    }
}