using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HealthCounter : MonoBehaviour
{
  private TMP_Text _textComponent;

  private void Awake()
  {
    _textComponent = GetComponent<TMP_Text>();
  }

  private void Start()
  {
    Player.Instance.HealthChanged += OnHealthChanged;
  }

  private void OnHealthChanged(int value)
  {
    _textComponent.text = value.ToString();
  }
}
