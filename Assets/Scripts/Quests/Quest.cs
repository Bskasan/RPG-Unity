using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(menuName = " Quest ")]
public class Quest : ScriptableObject
{
    [FormerlySerializedAs("_name")][SerializeField] private string _displayName;
    [SerializeField] private string _description;

    [Tooltip("Designer / Programmer notes, not visible to player")]
    [SerializeField] private string _notes;
    [SerializeField] private Sprite _sprite;

    public List<Step> Steps;

    public string DisplayName => _displayName;
    public string Description => _description;

    public Sprite Sprite => _sprite;

    public void TryProgress()
    {
        
    }
}
