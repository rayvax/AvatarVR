using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanternSpawner : MonoBehaviour
{
  [Header("Lantern")]
  [SerializeField] private Lantern _lanternPrefab;
  [SerializeField] private Transform _lanternsParent;

  [Header("Spawn params")]
  [SerializeField] private float _spawnPeriod = 1;
  [SerializeField] private float _spawnCircleRadius = 1;

  private float _elapsedTime;
  private bool _needSpawn = true;

  private void Update()
  {
    if (!_needSpawn) return;

    _elapsedTime += Time.deltaTime;

    if (_elapsedTime >= _spawnPeriod)
    {
      _elapsedTime = 0;
      SpawnLantern();
    }
  }

  public void SetNeedSpawn(bool value)
  {
    _needSpawn = value;
  }

  private void SpawnLantern()
  {
    // Vector3 toCircleVector = (Random.Range(-1f, 1f) * Vector3.forward + Random.Range(-1f, 1f) * Vector3.right) * _spawnCircleRadius;
    float randomAngle = Random.Range(0, 2f);
    float cs = Mathf.Cos(randomAngle);
    float sn = Mathf.Sin(randomAngle);

    Vector2 toCircleVector = Random.insideUnitCircle.normalized * _spawnCircleRadius;
    Vector3 lanternPosition = transform.position
                              + new Vector3(toCircleVector.x, 0, toCircleVector.y);

    Instantiate(_lanternPrefab, lanternPosition, Quaternion.identity, _lanternsParent);
  }
}
