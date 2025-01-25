using UnityEngine;


public enum SoundIndexes
{
    BackgroundMusic,
    Click,
    Poof,
    WinSound,
    LoseSound
}

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource[] Sounds;

    public void PlaySound(SoundIndexes index)
    {
        Sounds[(int)index].Play();
    }

    public void StopSound(SoundIndexes index)
    {
        Sounds[(int)index].Stop();
    }
}
