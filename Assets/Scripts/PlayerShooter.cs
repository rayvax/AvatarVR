using UnityEngine;
using Oculus.Interaction;

public class PlayerShooter : MonoBehaviour
{
  [Header("Poses")]
  [SerializeField] private ActiveStateSelector _fireballAppearPose;
  [SerializeField] private ActiveStateSelector _shootPose;

  [Header("Fireball")]
  [SerializeField] private Fireball _fireballPrefab;
  [SerializeField] private ActiveComponentDispenser _fireballShootingPositionDispenser;
  [SerializeField] private ActiveComponentDispenser _fireballParentDispenser;

  private Transform _fireballShootingPosition;
  private Transform _fireballParent;

  private Fireball _currentFireball = null;

  private void Start()
  {
    _fireballShootingPosition = _fireballShootingPositionDispenser.DispenseComponent<Transform>();
    _fireballParent = _fireballParentDispenser.DispenseComponent<Transform>();
  }

  private void OnEnable()
  {
    _fireballAppearPose.WhenSelected += CreateFireball;
    // _fireballAppearPose.WhenUnselected += DestroyCurrentFireball;

    _shootPose.WhenSelected += ShootFireball;
  }

  private void OnDisable()
  {
    _fireballAppearPose.WhenSelected -= CreateFireball;
    // _fireballAppearPose.WhenUnselected -= DestroyCurrentFireball;

    _shootPose.WhenSelected -= ShootFireball;
  }

  private void CreateFireball()
  {
    if (_currentFireball) return;

    _currentFireball = Instantiate(
      _fireballPrefab,
      _fireballShootingPosition.position,
      Quaternion.identity,
      _fireballParent);
  }

  private void DestroyCurrentFireball()
  {
    if (!_currentFireball) return;

    Destroy(_currentFireball.gameObject);
    _currentFireball = null;
  }

  private void ShootFireball()
  {
    if (!_currentFireball) return;

    _currentFireball.transform.parent = null;
    _currentFireball.Shoot(_fireballShootingPosition.forward);
    _currentFireball = null;
  }
}
