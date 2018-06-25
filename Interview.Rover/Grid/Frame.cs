#region header

// Interview.Rover - Frame.cs
// 
// Authored by Alexander Johnston for practice and not intended to be used by anyone except for evaluation.
// 
// Created: 2018-06-24 8:58 PM

#endregion

using Interview.Rover.Logic;

namespace Interview.Rover.Grid
{
    internal class Frame
    {
        public Dimension X { get; set; } = new Dimension(Compass.East, Compass.West);

        public Dimension Y { get; set; } = new Dimension(Compass.North, Compass.South);
    }
}