using DG.Tweening;
using System;
using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public event Action Jump_notifier;

    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private PlayerMovementConfig _playerMovementConfig;

    private PostionState _currentPlayerPosState = PostionState.Center;
    private bool _isJump;
    private Tween _jumpTween;
    private Tween _swipeTween;

    private void Awake()
    {
        _playerInput.LeftBtnClicked += GoToLeft;
        _playerInput.JumpBtnClicked += Jump;
        _playerInput.RightBtnClicked += GoToRight;
    }

    private void GoToLeft()
    {
        if (_currentPlayerPosState == PostionState.Left) return;
        if (_swipeTween != null && _swipeTween.IsPlaying()) return;

        _swipeTween = this.transform.DOMoveX(this.transform.position.x - _playerMovementConfig.StepLenght, _playerMovementConfig.StepDuration).SetEase(Ease.InOutExpo);
        _currentPlayerPosState -= 1;
    }

    private void Jump()
    {
        if (_isJump) return;
        if (_jumpTween != null && _jumpTween.IsPlaying()) return;

        _jumpTween = DOTween.Sequence()
            .Append(this.transform.DOMoveY(this.transform.position.y + _playerMovementConfig.JumpHeight, _playerMovementConfig.JumpDuration / 2).SetEase(Ease.OutCubic))
            .Append(this.transform.DOMoveY(this.transform.position.y, _playerMovementConfig.JumpDuration / 2).SetEase(Ease.InCubic));

        StartCoroutine(JumpTimer());

        Jump_notifier?.Invoke();
    }

    private void GoToRight()
    {
        if (_currentPlayerPosState == PostionState.Right) return;
        if (_swipeTween != null && _swipeTween.IsPlaying()) return;

        _swipeTween = this.transform.DOMoveX(this.transform.position.x + _playerMovementConfig.StepLenght, _playerMovementConfig.StepDuration).SetEase(Ease.InOutExpo);
        _currentPlayerPosState += 1;
    }

    private IEnumerator JumpTimer()
    {
        _isJump = true;
        yield return new WaitForSeconds(_playerMovementConfig.JumpDuration);
        _isJump = false;
    }

    private enum PostionState
    {
        Left,
        Center,
        Right
    }
}