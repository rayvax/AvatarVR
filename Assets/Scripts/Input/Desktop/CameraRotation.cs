using UnityEngine;

public class CameraRotation : MonoBehaviour
{
  [SerializeField] float camSens = 0.25f;

  //kind of in the middle of the screen, rather than at the top (play)
  [SerializeField] private Vector3 lastMouse = new Vector3(255, 255, 255);

  private void Update()
  {
    lastMouse = Input.mousePosition - lastMouse;
    lastMouse = new Vector3(-lastMouse.y * camSens, lastMouse.x * camSens, 0);
    lastMouse = new Vector3(transform.eulerAngles.x + lastMouse.x, transform.eulerAngles.y + lastMouse.y, 0);
    transform.eulerAngles = lastMouse;
    lastMouse = Input.mousePosition;
  }
}
