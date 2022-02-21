using System;
using System.Collections.Generic;

public class Signal 
{
    private event Action _callback;

    public void AddListener(Action handler)
    {
        #if UNITY_EDITOR
        UnityEngine.Debug.Assert(handler.Method.GetCustomAttributes(typeof(System.Runtime.CompilerServices.CompilerGeneratedAttribute), inherit: false).Length == 0,
            "Adding anonymous delegates as Signal callbacks is not supported (you wouldn't be able to unregister them later).");
        #endif
        _callback += handler;
    }

    public void RemoveListener(Action handler)
    {
        _callback -= handler;
    }

    public void Invoke()
    {
        _callback.Invoke();
    }
}

public class Signal<T>
{
    private event Action<T> _callback;

    public void AddListener(Action<T> handler)
    {
        #if UNITY_EDITOR
        UnityEngine.Debug.Assert(handler.Method.GetCustomAttributes(typeof(System.Runtime.CompilerServices.CompilerGeneratedAttribute), inherit: false).Length == 0,
            "Adding anonymous delegates as Signal callbacks is not supported (you wouldn't be able to unregister them later).");
        #endif
        _callback += handler;
    }

    public void RemoveListener(Action<T> handler)
    {
        _callback -= handler;
    }

    public void Invoke(T arg1)
    {
        _callback.Invoke(arg1);
    }
}

public class Signal<T, U>
{
    private event Action<T, U> _callback;

    public void AddListener(Action<T, U> handler)
    {
        #if UNITY_EDITOR
        UnityEngine.Debug.Assert(handler.Method.GetCustomAttributes(typeof(System.Runtime.CompilerServices.CompilerGeneratedAttribute), inherit: false).Length == 0,
            "Adding anonymous delegates as Signal callbacks is not supported (you wouldn't be able to unregister them later).");
        #endif
        _callback += handler;
    }

    public void RemoveListener(Action<T, U> handler)
    {
        _callback -= handler;
    }

    public void Invoke(T arg1, U arg2)
    {
        _callback.Invoke(arg1, arg2);
    }
}