#region header

// Interview.Rover - UnrecognizedStartingPositionException.cs
// 
// Authored by Alexander Johnston for practice and not intended to be used by anyone except for evaluation.
// 
// Created: 2018-06-24 11:06 PM

#endregion

using System;

namespace Interview.Rover.Exceptions
{
    public class UnrecognizedStartingPositionException : Exception
    {
        public UnrecognizedStartingPositionException() : base(
            "Unknown problem with the input parameter containing the starting position for this rover.")
        {
        }

        public UnrecognizedStartingPositionException(string message) : base(message)
        {
        }

        public UnrecognizedStartingPositionException(string message, Exception innerException) : base(message,
            innerException)
        {
        }

        public UnrecognizedStartingPositionException(int position, string startingPosition) : base(
            $"Unrecognized starting location at position {position} of the input \"{startingPosition}\".")
        {
        }
    }
}