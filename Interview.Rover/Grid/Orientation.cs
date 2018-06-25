#region header

// Interview.Rover - Orientation.cs
// 
// Authored by Alexander Johnston for practice and not intended to be used by anyone except for evaluation.
// 
// Created: 2018-06-24 9:01 PM

#endregion

using System;
using System.Linq;
using Interview.Rover.Logic;

namespace Interview.Rover.Grid
{
    /// <summary>
    ///     Provides orientation functionality traditional to the circular compass rose. This will contain as many directions
    ///     as are available in the <see cref="Compass" /> value.
    /// </summary>
    internal class Orientation
    {
        /// <summary>
        ///     Construct an Orientation using a circular buffer populated with the compass rose.
        /// </summary>
        public Orientation()
        {
            // Create a default compass facing North.
            int position = 0;
            foreach (Compass direction in Enum.GetValues(typeof(Compass)))
            {
                CircularCompass[position] = direction;
                position++;
            }
        }

        public Orientation(Compass initialFacing)
        {
            // Create a default compass facing North.
            int position = 0;
            var directions = DefaultCompass.Get();
            foreach (Compass direction in directions)
            {
                CircularCompass[position] = direction;
                position++;
            }

            // Move the current position to the start of the circular queue to set the starting direction.
            if (initialFacing == Compass.East)
            {
                CircularCompass.Forward();
            }
            else if (initialFacing == Compass.South)
            {
                CircularCompass.Forward();
                CircularCompass.Forward();
            }
            else if (initialFacing == Compass.West)
            {
                CircularCompass.Backward();
            }
        }

        /// <summary>
        ///     Tracks the current facing value of this <see cref="Orientation" />. Updated on each <see cref="Turn(bool)" />.
        /// </summary>
        private Compass Facing { get; set; } = Compass.North;

        /// <summary>
        ///     Provides forward, backward, and read capabilities. Acts as a buffer for the rotation logic.
        /// </summary>
        private CircularBuffer<Compass> CircularCompass { get; } = new CircularBuffer<Compass>();

        /// <summary>
        ///     Retrieve the current direction of this <see cref="Orientation" /> as a <see cref="Compass" /> value.
        /// </summary>
        public Compass Read => CircularCompass.Read();

        /// <summary>
        ///     Turns the compass using a bi-directional circular buffer.
        /// </summary>
        /// <param name="clockwise">Set bool to true for clockwise rotation or false for counter-clockwise rotation.</param>
        public void Turn(bool clockwise)
        {
            if (clockwise)
                CircularCompass.Forward();
            else
                CircularCompass.Backward();
            Facing = CircularCompass.Read();
        }
    }
}