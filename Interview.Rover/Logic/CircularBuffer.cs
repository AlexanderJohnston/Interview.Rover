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
    public class CircularBuffer<T> : IEnumerable<T>
    {
        private int Pointer { get; set; }

        private List<T> Objects { get; set; }

        public T this[int i]
        {
            get => Objects[i];
            set => Objects.Insert(i, value);
        }

        public IEnumerator<T> GetEnumerator() => Objects.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public T Read() => this[Pointer];

        public void Forward()
        {
            if (Pointer == Objects.Count)
                Pointer = 0;
            else
                Pointer++;
        }

        public void Backward()
        {
            if (Pointer == 0)
                Pointer = Objects.Count;
            else
                Pointer--;
        }
    }
}