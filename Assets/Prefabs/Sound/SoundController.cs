using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;
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

    private void stopMusic(string color)
    {
        try
        {
            colorAudioMap[color].mute = true;
        }
        catch (KeyNotFoundException)
        {
            Debug.Log("Color " + color + " not found in colorAudioMap");
        }
        colorAudioMap[color].mute = true;    
    }

    private void playMusic(string color)
    {
        try {
            colorAudioMap[color].mute = false;
        } catch (KeyNotFoundException) {
            Debug.Log("Color " + color + " not found in colorAudioMap");
        }
    }

    public void updateMusics(string[] colors){
        foreach (string color in colorAudioMap.Keys)
        {
            if (colors.Contains(color)) 
            {
                playMusic(color);
            } else {
                stopMusic(color);
            }
        }
    }
}
