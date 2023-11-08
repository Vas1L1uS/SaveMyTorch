using System;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public event Action LeftBtnClicked;
    public event Action JumpBtnClicked;
    public event Action RightBtnClicked;

    public void ClickOnLeftButton()
    {
        LeftBtnClicked?.Invoke();
    }

    public void ClickOnJumpButton()
    {
        JumpBtnClicked?.Invoke();
    }

    public void ClickOnRightButton()
    {
        RightBtnClicked?.Invoke();
    }
}
