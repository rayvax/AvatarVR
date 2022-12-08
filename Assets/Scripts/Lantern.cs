using UnityEngine;

public class Lantern : MonoBehaviour
{
  [SerializeField] private MeshRenderer _meshRenderer;

  [Header("Default fly")]
  [SerializeField] private float _defaultFlySpeed = 1;
  [SerializeField] private Vector3 _defaultFlyDirection = Vector3.down;

  [Header("Lit")]
  [SerializeField] private float _litSpeed = 3;
  [SerializeField] private Vector3 _litFlyDirection = Vector3.up;

  private float _currentFlySpeed;
  private Vector3 _currentFlyDirection;

  private void Awake()
  {
    _currentFlySpeed = _defaultFlySpeed;
    _currentFlyDirection = _defaultFlyDirection;
  }

  private void Update()
  {
    Fly(Time.deltaTime);
  }

  public void Light()
  {
    _meshRenderer.material.color = new Color(227, 186, 39);

    _currentFlySpeed = _litSpeed;
    _currentFlyDirection = _litFlyDirection;
  }

  public void Break()
  {
    Destroy(gameObject);
  }

  private void Fly(float deltaTime)
  {
    var newPosition = transform.position + _currentFlyDirection * _currentFlySpeed * deltaTime;
    gameObject.transform.position = newPosition;
  }
}
