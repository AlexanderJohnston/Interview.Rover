#region header

// Interview.Rover - Control.cs
// 
// Authored by Alexander Johnston for practice and not intended to be used by anyone except for evaluation.
// 
// Created: 2018-06-24 8:51 PM

#endregion

using Interview.Rover.Grid;

namespace Interview.Rover.Vehicle
{
    internal class Control
    {
        /// <summary>
        ///     Constructs a two-dimensional control module with a <see cref="Frame" /> representing the grid and a
        ///     <see cref="Location" /> tracking its position.
        /// </summary>
        public Control() => Location = new Position(Grid);

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

        public string Locate() => $"{Location.X} {Location.Y} {Location.Z}";
    }
}