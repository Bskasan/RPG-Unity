using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Ink.Runtime;
using System;
using System.Text;

public class DialogController : MonoBehaviour
{ 
    [SerializeField] private TMP_Text _storyText;
    [SerializeField] private Button[] _choiceButtons;
    [SerializeField] private Animator _animator;
     
    private Story _story;
    private CanvasGroup _canvasGroup;

    private void Awake() => _canvasGroup = GetComponent<CanvasGroup>();

    [ContextMenu("Start Dialog")]
    public void StartDialog(TextAsset _dialog)
    {
        _story = new Story(_dialog.text);
        RefreshView();
        ToggleCanvasOn();
    }

    private void ToggleCanvasOn()
    {
        _canvasGroup.alpha = 0.8f;
        _canvasGroup.interactable = true;
        _canvasGroup.blocksRaycasts = true;
    }

    private void ToggleCanvasOff()
    {
        _canvasGroup.alpha = 0.0f;
        _canvasGroup.interactable = false;
        _canvasGroup.blocksRaycasts = false;
    }

    private void RefreshView()
    {
        StringBuilder storyTextBuilder = new StringBuilder();

        while (_story.canContinue)
        {
            storyTextBuilder.AppendLine(_story.Continue());
            HandleTags();
        }
           

        _storyText.SetText(storyTextBuilder);

        for (int i = 0; i < _choiceButtons.Length; i++)
        {
            var button = _choiceButtons[i];
            button.gameObject.SetActive(i < _story.currentChoices.Count);
            button.onClick.RemoveAllListeners();
            if (i < _story.currentChoices.Count)
            { 
                Choice choice = _story.currentChoices[i]; 
                button.GetComponentInChildren<TMP_Text>().SetText(choice.text);
                button.onClick.AddListener(() =>
                {
                    _story.ChooseChoiceIndex(choice.index);
                    RefreshView();
                });
            }
        }

        
    }

    private void HandleTags()
    { 
        foreach(var tag in _story.currentTags) 
        {
            Debug.Log(tag);
            if (tag.StartsWith("E."))
            {
                string eventName = tag.Remove(0, 2);
                GameEvent.RaiseEvent(eventName);
            }
        }
    }

    
}
