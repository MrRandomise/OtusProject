using System;
using UnityEngine;

public enum U31PanelAnimation
{
    None,
    Fade,
    Jump,
    Swipe
}

public class U31Panel : MonoBehaviour
{
    // panel animation type
    public U31PanelAnimation panelAnimation;

    public GameObject panelRoot;

    private bool _animating;
    private Action _callback;
    private CanvasGroup _canvasGroup;
    private Animator _animator;

    void Awake()
    {
        if (panelRoot == null)
        {
            Debug.LogError("Please assign 'panelRoot' field.");
            return;
        }

        _canvasGroup = panelRoot.GetComponent<CanvasGroup>();
        _animator = panelRoot.GetComponent<Animator>();
        if (_canvasGroup == null || _animator == null)
        {
            Debug.LogError("Please add CanvasGroup & Animator " +
                            "components to 'panelRoot' game object.");
            return;
        }

        panelRoot.SetActive(false);
    }

    public void OnAnimationEvent(string eventName)
    {
        if (eventName == "ShowAnimationComplete" ||
            eventName == "HideAnimationComplete")
        {
            if (eventName == "HideAnimationComplete")
                panelRoot.SetActive(false);

            _animating = false;

            if (_callback != null)
                _callback();
            _callback = null;
        }
    }

    public void ShowPanel(Action callback)
    {
        togglePanel(callback, false);
    }

    public void HidePanel(Action callback)
    {
        togglePanel(callback, true);
    }

    private void togglePanel(Action callback, bool isHide)
    {
        if (_animating)
            return;

        _animating = true;
        _callback = callback;

        panelRoot.SetActive(true);

        string animName = string.Format("{0}{1}",
                                panelAnimation.ToString(),
                                isHide ? "Out" : "In");
        _animator.Play(animName);
    }
}
