#region header

// Interview.Rover - Program.cs
// 
// Authored by Alexander Johnston for practice and not intended to be used by anyone except for evaluation.
// 
// Created: 2018-06-24 8:47 PM

#endregion

using System;
using System.IO;
using Interview.Rover.Vehicle;

namespace Interview.Rover
{
    internal class Program
    {
        private static void Main(string[] args)
        {

        }

        private static void ExecuteAndLogToFile(LandRover rover, string movementInstructions, string filename)
        {
            var file = new FileStream($"{AppDomain.CurrentDomain.BaseDirectory}{filename}.txt", FileMode.OpenOrCreate);
            var consoleOutput = Console.Out;
            using (var sWriter = new StreamWriter(file))
            {
                Console.SetOut(sWriter);

            }
        }

        private static LandRover InitializeRover(string startingPosition)
        {
            LandRover rover = new LandRover();

        }

    }
}