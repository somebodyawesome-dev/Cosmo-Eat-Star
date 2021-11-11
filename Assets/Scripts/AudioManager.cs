using UnityEngine.Audio;
using UnityEngine;


public class AudioManager : MonoBehaviour
{
    [SerializeField] public Audio[] audios;
    private void Awake()
    {
        foreach(Audio audio in audios)
        {
            audio.source = gameObject.AddComponent<AudioSource>();
            audio.source.clip = audio.clip;
            audio.source.loop = audio.loop;
            audio.source.volume = audio.volume;
            audio.source.pitch = audio.pitch;
            audio.source.playOnAwake = false;
            
        }
    }
    private void Start()
    {
        play("Music");
        setMusic(PlayerData.isMusicOff);
        setSound(PlayerData.isSoundOff);
    }

    public void play(string name)
    {
        foreach(Audio audio in audios)
        {
            if (audio.name == name)
            {
                audio.source.Play();
                return;
            }
        }
        Debug.LogError("Audio :" + name + "Not found");
    }

    public void setMusic(bool isMusicOff)
    {
        foreach (Audio audio in audios)
        {
            if (!audio.isSound)
            {
                if (isMusicOff)
                {
                    audio.source.mute = true;
                }
                else
                {
                    audio.source.mute = false ;
                }
            }
        }
    }
    public void setSound(bool isSoundOff)
    {
        foreach (Audio audio in audios)
        {
            if (audio.isSound)
            {
                if (isSoundOff)
                {
                    audio.source.mute = true;
                }
                else
                {
                    audio.source.mute = false;
                }
            }
        }
    }


    public void muteMusic(bool isMusicOff)
    {
        PlayerData.isMusicOff = isMusicOff;
    }
    public void muteSounds(bool isSoundOff)
    {
        PlayerData.isSoundOff = isSoundOff;
    }
}
