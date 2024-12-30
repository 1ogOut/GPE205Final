using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsUI : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider VolumeSlider;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Start()
    {
        onMainVolumeChange();
    }

    public void onMainVolumeChange()
    {
        //get our sliders current volume
        float newVolume = VolumeSlider.value;
        //if the slider is at zero set it to the lowest volume (-80)
        if(newVolume <= 0)
        {
            newVolume = -80;
        }
        else
        {
            //get the new log10 value since were above 0
            newVolume = Mathf.Log10(newVolume);
            //make it 0-20db range instead of 0-1db
            newVolume = newVolume * 20;
        }
        //sets the volume to the new setting
        audioMixer.SetFloat("Master", newVolume);
    }
}
