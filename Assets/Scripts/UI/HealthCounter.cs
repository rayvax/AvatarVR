using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HealthCounter : MonoBehaviour
{
  [SerializeField] private Player _player;

  private TMP_Text _textComponent;

  private void Awake()
  {
    _textComponent = GetComponent<TMP_Text>();
  }

  private void OnEnable()
  {
    _player.HealthChanged += OnHealthChanged;
  }
  private void OnDisable()
  {
    _player.HealthChanged -= OnHealthChanged;
  }

  private void OnHealthChanged(int value)
  {
    _textComponent.text = value.ToString();
  }
}
