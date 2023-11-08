using UnityEngine;

[CreateAssetMenu(fileName = "PlayerMovementConfig", menuName = "Configs/PlayerMovement")]
public class PlayerMovementConfig : ScriptableObject
{
    public float JumpHeight => _jumpHeight;
    public float JumpDuration => _jumpDuration;
    public float StepLenght => _stepLenght;
    public float StepDuration => _stepDuration;
    public float RunSpeed => _runSpeed;

    [SerializeField] private float _jumpHeight;
    [SerializeField] private float _jumpDuration;
    [SerializeField] private float _stepLenght;
    [SerializeField] private float _stepDuration;
    [SerializeField] private float _runSpeed;
}