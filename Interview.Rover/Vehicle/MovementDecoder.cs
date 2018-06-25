#region header

// Interview.Rover - MovementDecoder.cs
// 
// Authored by Alexander Johnston for practice and not intended to be used by anyone except for evaluation.
// 
// Created: 2018-06-24 8:53 PM

#endregion

using System.Collections.Generic;
using Interview.Rover.Exceptions;
using Interview.Rover.Grid;

namespace Interview.Rover.Vehicle
{
    internal class MovementDecoder
    {
        public Movement ConvertToInstruction(char instruction, int position)
        {
            switch (instruction)
            {
                case 'L':
                    return Movement.Left;
                case 'R':
                    return Movement.Right;
                case 'M':
                    return Movement.Forward;
                default:
                    throw new UnrecognizedMovementInstructionException(position);
            }
        }

        public IEnumerable<Movement> CreateMovementInstructions(string instructions)
        {
            var instructionSet = new char[instructions.Length];
            for (var i = 0; i < instructions.Length; i++)
            {
                var instruction = instructionSet[i];
                yield return ConvertToInstruction(instruction, i);
            }
        }
    }
}