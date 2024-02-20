using System.Collections.Generic;
using UnityEngine;

public class ToggleablePanel : MonoBehaviour
{
    // Base class for all panels that can be toggled on and off
    private CanvasGroup _canvasGroup;
    private static HashSet<ToggleablePanel> _visiblePanels = new HashSet<ToggleablePanel>();

    public static bool IsVisible => _visiblePanels.Count > 0;

    private void Awake() 
    {
        _canvasGroup = GetComponent<CanvasGroup>();
        Hide();
    }

    protected void Show()
    {
        _visiblePanels.Add(this);
        _canvasGroup.alpha = 0.8f;
        _canvasGroup.interactable = true;
        _canvasGroup.blocksRaycasts = true;
    }

    public void Hide()
    {
        _visiblePanels.Remove(this);
        _canvasGroup.alpha = 0.0f;
        _canvasGroup.interactable = false;
        _canvasGroup.blocksRaycasts = false;
    }
}