using System;
using UnityEngine;
using UnityEngine.Events;

public class GameEventListener : MonoBehaviour
{
    [SerializeField] private UnityEvent _unityEvent;

    public void RaiseEvent()
    {
        _unityEvent.Invoke();
    }
}