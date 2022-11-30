using UnityEngine;

public class Lantern : MonoBehaviour
{
  [SerializeField] private MeshRenderer _meshRenderer;

  [SerializeField] private float _litSpeed = 3;

  private bool _isLit;
  private Vector3 _litFlyDirection = Vector3.up;

  private void Update()
  {
    if (_isLit)
    {
      Fly(Time.deltaTime);
    }
  }

  public void Light()
  {
    _meshRenderer.material.color = new Color(227, 186, 39);
    _isLit = true;
  }

  private void Fly(float deltaTime)
  {
    var newPosition = transform.position + _litFlyDirection * _litSpeed * deltaTime;
    gameObject.transform.position = newPosition;
  }
}
