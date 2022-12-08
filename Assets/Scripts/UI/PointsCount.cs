using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PointsCount : MonoBehaviour
{
  private TMP_Text _textComponent;

  private void Awake()
  {
    _textComponent = GetComponent<TMP_Text>();
  }

  private void Start()
  {
    Player.Instance.PointsCountChanged += OnPointsCountChanged;
  }

  private void OnPointsCountChanged(int value)
  {
    _textComponent.text = value.ToString();
  }
}
