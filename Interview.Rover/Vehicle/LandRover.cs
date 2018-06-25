#region header

// Interview.Rover - LandRover.cs
// 
// Authored by Alexander Johnston for practice and not intended to be used by anyone except for evaluation.
// 
// Created: 2018-06-24 8:52 PM

#endregion

using System;
using System.Collections;
using System.Collections.Generic;

namespace Interview.Rover.Vehicle
{
    /// <summary>
    ///     This class is capable of executing movement instructions "L, M, R" and reporting its position.
    /// </summary>
    internal class LandRover
    {
        /// <summary>
        ///     Controls the vehicle's movement.
        /// </summary>
        private Control Controller { get; set; }

        /// <summary>
        ///     Decodes instructions from the program so they can be passed to the <see cref="Control" /> property.
        /// </summary>
        public MovementDecoder Decoder { get; set; } = new MovementDecoder();

        public string Name { get; set; } = "Mars Rover";

        /// <summary>
        ///     Moves the rover according to a given set of instructions.
        /// </summary>
        /// <param name="instructions">A string containing the chars 'L', 'M', and 'R'.</param>
        /// <returns>An <see cref="IEnumerable{string}"/> containing the formatted "X Y Z" current position.</returns>
        public string ExecuteInstructions(string instructions)
        {
            foreach (var instruction in Decoder.CreateMovementInstructions(instructions))
            {
                Controller.Move(instruction);
            }
            return GetPosition();
        }

        /// <summary>
        ///     Returns the expected output formatted position for this <see cref="LandRover"/>.
        /// </summary>
        /// <returns>A string formatted as "X Y Z" with Z being the current facing direction.</returns>
        public string GetPosition() => Controller.Locate();

        /// <summary>
        ///     Constructs this <see cref="LandRover"/> positioned at (0,0) in the <see cref="Control"/> module.
        /// </summary>
        public LandRover() => Controller = new Control();

        /// <summary>
        ///     Constructs this <see cref="LandRover"/> with its <see cref="Control"/> module set to a specific starting point.
        /// </summary>
        /// <param name="startingPosition"></param>
        public LandRover(string startingPosition) => Controller = new Control(startingPosition);
    }
}