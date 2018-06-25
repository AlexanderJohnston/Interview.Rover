#region header

// Interview.Rover - UnrecognizedMovementInstructionException.cs
// 
// Authored by Alexander Johnston for practice and not intended to be used by anyone except for evaluation.
// 
// Created: 2018-06-24 11:06 PM

#endregion

using System;

namespace Interview.Rover.Exceptions
{
    public class UnrecognizedMovementInstructionException : Exception
    {
        public UnrecognizedMovementInstructionException() : base(
            "Unknown problem with the input parameter containing movement instructions.")
        {
        }

        public UnrecognizedMovementInstructionException(string message) : base(message)
        {
        }

        public UnrecognizedMovementInstructionException(int position) : base(
            $"Unrecognized movement instruction at position {position} of the input parameter containing movement instructions.")
        {
        }
    }
}