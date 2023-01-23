using UnityEngine;
using Oculus.Interaction;

public class PlayerShooter : MonoBehaviour
{
  [Header("Poses")]
  [SerializeField] private ActiveStateSelector _fireballAppearPose;
  // [SerializeField] private ActiveStateSelector _shootPose;

  [Header("Fireball")]
  [SerializeField] private Fireball _fireballPrefab;
  [SerializeField] private ActiveComponentDispenser _fireballReadyEffectDispenser;
  [SerializeField] private ActiveComponentDispenser _fireballShootingPositionDispenser;
  [SerializeField] private ActiveComponentDispenser _fireballParentDispenser;
  [SerializeField] private ActiveComponentDispenser _fireballShootingDirectionDispenser;

  [Header("Sounds")]
  [SerializeField] private ActiveComponentDispenser _fireballPreparedSoundDispenser;
  [SerializeField] private ActiveComponentDispenser _fireballShootSoundDispenser;

  private ParticleSystem _fireballReadyEffect;
  private Transform _fireballShootingPosition;
  private Transform _fireballParent;
  private Transform _fireballShootingDirection;
  private AudioSource _fireballPreparedAudioSource;
  private AudioSource _fireballShootAudioSource;

  private bool _isFireballReady = false;
  private bool _canShoot = true;

  private void Start()
  {
    _fireballReadyEffect = _fireballReadyEffectDispenser.DispenseComponent<ParticleSystem>();
    _fireballShootingPosition
          = _fireballShootingPositionDispenser.DispenseComponent<Transform>();
    _fireballParent = _fireballParentDispenser.DispenseComponent<Transform>();
    _fireballShootingDirection
          = _fireballShootingDirectionDispenser.DispenseComponent<Transform>();
    _fireballPreparedAudioSource
          = _fireballPreparedSoundDispenser.DispenseComponent<AudioSource>();
    _fireballShootAudioSource
          = _fireballShootSoundDispenser.DispenseComponent<AudioSource>();
  }

  private void OnEnable()
  {
    _fireballAppearPose.WhenSelected += PrepareFireball;
    _fireballAppearPose.WhenUnselected += ShootFireball;
  }

  private void OnDisable()
  {
    _fireballAppearPose.WhenSelected -= PrepareFireball;
    _fireballAppearPose.WhenUnselected -= ShootFireball;
  }

  public void DisableShooting()
  {
    _canShoot = false;
    _fireballReadyEffect.Stop();
    _fireballPreparedAudioSource.Stop();
  }

  private void PrepareFireball()
  {
    if (!_canShoot || _fireballReadyEffect.isPlaying) return;

    _fireballReadyEffect.Play();
    _fireballPreparedAudioSource.Play();
  }

  private void ShootFireball()
  {
    if (!_canShoot || !_fireballReadyEffect.isPlaying) return;

    _fireballReadyEffect.Stop();
    _fireballPreparedAudioSource.Stop();

    var _currentFireball = Instantiate(
      _fireballPrefab,
      _fireballShootingPosition.position,
      Quaternion.identity);

    _currentFireball.Shoot(_fireballShootingDirection.forward);
    _fireballShootAudioSource.Play();
  }
}
