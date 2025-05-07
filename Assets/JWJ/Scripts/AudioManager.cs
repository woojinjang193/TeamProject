using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static AudioManager instance;
    

    [Header("#BGM")]
    public AudioClip bgmClip;
    public float bgmVolume;
    AudioSource bgmPlayer;

    [Header("#SFX")]
    public AudioClip[] sfxClips;
    [SerializeField] private float[] sfxVolumes;

    public int channels;
    AudioSource[] sfxPlayers;
    int channelIndex;

    public enum Sfx { ArrowRelease, Hit, FootStep, PlayerGetDamaged, MonsterGetDamaged, BossSpawn, BossDead, BossAttack, BossDash }

    private void Awake()
    {
        instance = this;
        Init();
    }

    void Init()
    {
        GameObject bgmObject = new GameObject("bgmPlayer");
        bgmObject.transform.parent = transform;
        bgmPlayer = bgmObject.AddComponent<AudioSource>();
        bgmPlayer.playOnAwake = false; // 시작시 재생 끔
        bgmPlayer.loop = true;
        bgmPlayer.volume = bgmVolume;
        bgmPlayer.clip = bgmClip;

        GameObject sfxObject = new GameObject("sfxPlayer");
        sfxObject.transform.parent = transform;
        sfxPlayers = new AudioSource[channels];

        for (int index = 0; index < sfxPlayers.Length; index++)
        {
            sfxPlayers[index] = sfxObject.AddComponent<AudioSource>();
            sfxPlayers[index].playOnAwake = false;
        }
    }
    public void PlayBgm()
    {
        if (bgmPlayer != null && bgmClip != null && !bgmPlayer.isPlaying)
        {
            bgmPlayer.Play();
        }
    }

    public void PlaySfx(Sfx sfx)
    {
        int sfxIndex = (int)sfx;

        for (int index = 0; index < sfxPlayers.Length; index++)
        {
            int loopIndex = (index + channelIndex) % sfxPlayers.Length;

            if (sfxPlayers[loopIndex].isPlaying)
                continue;

            channelIndex = loopIndex;
            sfxPlayers[loopIndex].clip = sfxClips[(int)sfx];
            sfxPlayers[loopIndex].volume = sfxVolumes[sfxIndex];
            sfxPlayers[loopIndex].Play();
            break;
        }
        
    }
}
