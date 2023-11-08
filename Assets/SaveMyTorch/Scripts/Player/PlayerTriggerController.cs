using UnityEngine;

public class PlayerTriggerController : MonoBehaviour
{
    [SerializeField] private PlayerTorchController _playerTorchController;
    [SerializeField] private string _torchFuelTag;
    [SerializeField] private string _waterTag;
    [SerializeField] private string _wallTag;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(_torchFuelTag))
        {
            TakeTorchFuel(other.gameObject);
        }
        else if (other.CompareTag(_waterTag))
        {
            WaterCollision();
        }
        else if (other.CompareTag(_wallTag))
        {
            _playerTorchController.HitAWall();
        }
    }

    private void TakeTorchFuel(GameObject torch)
    {
        _playerTorchController.AddFuel();
        Destroy(torch);
    }

    private void WaterCollision()
    {
        _playerTorchController.WaterDamage();
    }
}