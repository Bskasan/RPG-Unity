using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(menuName = " Quest ")]
public class Quest : ScriptableObject
{
    [SerializeField] private string _displayName;
    [SerializeField] private string _description;

    [Tooltip("Designer / Programmer notes, not visible to player")]
    [SerializeField] private string _notes;
    [SerializeField] private Sprite _sprite;
    
    private int _currentStepIndex = 0;

    public List<Step> Steps;

    public Sprite Sprite => _sprite;

    public string DisplayName => _displayName;
    public string Description => _description;

    public void TryProgress()
    {
        var currentStep = GetCurrentStep();
        if (currentStep.HasAllObjectivesCompleted())
        { 
            _currentStepIndex++;
            // do whatever we do when a quest progresses like update the UI

        }
    }


    private Step GetCurrentStep() => Steps[_currentStepIndex];
}
