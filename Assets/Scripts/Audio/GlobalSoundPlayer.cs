using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalSoundPlayer : MonoBehaviour
{
  [Header("Audio")]
  [SerializeField] private AudioClip _winSoundClip;
  [SerializeField] private AudioClip _loseSoundClip;


  [Header("References")]
  [SerializeField] private Player _player;

  private AudioSource _audioSource;

  private void Awake()
  {
    _audioSource = GetComponent<AudioSource>();
  }

  private void OnEnable()
  {
    _player.Won += OnPlayerWon;
    _player.Died += OnPlayerDied;
  }
  private void OnDisable()
  {
    _player.Won -= OnPlayerWon;
    _player.Died -= OnPlayerDied;
  }

  private void OnPlayerWon()
  {
    PlayClip(_winSoundClip);
  }

  private void OnPlayerDied()
  {
    PlayClip(_loseSoundClip);
  }


  private void PlayClip(AudioClip clip)
  {
    _audioSource.Stop();
    _audioSource.clip = clip;
    _audioSource.Play();
  }
}
