using UnityEngine;
using Plugins.Audio.Core;

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    private SourceAudio sourceMusic;

    [SerializeField]
    private SourceAudio sourceSound;

    public Sound[] sounds;

    public static AudioManager Instance;

    private void Awake()
    {
        #region Singleton

        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);

        #endregion

        SetVolume();

        foreach (Sound s in sounds)
        {
            if (s.name == "Music")
            {
                s.source = sourceMusic;
            }
            else
            {
                s.source = sourceSound;
            }
        }
        
    }

    private void Start()
    {
        sourceMusic.Play("Music");

        foreach (Sound s in sounds)
        {
            if (s.name == "Music")
            {
                s.source.Loop = s.loop;

                s.source.Volume = s.volume = PlayerPrefs.GetFloat("MusicVolume");
            }
            else
            {
                s.source.Loop = s.loop;

                s.source.Volume = s.volume = PlayerPrefs.GetFloat("SoundVolume");
            }
        }
    }

    public void PlaySounds(string soundKey)
    {
        sourceSound.Play(soundKey);
    }

    private void SetVolume()
    {
        if (!PlayerPrefs.HasKey("MusicVolume"))
        {
            PlayerPrefs.SetFloat("MusicVolume", 1f);
        }
        if (!PlayerPrefs.HasKey("SoundVolume"))
        {
            PlayerPrefs.SetFloat("SoundVolume", 1f);
        }
    }

    private void OnMusic()
    {
        PlayerPrefs.SetFloat("MusicVolume", 1f);

        foreach (Sound s in sounds)
        {
            if (s.name == "Music")
            {
                s.source.Volume = s.volume = PlayerPrefs.GetFloat("MusicVolume");
            }
        }
    }

    private void OffMusic()
    {
        PlayerPrefs.SetFloat("MusicVolume", 0f);

        foreach (Sound s in sounds)
        {
            if (s.name == "Music")
            {
                s.source.Volume = s.volume = PlayerPrefs.GetFloat("MusicVolume");
            }
        }
    }

    private void OnSounds()
    {
        PlayerPrefs.SetFloat("SoundVolume", 1f);

        foreach (Sound s in sounds)
        {
            if (s.name == "Music")
            {
                continue;
            }
            else
            {
                s.source.Volume = s.volume = PlayerPrefs.GetFloat("SoundVolume");
            }
        }
    }

    private void OffSounds()
    {
        PlayerPrefs.SetFloat("SoundVolume", 0f);

        foreach (Sound s in sounds)
        {
            if (s.name == "Music")
            {
                continue;
            }
            else
            {
                s.source.Volume = s.volume = PlayerPrefs.GetFloat("SoundVolume");
            }
        }
    }
}
