using Oculus.Interaction;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
  [SerializeField] private int _maxHealthPoint = 3;
  [SerializeField] private int _pointsToWin = 10;
  [SerializeField] private ActiveStateSelector _restartGamePose;
  [SerializeField] private LanternSpawner _lanternSpawner;

  public static Player Instance => _instance;

  public event UnityAction<int> HealthChanged;
  public event UnityAction Died;

  public event UnityAction<int> PointsCountChanged;
  public event UnityAction Won;

  private int _currentHealth;
  private int _currentPointsCount;
  private static Player _instance;

  private PlayerShooter[] _playerShooters;

  private bool _ableToRestart = false;

  private void Awake()
  {
    _playerShooters = GetComponents<PlayerShooter>();
  }

  private void OnEnable()
  {
    InitSingleton();
    _restartGamePose.WhenSelected += RestartGame;
  }

  private void OnDisable()
  {
    _restartGamePose.WhenSelected -= RestartGame;
  }

  private void Start()
  {
    SetCurrentHealth(_maxHealthPoint);
    SetCurrentPointsCount(0);
  }

  public void LoseHealthPoint()
  {
    SetCurrentHealth(_currentHealth - 1);

    if (_currentHealth <= 0)
    {
      EndGame();
      Died?.Invoke();
    }
  }

  public void IncreasePoint()
  {
    SetCurrentPointsCount(_currentPointsCount + 1);

    if (_currentPointsCount >= _pointsToWin)
    {
      EndGame();
      Won?.Invoke();
    }
  }

  private void InitSingleton()
  {
    if (_instance == null)
    {
      _instance = this;
    }
    else if (_instance == this)
    {
      Destroy(gameObject);
    }
  }

  private void SetCurrentHealth(int value)
  {
    _currentHealth = value;
    HealthChanged?.Invoke(_currentHealth);
  }

  private void SetCurrentPointsCount(int value)
  {
    _currentPointsCount = value;
    PointsCountChanged?.Invoke(_currentPointsCount);
  }

  private void DisableAllShooting()
  {
    foreach (var shooter in _playerShooters)
      shooter.DisableShooting();
  }

  private void EndGame()
  {
    DisableAllShooting();

    _lanternSpawner.StopSpawnedLanterns();
    _lanternSpawner.SetNeedSpawn(false);

    _ableToRestart = true;
  }

  private void RestartGame()
  {
    if (!_ableToRestart) return;

    SceneManager.LoadScene(0);
  }
}
