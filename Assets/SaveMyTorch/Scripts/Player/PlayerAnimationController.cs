using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private string _jumpTriggerParameterName;

    private void Awake()
    {
        _playerMovement.Jump_notifier += Jump;
    }

    public void Jump()
    {
        _animator.Play("Run");
        _animator.SetTrigger(_jumpTriggerParameterName);
    }
}