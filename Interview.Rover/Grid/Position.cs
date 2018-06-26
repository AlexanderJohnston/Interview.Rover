#region header

// Interview.Rover - Position.cs
// 
// Authored by Alexander Johnston for practice and not intended to be used by anyone except for evaluation.
// 
// Created: 2018-06-24 9:00 PM

#endregion

using System;
using Interview.Rover.Exceptions;
using Interview.Rover.Logic;

namespace Interview.Rover.Grid
{
    internal class Position
    {
        /// <summary>
        ///     Construct this <see cref="Position" /> based on a specified <see cref="Frame" /> grid.
        /// </summary>
        /// <param name="grid">Position will initialize at the south-west (0,0) location on this <see cref="Frame" />.</param>
        /// <param name="facing">A <see cref="Compass" /> object to specify where the rover is initially facing.</param>
        public Position(Frame grid, Compass facing)
        {
            X = grid.X.Position;
            Y = grid.Y.Position;
            Facing = new Orientation(facing);
        }

        /// <summary>
        ///     Construct this <see cref="Position" /> based on a specific <see cref="Frame" /> grid at a specific starting
        ///     position.
        /// </summary>
        /// <param name="grid">Position will initalize based on this <see cref="Frame" />.</param>
        /// <param name="startingPosition">
        ///     The starting position is expected in "X Y Z" format, with Z being a
        ///     <see cref="Compass" /> direction.
        /// </param>
        public Position(Frame grid, string startingPosition)
        {
            try
            {
                var parsedX = int.TryParse(startingPosition.Substring(0, 1), out var x);
                var parsedY = int.TryParse(startingPosition.Substring(2, 1), out var y);
                var z = Convert.ToChar(startingPosition.Substring(4, 1));

                if (parsedX && parsedY)
                {
                    grid.X.Position = x;
                    grid.Y.Position = y;
                    Facing = new Orientation((Compass) z);
                    if ((Compass) z == Compass.North || (Compass) z == Compass.South)
                        CurrentAxis = grid.Y;
                    else
                        CurrentAxis = grid.X;
                }
                else
                {
                    throw new UnrecognizedStartingPositionException();
                }
            }
            catch (ArgumentNullException nullEx)
            {
                throw new UnrecognizedStartingPositionException(
                    "The starting position for this rover contains null characters.", nullEx);
            }
            catch (InvalidCastException castEx)
            {
                throw new UnrecognizedStartingPositionException(
                    "The starting position for this rover contains symbols which could not be case from the \"X Y Z\" format.",
                    castEx);
            }
            catch (OverflowException flowEx)
            {
                throw new UnrecognizedStartingPositionException(
                    "A buffer overflow was detected in the starting position commands for this rover. Char is below minvalue or above maxvalue.");
            }
        }

        /// <summary>
        ///     Considered to be a higher level object than <see cref="Dimension" /> and so it loosely depends on the
        ///     <see cref="Dimension.Position" /> property being initialized properly.
        /// </summary>
        public int X { get; private set; }

        /// <summary>
        ///     Considered to be a higher level object than <see cref="Dimension" /> and so it loosely depends on the
        ///     <see cref="Dimension.Position" /> property being initialized properly.
        /// </summary>
        public int Y { get; private set; }

        /// <summary>
        ///     Gets the current facing direction as a <see cref="char" /> compatible with the expected output of this program.
        /// </summary>
        public char Z => (char) Facing.Read;

        private Orientation Facing { get; } = new Orientation();

        /// <summary>
        ///     Used to reference the current axis for movement positions to be updated against.
        /// </summary>
        private Dimension CurrentAxis { get; set; }

        /// <summary>
        ///     Takes a <see cref="Movement" /> instruction and executes it against a <see cref="Frame" /> using the private
        ///     <see cref="Orientation" /> property of this <see cref="Position" />.
        /// </summary>
        /// <param name="instruction">A <see cref="Movement" /> enum specifying the action to take.</param>
        /// <param name="grid">A <see cref="Frame" /> object containing the dimensions along which a move can be executed.</param>
        public void Move(Movement instruction, Frame grid)
        {
            if ((instruction == Movement.Forward) && (Facing.Read == CurrentAxis.Forepoint))
                CurrentAxis.Forward();
            else if ((instruction == Movement.Forward) && (Facing.Read == CurrentAxis.Endpoint))
                CurrentAxis.Backward();
            else if (instruction == Movement.Left)
                Turn(grid, false);
            else if (instruction == Movement.Right)
                Turn(grid, true);

            X = grid.X.Position;
            Y = grid.Y.Position;
        }

        /// <summary>
        ///     Swaps the axis and re-orients the compass based on turning <see cref="Movement.Left" /> or
        ///     <see cref="Movement.Right" />.
        /// </summary>
        /// <param name="grid">
        ///     A frame from which this <see cref="Position" /> can reference its private reference to the current
        ///     <see cref="Dimension" /> of orientation.
        /// </param>
        /// <param name="clockwise">
        ///     Specifies whether or not this is a clockwise turn. Set to false for
        ///     <see cref="Movement.Left" /> and true for <see cref="Movement.Right" />.
        /// </param>
        private void Turn(Frame grid, bool clockwise)
        {
            if (CurrentAxis == grid.Y)
            {
                CurrentAxis = grid.X;
                Facing.Turn(clockwise);
            }
            else
            {
                CurrentAxis = grid.Y;
                Facing.Turn(clockwise);
            }
        }
    }
}
