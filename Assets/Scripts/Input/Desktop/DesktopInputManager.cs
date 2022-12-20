using UnityEngine;

public class DesktopInputManager : MonoBehaviour
{
  [SerializeField] private SimpleActiveState _rightShootPose;
  [SerializeField] private SimpleActiveState _leftShootPose;

  private void Update()
  {
    DetectSelectorMouseInput(0, _rightShootPose);
    DetectSelectorMouseInput(1, _leftShootPose);
  }

  private void DetectSelectorMouseInput(int mouseButton, SimpleActiveState selector)
  {
    if (Input.GetMouseButtonDown(mouseButton))
    {
      selector.Select();
    }
    else if (Input.GetMouseButtonUp(mouseButton))
    {
      selector.Unselect();
    }
  }
}
