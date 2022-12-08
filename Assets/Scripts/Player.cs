using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
  [SerializeField] private int _maxHealthPoint = 3;

  public event UnityAction<int> HealthChanged;
  public event UnityAction Died;

  private int _currentHealth;

  private void Start()
  {
    SetCurrentHealth(_maxHealthPoint);
  }

  public void LoseHealthPoint()
  {
    SetCurrentHealth(_currentHealth - 1);

    if (_currentHealth <= 0)
      Died?.Invoke();
  }

  private void SetCurrentHealth(int value)
  {
    _currentHealth = value;
    HealthChanged?.Invoke(_currentHealth);
  }
}
