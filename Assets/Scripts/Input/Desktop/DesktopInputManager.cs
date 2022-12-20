using UnityEngine;

public class DesktopInputManager : MonoBehaviour
{
  [SerializeField] private SimpleActiveState _rightShootPose;
  [SerializeField] private SimpleActiveState _leftShootPose;
  [SerializeField] private SimpleActiveState _readyPose;

  private void Update()
  {
    DetectSelectorMouseInput(0, _rightShootPose);
    DetectSelectorMouseInput(1, _leftShootPose);

    if (Input.GetKeyDown(KeyCode.Return))
    {
      _readyPose.Select();
    }
    else if (Input.GetKeyUp(KeyCode.Return))
    {
      _readyPose.Unselect();
    }
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
