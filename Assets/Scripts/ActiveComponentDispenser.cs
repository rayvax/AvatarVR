using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveComponentDispenser : MonoBehaviour
{
  [SerializeField] List<GameObject> _objectsToDispense;

  public T DispenseComponent<T>()
  {
    for (int i = 0; i < _objectsToDispense.Count; i++)
    {
      if (_objectsToDispense[i] & _objectsToDispense[i].activeInHierarchy)
      {
        return _objectsToDispense[i].GetComponent<T>();
      }
    }

    return default(T);
  }
}
