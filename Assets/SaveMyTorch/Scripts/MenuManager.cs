using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject _menu;
    [SerializeField] private GameObject _game;

    public void StartGame()
    {
        _game.SetActive(true);
        _menu.SetActive(false);
    }
}