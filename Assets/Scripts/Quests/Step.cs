using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Step
{
    [SerializeField] private string _instructions;

    public string Instructions => _instructions;
    public List<Objective> Objective;

    public bool HasAllObjectivesCompleted()
    {
        return Objective.TrueForAll(t => t.IsCompleted);
    }
}
