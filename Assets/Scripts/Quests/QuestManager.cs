using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    [SerializeField] private object _questPanel;

    private List<Quest> _activeQuests;

    public void AddQuest(Quest quest)
    {
        _activeQuests.Add(quest);
        _questPanel.SelectQuest(quest);
    }
}
