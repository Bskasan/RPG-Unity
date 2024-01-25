using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Ink.Runtime;

public class DialogController : MonoBehaviour
{
    [SerializeField] private TextAsset _dialog;
    [SerializeField] private TMP_Text _storyText;
    [SerializeField] private Button[] _choiceButtons;

    private Story _story;

    private void Start()
    {
        _story = new Story(_dialog.text);
    }
}
