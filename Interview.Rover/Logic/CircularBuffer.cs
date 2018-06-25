#region header

// Interview.Rover - CircularBuffer.cs
// 
// Authored by Alexander Johnston for practice and not intended to be used by anyone except for evaluation.
// 
// Created: 2018-06-24 9:08 PM

#endregion

using System.Collections;
using System.Collections.Generic;

namespace Interview.Rover.Logic
{
    /// <summary>
    ///     This circular buffer can be turned clockwise and counter-clockwise.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class CircularBuffer<T> : IEnumerable<T>
    {
        /// <summary>
        ///     Visualize the "Direction Of Travel" on a compass as this pointer. The magnetic needle is just the mechanism for
        ///     moving left/right.
        ///     This means the pointer will always be the direction you are facing.
        /// </summary>
        private int Pointer { get; set; }

        private List<T> Objects { get; } = new List<T>();

        public T this[int i]
        {
            get => Objects[i];
            set => Objects.Insert(i, value);
        }

        public IEnumerator<T> GetEnumerator() => Objects.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public T Read() => this[Pointer];

        /// <summary>
        ///     Turns the contents of the circular buffer clockwise by moving the pointer. The buffer itself is not turning.
        ///     Visualize this as moving all elements in the array to the left by 1.
        /// </summary>
        public void Forward()
        {
            //  Go around the right edge and arrive at the left side of buffer.
            if (Pointer == (Objects.Count - 1))
                Pointer = 0;
            else
                Pointer++;
        }

        /// <summary>
        ///     Turns the circular buffer counter-clockwise.
        ///     Visualize this as moving all elements in the array to the right by 1.
        /// </summary>
        public void Backward()
        {
            // Go around th left edge and arrive at the right side of buffer.
            if (Pointer == 0)
                Pointer = Objects.Count - 1;
            else
                Pointer--;
        }
    }
}