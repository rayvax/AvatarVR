using UnityEngine;

public class Fireball : MonoBehaviour
{
  [SerializeField] private float _flySpeed = 10;
  [SerializeField] private float _flyTime = 0.5f;

  private Vector3 _flyDirection;
  private bool _isShooted;
  private float _elapsedTime = 0;

  private void Update()
  {
    if (_isShooted)
    {
      Fly(Time.deltaTime);

      _elapsedTime += Time.deltaTime;
      if (_elapsedTime > _flyTime)
      {
        Destroy(gameObject);
      }
    }
  }

  private void Fly(float deltaTime)
  {
    var newPosition = transform.position + _flyDirection * _flySpeed * deltaTime;
    gameObject.transform.position = newPosition;
  }

  public void Shoot(Vector3 direction)
  {
    _isShooted = true;
    _flyDirection = direction.normalized;
  }
}
