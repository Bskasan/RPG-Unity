using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Step
{
    [SerializeField] private string _instructions;

    public string Instructions => _instructions;
    public List<Objective> Objectives;

    public bool HasAllObjectivesCompleted()
    {
        return Objectives.TrueForAll(t => t.IsCompleted);
    }
}
