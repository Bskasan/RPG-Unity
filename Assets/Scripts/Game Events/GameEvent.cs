using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvent : ScriptableObject
{
    private HashSet<GameEventListener> _gameEventListeners = new HashSet<GameEventListener> ();   

    public void Register(GameEventListener gameEventListener) => _gameEventListeners.Add(gameEventListener);


}
