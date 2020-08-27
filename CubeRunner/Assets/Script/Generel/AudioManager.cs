using System.Collections;
using UnityEngine.Audio;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioClip DeathExplosion;
    public static AudioSource[] _audioSourceAray;
    public static AudioSource _deathAudioSource;
    public static AudioSource _CoinAudioSource;
    
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        _audioSourceAray = GetComponents<AudioSource>();
        _deathAudioSource = _audioSourceAray[0];
        _CoinAudioSource = _audioSourceAray[1];
    }

    public static void PlayDeathSound()
    {
        _deathAudioSource.Play();
    }

    public static void PlayCoinNoise()
    {
        _CoinAudioSource.Play();
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
