using UnityEngine;
using UnityEngine.Audio;

namespace GUI
{
    public class Slider : MonoBehaviour
    {
        [SerializeField] private AudioMixerGroup _mixerSlider;
        [SerializeField] private float _minVolume;
        [SerializeField] private float _maxVolume;
        [SerializeField] private string _mixerGroupName;

        public void ChangeVolume(float volume)
        {
            _mixerSlider.audioMixer.SetFloat(_mixerGroupName, Mathf.Lerp(_minVolume, _maxVolume, volume));
        }
    }
}
