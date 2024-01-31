using System;
using UnityEngine;

[Serializable]
public class Objective
{
    [SerializeField] private ObjectiveType _objectiveType;

    public enum ObjectiveType
    { 
        Flag,
        Item,
        Kill,
    }
}