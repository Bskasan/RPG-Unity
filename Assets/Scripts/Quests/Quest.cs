using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = " Quest ")]
public class Quest : ScriptableObject
{
    public List<Step> Steps;
}
