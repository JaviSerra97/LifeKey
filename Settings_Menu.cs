using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Settings_Menu : MonoBehaviour
{
    public Slider volumeSlider;

    public void VolumeController()
    {
        AudioListener.volume = volumeSlider.value;
    }
}