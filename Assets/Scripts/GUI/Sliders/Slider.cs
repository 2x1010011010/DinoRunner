using Unity.Mathematics.Geometry;
using UnityEngine;
using UnityEngine.Audio;

namespace GUI.Sliders
{
  public class Slider : MonoBehaviour
  {
    [SerializeField] protected AudioMixerGroup _mixerSlider;
    [SerializeField] protected float _minVolume;
    [SerializeField] protected float _maxVolume;
    [SerializeField] protected string _mixerGroupName;
    
    private float _currentVolume;
    private const float _epsilon = 0.001f;
    public void ChangeVolume(float volume)
    {
      if (VolumesAreEqual(volume)) return;
      
      _mixerSlider.audioMixer.SetFloat(_mixerGroupName, Mathf.Lerp(_minVolume, _maxVolume, volume));
      _currentVolume = volume;
      PlayerPrefs.SetFloat(_mixerGroupName, volume);
    }

    private bool VolumesAreEqual(float volume)
    {
      return Mathf.Abs(_currentVolume - volume) < _epsilon;
    }
  }
}