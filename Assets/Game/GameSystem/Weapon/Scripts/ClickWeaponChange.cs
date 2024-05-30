using OtusProject.PlayerInput;
using OtusProject.View;
using System;
using TMPro;
using UnityEngine;
using Zenject;

public class ClickWeaponChange : IDisposable
{
    private CharacterInputController _controller;

    [Inject]
    void construct(CharacterInputController controller)
    {
        _controller = controller;
        ItemsView.OnClickItemsView += ChangeButton;
    }

    public void ChangeButton(string key)
    {
        if (key[0] >= '0' && key[0] <= '9')
            key = "Alpha" + key;
        var keyCode = (KeyCode)Enum.Parse(typeof(KeyCode), key);
        _controller.KeyboardPress(keyCode);
    }

    public void Dispose()
    {
        ItemsView.OnClickItemsView -= ChangeButton;
    }
}
