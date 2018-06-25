#region header

// Interview.Rover - Control.cs
// 
// Authored by Alexander Johnston for practice and not intended to be used by anyone except for evaluation.
// 
// Created: 2018-06-24 8:51 PM

#endregion

using Interview.Rover.Grid;
using Interview.Rover.Logic;

namespace Interview.Rover.Vehicle
{
    /// <summary>
    ///     Controls the vehicle's movement over a grid while tracking the current location.
    /// </summary>
    internal class Control
    {
        /// <summary>
        ///     Constructs a two-dimensional control module with a <see cref="Frame" /> representing the grid and a
        ///     <see cref="Position" /> object tracking its location from (0,0).
        /// </summary>
        public Control() => Location = new Position(Grid, Compass.North);

        /// <summary>
        ///     Constructs a two-dimensional control module with a <see cref="Frame" /> representing the grid and a
        ///     <see cref="Position"/> set to a specific starting point.
        /// </summary>
        /// <param name="startingPosition"></param>
        public Control(string startingPosition) => Location = new Position(Grid, startingPosition);

        /// <summary>
        ///     A <see cref="Frame"/> grid which this controller can use to execute movement instructions against its <see cref="Position"/>.
        /// </summary>
        private Frame Grid { get; } = new Frame();

        /// <summary>
        ///     Initialized in the constructor because it relies on the private <see cref="Frame" /> of this class being
        ///     constructed.
        /// </summary>
        private Position Location { get; }

        /// <summary>
        ///     Moves this vehicle along its own internal mapping of the world as a grid.
        /// </summary>
        /// <param name="instruction">
        ///     A <see cref="Movement" /> instruction to be executed against the internal constructed model
        ///     of the world.
        /// </param>
        public void Move(Movement instruction) => Location.Move(instruction, Grid);

        /// <summary>
        ///     Gets the "X Y Z" formatted output of this vehicle's position.
        /// </summary>
        /// <returns>A string in the format of "X Y Z" with Z as the current facing direction.</returns>
        public string Locate() => $"{Location.X} {Location.Y} {Location.Z}";
    }
}