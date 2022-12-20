using System.Collections;
using System.Collections.Generic;
using Oculus.Interaction;
using UnityEngine;

public class TutorialScreen : MonoBehaviour
{
  [SerializeField] private CanvasGroup _groupToDismiss;
  [SerializeField] private ActiveStateSelector _dismissPose;
  [SerializeField] private float _dismissTime = 3;

  [SerializeField] private LanternSpawner _lanternSpawner;

  private float _elapsedTime = 0;
  private bool _needDismiss = false;

  private void OnEnable()
  {
    _dismissPose.WhenSelected += DismissTutorial;
  }
  private void OnDisable()
  {
    _dismissPose.WhenSelected -= DismissTutorial;
  }

  private void Update()
  {
    if (_needDismiss)
    {
      _elapsedTime += Time.deltaTime;
      _groupToDismiss.alpha = (1 - _elapsedTime / _dismissTime);

      if (_elapsedTime >= _dismissTime)
      {
        _needDismiss = false;
        _lanternSpawner.SetNeedSpawn(true);
        gameObject.SetActive(false);
      }
    }
  }

  private void DismissTutorial()
  {
    _needDismiss = true;
  }
}
