#region header

// Interview.Rover - Program.cs
// 
// Authored by Alexander Johnston for practice and not intended to be used by anyone except for evaluation.
// 
// Created: 2018-06-24 8:47 PM

#endregion

using System;
using System.IO;
using System.Linq;
using Interview.Rover.Vehicle;

namespace Interview.Rover
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                ShowHelp();
                return;
            }

            var cmdArgs = new CommandLineArguments();
            if (args[0].ToLower().Contains("help") || (args[0].ToLower().Contains("man") && !File.Exists(args[0])))
            {
                ShowHelp();
                return;
            }

            cmdArgs.ParseInstructions(args[0]);

            var outputFileName = $"{AppDomain.CurrentDomain.BaseDirectory}";
            if (args[1].Length > 0)
                outputFileName = args[1];
            else
                outputFileName += "output.txt";

            //  Iterates over all current rovers imported from file-based command arguments.
            for (var currentRover = 0; currentRover < cmdArgs.StartingPositions.Count; currentRover++)
            {
                var rover = InitializeRoverAtPosition(cmdArgs.StartingPositions.ElementAt(currentRover));
                ExecuteAndLogToFile(rover, cmdArgs.MovementInstructions.ElementAt(currentRover), outputFileName);
            }
        }

        /// <summary>
        ///     Outputs the <see cref="Console" /> to a file located in the <see cref="AppDomain" /> base directory.
        /// </summary>
        /// <param name="rover">A <see cref="LandRover" /> to be moved.</param>
        /// <param name="movementInstructions">A list of instructions to be passed to the <see cref="LandRover" />.</param>
        /// <param name="fileName">
        ///     The name of the file containing output strings which report the <see cref="LandRover" /> current
        ///     position after each instruction.
        /// </param>
        private static void ExecuteAndLogToFile(LandRover rover, string movementInstructions, string fileName)
        {
            FileStream file;
            if (File.Exists(fileName))
                file = new FileStream($"{fileName}", FileMode.Append);
            else
                file = new FileStream($"{fileName}", FileMode.OpenOrCreate);
            var consoleOutput = Console.Out;
            using (var sWriter = new StreamWriter(file))
            {
                //  Trace the console out to the file.
                Console.SetOut(sWriter);
                var currentPos = rover.ExecuteInstructions(movementInstructions);
                Console.WriteLine(currentPos);

                //  Restore the original console output.
                Console.SetOut(consoleOutput);
            }
        }

        private static void ShowHelp()
        {
            Console.WriteLine(@"Welcome to the Mars Rover interview challenge.
This program was built by Alexander Johnston and submitted 2018-25-06.

HOW TO USE:
---
The first argument should contain the fully qualified path to your input instructions as a plaintext file.
The second argument specifies an output file, otherwise the program will output to the AppDomain's base directory.

EX: .\Interview.Rover.exe C:\Working\RoverInstructions.txt C:\Working\Output.txt

INSTRUCTIONS FORMAT:
---
MaxX MaxY           <- Only include this once at the top of the file to determine boundaries.
PosX PosY FaceZ     <- You can include one starting position per Rover, but this line can be repeated after the next one for multiple rovers.
LMRLMRLMRLMRLMRLMR  <- You can include only one movement set for each rover, but you can include as many rovers as you want.

MaxX = maximum X coordinate
MaxY = maximum Y coordinate
PosX = starting position X
PosY = starting position Y
FaceZ = facing direction ['N, E, S, W'] <- Choose one

EX: 5 1 N
    LMLMLMLMM

OUTPUT:
---
CurrentPosX CurrentPosY CurrentFaceZ

EX: 1 3 E

");
        }

        private static LandRover InitializeRoverDefault() => new LandRover();

        private static LandRover InitializeRoverAtPosition(string startingPosition) => new LandRover(startingPosition);
    }
}
