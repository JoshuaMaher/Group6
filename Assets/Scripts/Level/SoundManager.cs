
using UnityEngine;

public class SoundManager : MonoBehaviour
{
   private AudioSource source;
   private AudioSource musicSource;
   public static SoundManager instance {get; private set;}

   private void Awake()
   {
    instance = this;
    source = GetComponent<AudioSource>();
    musicSource = transform.GetChild(0).GetComponent<AudioSource>();
    
    if (instance == null)
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
    else if (instance != null && instance != this)
        Destroy(gameObject);

    ChangeVolumeMusic(0);
    ChangeVolumeSound(0);
   }

    public void PlaySound(AudioClip _sound)
    {
        source.PlayOneShot(_sound);
    }

    public void ChangeVolumeSound(float _change)
    {
        float baseVolume = 1;

        float currentValue = PlayerPrefs.GetFloat("soundVolume", 1);
        currentValue += _change;

        if(currentValue > 1)
            currentValue = 0;
        else if(currentValue < 0)
            currentValue = 1;

        float newVolume = currentValue * baseVolume;
        source.volume = newVolume;
        
        PlayerPrefs.SetFloat("soundVolume", currentValue);
    }

    public void ChangeVolumeMusic(float _change)
    {
        float baseVolume = 0.2f;

      float currentValue = PlayerPrefs.GetFloat("musicVolume", 1);
        currentValue += _change;

        if(currentValue > 1)
            currentValue = 0;
        else if(currentValue < 0)
            currentValue = 1;

        float newVolume = currentValue * baseVolume;
        musicSource.volume = newVolume;
        
        PlayerPrefs.SetFloat("musicVolume", currentValue);
    }

}
