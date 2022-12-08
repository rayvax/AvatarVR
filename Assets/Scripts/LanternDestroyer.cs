using UnityEngine;

public class LanternDestroyer : MonoBehaviour
{
  [SerializeField] private Player _player;


  private void OnTriggerEnter(Collider other)
  {
    if (other.TryGetComponent<Lantern>(out Lantern lantern))
    {
      _player.LoseHealthPoint();
      lantern.Break();
    }
  }
}
