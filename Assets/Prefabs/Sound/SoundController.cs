using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class SoundController : MonoBehaviour
{
    private Dictionary<string, AudioSource> colorAudioMap;

    public static SoundController Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        
        colorAudioMap = new Dictionary<string, AudioSource>();
        var audioSources = GetComponents<AudioSource>();
        colorAudioMap.Add("Red", audioSources[0]);
        colorAudioMap.Add("Blue", audioSources[1]);
        colorAudioMap.Add("Green", audioSources[2]);
        colorAudioMap.Add("Purple", audioSources[3]);

        StartMusic();
    }

    private void StartMusic()
    {
        foreach (AudioSource audioSource in GetComponents<AudioSource>())
        {
            audioSource.Play();
        }
    }

    public void stopMusic(string color)
    {
        
        colorAudioMap[color].mute = true;    
    }

    public void playMusic(string color)
    {
        colorAudioMap[color].mute = false;
    }
}
