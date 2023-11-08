using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    [SerializeField] private MapConfig _mapConfig;
    [SerializeField] private Transform _chanksParrent;
    [SerializeField] private float _deletePosZ;
    [SerializeField] private List<Transform> _chanks;

    private void Update()
    {
        MoveAllChanks();

        if (CheckFirstChunkOnDeletePos())
        {
            Destroy(_chanks.First().gameObject);
            _chanks.Remove(_chanks.First());
            SpawnNewChank();
        }
    }

    private void SpawnNewChank()
    {
        _chanks.Add(Instantiate(GetRandomChank(), _chanks.Last().transform.position + Vector3.forward * _mapConfig.ChankSize.y, Quaternion.identity, _chanksParrent).transform);
    }

    private GameObject GetRandomChank()
    {
        return _mapConfig.LevelPrefabs[Random.Range(0, _mapConfig.LevelPrefabs.Count)];
    }

    private void MoveAllChanks()
    {
        foreach (var chank in _chanks)
        {
            chank.transform.Translate(Vector3.back * _mapConfig.MapSpeed * Time.deltaTime);
        }
    }

    private bool CheckFirstChunkOnDeletePos()
    {
        if (_chanks.First().position.z <= _deletePosZ) return true;
        return false;
    }
}