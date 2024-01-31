using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Step
{
    [SerializeField] private string _instructions;

    public List<Objective> Objectives;
}
