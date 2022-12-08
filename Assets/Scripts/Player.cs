using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
  [SerializeField] private int _maxHealthPoint = 3;
  [SerializeField] private int _pointsToWin = 10;

  public static Player Instance => _instance;

  public event UnityAction<int> HealthChanged;
  public event UnityAction Died;

  public event UnityAction<int> PointsCountChanged;
  public event UnityAction Won;

  private int _currentHealth;
  private int _currentPointsCount;
  private static Player _instance;

  private void OnEnable()
  {
    InitSingleton();
  }

  private void Start()
  {
    SetCurrentHealth(_maxHealthPoint);
  }

  public void LoseHealthPoint()
  {
    SetCurrentHealth(_currentHealth - 1);

    if (_currentHealth <= 0)
      Died?.Invoke();
  }

  public void IncreasePoint()
  {
    SetCurrentPointsCount(_currentPointsCount + 1);

    if (_currentPointsCount >= _maxHealthPoint)
      Won?.Invoke();
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

    DontDestroyOnLoad(gameObject);
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
}
