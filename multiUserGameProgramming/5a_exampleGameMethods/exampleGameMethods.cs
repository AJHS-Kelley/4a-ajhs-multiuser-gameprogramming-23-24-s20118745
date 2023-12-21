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



flappy bird

float height
int score
string player name
array pipe heights
pipes have a gap of 60, then 40, 20, 10
jump += height
fall -= height

method jump/fall return height
method randomize pipes height
method take player name, default "Anonymous"
method check if height matches pipe
need variable for next pipe

for loop show nearby pipes
while loop hold game
*/



namespace ExampleGameMethods
{
    class ExampleGameMethods
    {
        static int Move(int height, int code)
        {
            //button press or text to move up random number of 10-20
            if (code == 1) {
                height += RandomInt(10,30);
            } else if (code == 0) {
                height -= RandomInt(10,30);
            } else if (code == 2) {
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
                "If you get hit once, you lose!\n\n"

            );
        }

        static int RandomInt(int min = 0, int max = 30)
        {
            //
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

            // for (int i = 0; i < pipes.Length; i++) {
            //     Console.WriteLine(pipes[i]);
            // }
            Instructions();
            
            while (true) {
                
                if (turn == 0) {
                    Console.WriteLine($"The next pipe has a gap of {pipes[score+1]+gap} to {pipes[score+1]}");
                } else if (turn == 3) {
                    win = CheckPipe(pipes,score,height,gap);
                    if (win == false) {
                        Console.WriteLine($"Your final score is {score}");
                        break;
                    } else {
                        score++;
                    }
                    turn = 0;
                    Console.WriteLine($"The next pipe has a gap of {pipes[score+1]+gap} to {pipes[score+1]}");
                }

                if (score > 10) {
                    gap = 40;
                } else if (score > 20) {
                    gap = 20;
                }

                

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