using MarsRover.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverConsole
{
    class Program
    {
        //static int GridTopX = 5;
        //static int GridTopY = 5;
       
        static void Main(string[] args)
        {
            int GridTopX = 5;
            int GridTopY = 5;
            
            Console.WriteLine("Enter the upper right co-ordinates with a space between X and Y co-ordinates eg. 5 5");
            string TopXY = Console.ReadLine();
            var gridCoordinates = TopXY.Split(' ');
            GridTopX = Convert.ToInt32(gridCoordinates[0]);
            GridTopY = Convert.ToInt32(gridCoordinates[1]);

            MarsRoverInputModel inputLocation = new MarsRoverInputModel();
            Console.WriteLine("Enter the rover starting position with a space between X and Y co-ordinates and directon eg. 1 2 N");
            string roverStartingPosition = Console.ReadLine();
            var strartPosition = roverStartingPosition.Split(' ');
            inputLocation.Position.PositionX = Convert.ToInt32(strartPosition[0]);
            inputLocation.Position.PositionY = Convert.ToInt32(strartPosition[1]);
            inputLocation.Position.Heading = strartPosition[2];
            Console.WriteLine("Enter the move direction command");

            string moveDirection = Console.ReadLine();
            //inputLocation.Position.PositionX = 1;
            //inputLocation.Position.PositionY = 2;
            //inputLocation.Position.Heading = "N";
            //string moveDirection = "LMLMLMLMM";

            //inputLocation.Position.PositionX = 3;
            //inputLocation.Position.PositionY = 3;
            //inputLocation.Position.Heading = "E";
            //string moveDirection = "MMRMMRMRRM";


            var output = ExecuteCommand(inputLocation, moveDirection, GridTopX, GridTopY);
            Console.WriteLine("OutPut : " + inputLocation.Position.PositionX + " " + inputLocation.Position.PositionY + " " + inputLocation.Position.Heading);
            Console.Read();
        }
        public static MarsRoverInputModel ExecuteCommand(MarsRoverInputModel inputLocation, string moveDirection,int gridTopX,int gridTopY)
        {
            var commands = moveDirection.ToCharArray();
            foreach (char command in commands)
            {
                switch (command)
                {
                    case 'L':
                        switch (inputLocation.Position.Heading)
                        {
                            case "E":
                                inputLocation.Position.Heading = "N";
                                break;
                            case "N":
                                inputLocation.Position.Heading = "W";
                                break;
                            case "W":
                                inputLocation.Position.Heading = "S";
                                break;
                            case "S":
                                inputLocation.Position.Heading = "E";
                                break;
                        }
                        break;
                    case 'R':
                        switch (inputLocation.Position.Heading)
                        {
                            case "E":
                                inputLocation.Position.Heading = "S";
                                break;
                            case "N":
                                inputLocation.Position.Heading = "E";
                                break;
                            case "W":
                                inputLocation.Position.Heading = "N";
                                break;
                            case "S":
                                inputLocation.Position.Heading = "W";
                                break;
                        }
                        break;
                    case 'M':
                        inputLocation = Move(inputLocation,gridTopX,gridTopY);
                        break;
                }

                //Console.WriteLine("OutPut : " + inputLocation.Position.PositionX + " " + inputLocation.Position.PositionY + " " + inputLocation.Position.Heading);
            }
            return inputLocation;
        }
        public static MarsRoverInputModel Move(MarsRoverInputModel inputLocation, int gridTopX, int gridTopY)
        {

            string direction = inputLocation.Position.Heading;
            string move_direction = "";
            bool can_move = true;
            var currentPositionX = inputLocation.Position.PositionX;
            var currentPositionY = inputLocation.Position.PositionY;

            if (direction == "E" || direction == "W")
                move_direction = "X";
            else if (direction == "S" || direction == "N")
                move_direction = "Y";

            if (direction == "E" || direction == "N")
            {
                if (direction == "E")
                    if ((currentPositionX < 0 || (currentPositionX) > gridTopX))
                        can_move = false;

                if (direction == "N")
                    if (currentPositionY < 0 || (currentPositionY) > gridTopY)
                        can_move = false;

                if (can_move)
                {
                    if (move_direction == "X")
                        inputLocation.Position.PositionX += 1;
                    else
                        inputLocation.Position.PositionY += 1;
                }
            }
            else if (direction == "W" || direction == "S")
            {
                if (move_direction == "X" && currentPositionX > 0)
                    inputLocation.Position.PositionX -= 1;
                else if (move_direction == "Y" && currentPositionY > 0)
                    inputLocation.Position.PositionY -= 1;
            }

            return inputLocation;
        }
        //public List<MarsRoverInputModel> ProcessMultilineCommand(string command)
        //{
        //    string inputCommand = string.Empty;
        //    // Console.WriteLine("OutPut : " + inputLocation.Position.PositionX + " " + inputLocation.Position.PositionY + " " + inputLocation.Position.Heading);
        //    inputCommand = Console.ReadLine();
        //    string[] stringSeparators = new string[] { "\r\n" };
        //    var commands = inputCommand.TrimEnd().Split(stringSeparators, StringSplitOptions.None);
        //    List<MarsRoverInputModel> inputModels = new List<MarsRoverInputModel>();
        //    var gridDimensions = commands[0].Split(' ');  // First line sets the Battlefield dimensoins

        //    int GridX = int.Parse(gridDimensions[0]);
        //    int GridY = int.Parse(gridDimensions[1]);

        //    for (int i = 1; i < commands.Length; i += 2)
        //    {
        //        MarsRoverInputModel model = new MarsRoverInputModel();
        //        var postion = commands[i].Split(' ');
        //        model.Position.PositionX = int.Parse(postion[0]);
        //        model.Position.PositionY = int.Parse(postion[1]);
        //        model.Position.Heading = postion[2];
        //        model.Instructions = commands[i + 1];

        //        inputModels.Add(model);
        //    }
        //}
    }


}
