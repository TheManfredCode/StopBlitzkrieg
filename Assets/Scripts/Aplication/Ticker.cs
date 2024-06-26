using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ticker : Singleton<Ticker>
{
    private static Dictionary<uint, Coroutine> intervals;
    private static uint lastId;

    public static void Init()
    {
        intervals = new Dictionary<uint, Coroutine>();
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();
        intervals?.Clear();
    }

    public static uint SetInterval(Action function, float milliseconds)
    {
        return InstantiateInterval(function, milliseconds, true);
    }

    public static void ClearInterval(uint intervalId)
    {
        if (!intervals.ContainsKey(intervalId))
        {
            return;
        }

        if (!intervals.TryGetValue(intervalId, out var timer))
        {
            return;
        }

        Instance.StopCoroutine(timer);
        intervals.Remove(intervalId);
    }

    public static uint SetTimeout(Action function, float milliseconds)
    {
        return InstantiateInterval(function, milliseconds, false);
    }

    public static void ClearTimeout(uint timeoutId)
    {
        ClearInterval(timeoutId);
    }

    public static Coroutine CallOnNextFrame(Action action)
    {
        return Instance.StartCoroutine(WaitOneFrame(action));
    }

    public static void Dispose()
    {
        intervals.Clear();
    }

    private static IEnumerator WaitOneFrame(Action action)
    {
        yield return null;
        action();
    }

    private static uint InstantiateInterval(Action function, float milliseconds, bool infinite)
    {
        var id = lastId++; 
        Coroutine timer = Instance.StartCoroutine(Instance.CreateCoroutine(id, function, milliseconds, infinite));
        intervals.Add(id, timer);
        return id;
    }

    private IEnumerator CreateCoroutine(uint id, Action action, float milliseconds, bool infinite)
    {
        var timeSeconds = milliseconds / 1000;
        if (infinite)
        {
            while (true)
            {
                yield return new WaitForSeconds(timeSeconds);
                action?.Invoke();
            }
        }
        yield return new WaitForSeconds(timeSeconds);
        action?.Invoke();
        ClearTimeout(id);
    }
}