using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircularArray<T> {

    private T[] _array;

    private int _position;

    public CircularArray(T[] array)
    {
        this._array = array;
        _position = 0;
    }

    public int Position()
    {
        return _position;
    }

    public T Current()
    {
        return _array[_position];
    }

    public void Next()
    {
        if (_position == _array.Length - 1)
        {
            _position = 0;
            return;
        }
        _position++;
    }

    public T PeakNext()
    {
        this.Next();
        return _array[_position];
    }

    public T PeakPrevious()
    {
        this.Previous();
        return _array[_position];
    }

    public void Previous()
    {
        if (_position == 0)
        {
            _position = _array.Length - 1;
            return;
        }
        _position--;
    }

    public T[] GetArray()
    {
        return _array;
    }
}
