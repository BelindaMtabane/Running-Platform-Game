using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource musicSource; // Reference to the AudioSource component
    [SerializeField] Slider volumeAdjust; // Reference to the volume slider

    public AudioClip background; // Reference to the background music

    void Start()
    {
        if(!PlayerPrefs.HasKey("MusicVolume")) // Check if the music volume is saved
        {
            PlayerPrefs.SetFloat("MusicVolume", 1); // Set the default music volume
            Load();
        }
        musicSource.clip = background; // Set the background music clip
        musicSource.Play(); // Play the background music
    }
    public void VolumeAdjust()
    {
        musicSource.volume = volumeAdjust.value; // Adjust the volume of the music
    }
    public void Mute()
    {
        musicSource.mute = !musicSource.mute; // Mute or unmute the music
    }
    public void Save()
    {
        if (musicSource != null)
        {
            PlayerPrefs.SetFloat("MusicVolume", musicSource.volume); // Save the music volume
        }
        else
        {
            PlayerPrefs.SetInt("MusicMute", musicSource.mute ? 1 : 0); // Save the music mute state
        }
    }
    public void Load()
    {
        if (musicSource != null)
        {
            volumeAdjust.value = PlayerPrefs.GetFloat("MusicVolume", 1); // Load the music volume
        }
        else
        {
            musicSource.mute = PlayerPrefs.GetInt("MusicMute", 0) == 1; // Load the music mute state
        }
    }
}
