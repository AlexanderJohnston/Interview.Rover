#region header

// Interview.Rover - Dimension.cs
// 
// Authored by Alexander Johnston for practice and not intended to be used by anyone except for evaluation.
// 
// Created: 2018-06-24 8:58 PM

#endregion

using Interview.Rover.Logic;

namespace Interview.Rover.Grid
{
    /// <summary>
    ///     Provides a logical dimensions on the <see cref="Grid" /> using points located at the theoretical limit of each
    ///     <see cref="Compass" /> value.
    ///     This can also be thought of as a standard geometric line between two points.
    /// </summary>
    internal class Dimension
    {
        /// <summary>
        ///     Construct the dimension using a starting and ending point on the <see cref="Compass" />.
        /// </summary>
        /// <param name="forepoint">The theoretical starting point, e.g. <see cref="Compass.North" />.</param>
        /// <param name="endpoint">The theoretical ending point, e.g. <see cref="Compass.South" />.</param>
        public Dimension(Compass forepoint, Compass endpoint)
        {
            Forepoint = forepoint;
            Endpoint = endpoint;
        }

        /// <summary>
        ///     Contains the theoretical starting point of this dimension on a grid.
        /// </summary>
        public Compass Forepoint { get; }

        /// <summary>
        ///     Contains the theoretical ending point of this dimension on a grid.
        /// </summary>
        public Compass Endpoint { get; }

        /// <summary>
        ///     Considered to be a deeper level position than the <see cref="Grid.Position" /> object. It has a loose dependency on this
        ///     being initialized to some value. You can also change this value at will and it should be carried uwpard.
        /// </summary>
        public int Position { get; set; }

        public void Forward() => Position++;

        public void Backward() => Position--;
    }
}