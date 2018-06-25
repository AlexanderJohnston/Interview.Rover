#region header

// Interview.Rover - Compass.cs
// 
// Authored by Alexander Johnston for practice and not intended to be used by anyone except for evaluation.
// 
// Created: 2018-06-24 9:53 PM

#endregion

namespace Interview.Rover.Logic
{
    public enum Compass
    {
        North = 'N',
        East = 'E',
        South = 'S',
        West = 'W'
    }

    public static class DefaultCompass
    {
        public static Compass[] Get()
        {
            return new Compass[] {Compass.North, Compass.East, Compass.South, Compass.West};
        }
    }
}