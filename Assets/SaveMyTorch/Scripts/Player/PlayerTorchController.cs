using System.Collections;
using TMPro;
using UnityEngine;

public class PlayerTorchController : MonoBehaviour
{
    [SerializeField] private Light _lightInHand;
    [SerializeField] private Light _light;
    [SerializeField] private UnityEngine.UI.Image _torchHealth;
    [SerializeField] private GameObject _game;
    [SerializeField] private GameObject _gameover;
    [SerializeField] private TMP_Text _looseText;

    public float CurrentFuel => _currentFuel;

    [SerializeField] private PlayerTorchConfig _playerTorchConfig;
    [SerializeField] private float _currentFuel = 1;

    private float _startLightRange;
    private Coroutine _coroutine;

    private void Start()
    {
        _startLightRange = _lightInHand.range - 5;
        _coroutine = StartCoroutine(RemoveFuelEverySecond());
    }

    public void AddFuel()
    {
        ChangeTorchFuel(_playerTorchConfig.AddFuelBonus);

        if (_currentFuel > 1)
        {
            _currentFuel = 1;
            _lightInHand.range = _startLightRange;
            _light.range = _startLightRange;
            _torchHealth.fillAmount = _currentFuel;
        }
        else
        {
            ChangeTorchFuel(_playerTorchConfig.AddFuelBonus);
        } 
    }

    public void WaterDamage()
    {
        ChangeTorchFuel(-_playerTorchConfig.WaterDamage);

        if (_currentFuel <= 0) Gameover("Факел потух!");
    }

    public void HitAWall()
    {
        Gameover("Разбился об препятствие");
    }

    private void Gameover(string text)
    {
        Time.timeScale = 0;
        _gameover.SetActive(true);
        _game.SetActive(false);
        _looseText.text = text;
    }

    private void ChangeTorchFuel(float value)
    {
        _lightInHand.range += _startLightRange * value;
        _light.range += _startLightRange * value;
        _currentFuel += value;
        _torchHealth.fillAmount = _currentFuel;
    }

    private IEnumerator RemoveFuelEverySecond()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.25f);
            ChangeTorchFuel(-0.01f);
            if (_currentFuel <= 0) Gameover("Факел потух!");
        }
    }
}