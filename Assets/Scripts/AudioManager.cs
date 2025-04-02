using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource musicSource; // Reference to the AudioSource component

    public AudioClip background; // Reference to the background music

    void Start()
    {
        musicSource.clip = background; // Set the background music clip
        //musicSource.loop = true; // Set the background music to loop
        musicSource.Play(); // Play the background music
    }


}
