using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MapConfig", menuName = "Configs/Map")]
public class MapConfig : ScriptableObject
{
    public Vector2 ChankSize => _chankSize;
    public List<GameObject> LevelPrefabs => _levelPrefabs;
    public float MapSpeed => _mapSpeed;

    [SerializeField] private List<GameObject> _levelPrefabs;
    [SerializeField] private float _mapSpeed;
    [SerializeField] private Vector2 _chankSize;
}