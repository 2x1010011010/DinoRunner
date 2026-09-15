using UnityEngine;
using UnityEngine.Audio;

namespace GUI.Sliders
{
  public class Slider : MonoBehaviour
  {
    [SerializeField] protected AudioMixerGroup _mixerSlider;
    [SerializeField] protected string _mixerGroupName;

    private const float _minLinearVolume = 0.0001f;
    private const float _minDb = -80f;

    private float _currentVolume = -1f;
    private const float _epsilon = 0.001f;

    private void Start()
    {
      float saved = PlayerPrefs.GetFloat(_mixerGroupName, 1f);
      ChangeVolume(saved);
    }

    public void ChangeVolume(float volume)
    {
      if (VolumesAreEqual(volume)) return;

      float dB = volume <= _minLinearVolume
        ? _minDb
        : Mathf.Log10(volume) * 20f;

      _mixerSlider.audioMixer.SetFloat(_mixerGroupName, dB);
      _currentVolume = volume;
      PlayerPrefs.SetFloat(_mixerGroupName, volume);
    }

    private bool VolumesAreEqual(float volume)
    {
      return Mathf.Abs(_currentVolume - volume) < _epsilon;
    }
  }
}