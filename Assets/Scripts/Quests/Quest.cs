using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = " Quest ")]
public class Quest : ScriptableObject
{
    [SerializeField] private string _name;
    [SerializeField] private string _description;
    [Tooltip("Designer / Programmer notes, not visible to player")]
    [SerializeField] private string _notes;

    public List<Step> Steps;
}
