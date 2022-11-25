using UnityEngine;
using Oculus.Interaction;

public class SimpleActiveState : MonoBehaviour, IActiveState
{
  public bool Active => _active;

  private bool _active;

  public void Select()
  {
    _active = true;
  }

  public void Unselect()
  {
    _active = false;
  }
}
