using UnityEngine;

[CreateAssetMenu(fileName = "PlayerTorchConfig", menuName = "Configs/PlayerTorch")]
public class PlayerTorchConfig : ScriptableObject
{
    public float WaterDamage => _waterDamage;
    public float AddFuelBonus => _addFuelBonus;
    public float RemoveFuelInSecond => _removeFuelInSecond;

    [SerializeField] private float _waterDamage;
    [SerializeField] private float _addFuelBonus;
    [SerializeField] private float _removeFuelInSecond;
}