#region header

// Interview.Rover - LandRover.cs
// 
// Authored by Alexander Johnston for practice and not intended to be used by anyone except for evaluation.
// 
// Created: 2018-06-24 8:52 PM

#endregion

using System;

namespace Interview.Rover.Vehicle
{
    internal class LandRover
    {
        /// <summary>
        ///     Controls the vehicle's movement.
        /// </summary>
        private Control Controller { get; } = new Control();

        /// <summary>
        ///     Decodes instructions from the program so they can be passed to the <see cref="Control" /> property.
        /// </summary>
        public MovementDecoder Decoder { get; set; } = new MovementDecoder();

        public string Name { get; set; } = "Mars Rover";

        /// <summary>
        ///     Moves the rover according to a given set of instructions.
        /// </summary>
        /// <param name="instructions">A string containing the chars 'L', 'M', and 'R'.</param>
        public void ExecuteInstructions(string instructions)
        {
            foreach (var instruction in Decoder.CreateMovementInstructions(instructions))
            {
                Controller.Move(instruction);
                Console.WriteLine();
            }
        }

        /// <summary>
        ///     Returns the expected output "X Y Z" formatted position for this <see cref="LandRover"/>.
        /// </summary>
        /// <returns></returns>
        public string GetPosition() => Controller.Locate();
    }
}