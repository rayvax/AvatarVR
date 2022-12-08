using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseScreen : MonoBehaviour
{
  [SerializeField] private Player _player;

  [SerializeField] private List<GameObject> _loseScreenObjects;

  private void OnEnable()
  {
    _player.Died += OnPlayerDied;
  }

  private void OnDisable()
  {
    _player.Died -= OnPlayerDied;
  }

  private void OnPlayerDied()
  {
    foreach (var obj in _loseScreenObjects)
    {
      obj.SetActive(true);
    }
  }
}
