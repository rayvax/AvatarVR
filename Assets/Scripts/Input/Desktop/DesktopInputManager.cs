using UnityEngine;

public class DesktopInputManager : MonoBehaviour
{
  [SerializeField] private SimpleActiveState _stopPoseSelector;
  [SerializeField] private SimpleActiveState _bunnyPoseSelector;

  private void Update()
  {
    DetectSelectorMouseInput(0, _stopPoseSelector);
    DetectSelectorMouseInput(1, _bunnyPoseSelector);
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
