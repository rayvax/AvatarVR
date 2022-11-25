using UnityEngine;
using UnityEngine.XR.Management;

public class DetectVR : MonoBehaviour
{
  [SerializeField] private GameObject[] vrObjects;
  [SerializeField] private GameObject[] desktopObjects;

  private void Awake()
  {
    var xrSettings = XRGeneralSettings.Instance;
    if (xrSettings == null)
    {
      Debug.Log("XRGeneralSettings is null");
      return;
    }

    var xrManager = xrSettings.Manager;
    if (xrManager == null)
    {
      Debug.Log("XRManagerSettings is null");
      return;
    }

    var xrLoader = xrManager.activeLoader;
    if (xrLoader == null)
    {
      Debug.Log("XRLoader is null. Setting in desktop mode.");

      foreach (var obj in vrObjects)
        obj.SetActive(false);

      foreach (var obj in desktopObjects)
        obj.SetActive(true);

      return;
    }

    Debug.Log("XRLoader is null. Setting in VR mode.");

    foreach (var obj in vrObjects)
      obj.SetActive(false);

    foreach (var obj in desktopObjects)
      obj.SetActive(false);
  }
}
