#region header

// Interview.Rover - CommandLineArguments.cs
// 
// Authored by Alexander Johnston for practice and not intended to be used by anyone except for evaluation.
// 
// Created: 2018-06-25 4:40 PM

#endregion

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Interview.Rover.Grid;
using Interview.Rover.Logic;

namespace Interview.Rover
{
    public class CommandLineArguments
    {
        /// <summary>
        ///     Determines the size of the grid and is populated by <see cref="ParseGridSize" />.
        ///     Formatted as "X Y".
        ///     This parameter isn't actually used because I don't have enough information to decide if it's necessary.
        ///     There is not an acceptable output listed in the challenge for "fell off the grid", so I'm going to process instructions
        ///     as if the grid is infinite or theoretical.
        /// </summary>
        public int[] GridSize { get; set; } = {0, 0};

        /// <summary>
        ///     A list of starting positions for rovers in the form "X Y Z" with Z being a <see cref="Compass" />
        /// </summary>
        public List<string> StartingPositions { get; set; } = new List<string>();

        /// <summary>
        ///     A list of movement instructions for rovvers of any length, containing commands 'L', 'M', and 'R'.
        /// </summary>
        public List<string> MovementInstructions { get; set; } = new List<string>();

        /// <summary>
        ///     Parses out both starting positions and movement instructions.
        ///     Items must be weaved so that each starting position is followed by movement instructions.
        ///     For example: 1 2 1 2 1 2 1 2, with 1 being starting position and 2 being movement instruction.
        /// </summary>
        /// <param name="args">Ordered sets of positions and movement instructions.</param>
        public void ParseInstructions(string pathToFile)
        {
            try
            {
                using (StreamReader sReader = new StreamReader(pathToFile))
                {
                    string gridSize = sReader.ReadLine(); // Unused currently.
                    while (sReader.Peek() >= 0)
                    {
                        StartingPositions.Add(sReader.ReadLine());
                        MovementInstructions.Add(sReader.ReadLine());
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Could not read the input file {pathToFile}.");
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        ///     Parses grid instructions from "MaxX MaxY" format "X Y" to their respective values in <see cref="GridSize"/>.
        /// </summary>
        /// <param name="size">A string formatted as "X Y" with the integers representing maximum grid length along that axis.</param>
        public void ParseGridSize(string size)
        {
            var x = size.Substring(0, 1);
            var y = size.Substring(2, 1);
            if (int.TryParse(x, out var X))
                GridSize[0] = X;
            if (int.TryParse(y, out int Y))
                GridSize[1] = Y;
        }
    }
}