using System.Collections.Generic;
using UnityEngine;

public class WinScreen : MonoBehaviour
{
  [SerializeField] private Player _player;

  [SerializeField] private List<GameObject> _winScreenObjects;

  private void OnEnable()
  {
    _player.Won += OnPlayerWon;
  }

  private void OnDisable()
  {
    _player.Won -= OnPlayerWon;
  }

  private void OnPlayerWon()
  {
    foreach (var obj in _winScreenObjects)
    {
      obj.SetActive(true);
    }
  }
}
