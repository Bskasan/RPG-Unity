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
    [SerializeField] private TextAsset _dialog;
    [SerializeField] private TMP_Text _storyText;
    [SerializeField] private Button[] _choiceButtons;

    private Story _story;

    [ContextMenu("Start Dialog")]
    public void StartDialog()
    {
        _story = new Story(_dialog.text);
        RefreshView();
    }

    private void RefreshView()
    {
        StringBuilder storyTextBuilder = new StringBuilder();

        while(_story.canContinue) 
            storyTextBuilder.AppendLine(_story.Continue());

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
}
