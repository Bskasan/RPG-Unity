using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Game Event")]
public class GameEvent : ScriptableObject
{
    private HashSet<GameEventListener> _gameEventListeners = new HashSet<GameEventListener> ();   

    public void Register(GameEventListener gameEventListener) => _gameEventListeners.Add(gameEventListener);
    public void DeRegister(GameEventListener gameEventListener) => _gameEventListeners.Remove(gameEventListener);

    public void Invoke()
    {
        foreach (GameEventListener gameEventListener in _gameEventListeners)
            gameEventListener.RaiseEvent();
    }


}
