using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMusicPlayer : MonoBehaviour
{
  [Header("Audio")]
  [SerializeField] private AudioClip _whileShootingAudio;
  [SerializeField] private AudioClip _tutorialAudio;
  [SerializeField] private AudioClip _loseAudio;
  [SerializeField] private AudioClip _winAudio;

  [Header("References")]
  [SerializeField] private Player _player;
  [SerializeField] private TutorialScreen _tutorialScreen;

  private AudioSource _audioSource;

  private void Awake()
  {
    _audioSource = GetComponent<AudioSource>();
  }

  private void OnEnable()
  {
    _tutorialScreen.Started += OnTutorialStarted;
    _tutorialScreen.DismissEnded += OnTutorialDismissEnded;
    _player.Won += OnPlayerWon;
    _player.Died += OnPlayerDied;
  }
  private void OnDisable()
  {
    _tutorialScreen.Started -= OnTutorialStarted;
    _tutorialScreen.DismissEnded -= OnTutorialDismissEnded;
    _player.Won -= OnPlayerWon;
    _player.Died -= OnPlayerDied;
  }

  private void OnTutorialStarted()
  {
    PlayClip(_tutorialAudio);
  }

  private void OnTutorialDismissEnded()
  {
    PlayClip(_whileShootingAudio);
  }

  private void OnPlayerWon()
  {
    PlayClip(_winAudio);
  }

  private void OnPlayerDied()
  {
    PlayClip(_loseAudio);
  }


  private void PlayClip(AudioClip clip)
  {
    _audioSource.Stop();
    _audioSource.clip = clip;
    _audioSource.Play();
  }
}
