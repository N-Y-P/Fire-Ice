using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public enum SoundType
{
    BGM,
    SFX
}

public class SoundManager : Singleton<SoundManager>
{
    [SerializeField] private AudioMixer audioMixer;
    //����� �ͼ��� ���� ����

    [SerializeField] private List<AudioClip> audioClipList;
    //����� ����� Ŭ�� ����

    [SerializeField] private int initialPoolSize = 6;
    private List<SoundPlayer> sfxPool = new List<SoundPlayer>();

    [HideInInspector]public Dictionary<SoundType, List<SoundPlayer>> soundPlayerDic;
    //��� ���� SoundPlayer�� ����

    private string currentBGM = ""; //���� BGM ����

    public AudioMixer AudioMixer { get { return audioMixer; } }
    //�ܺο��� ����� �ͼ� ���� ���

    protected override void Awake()
    {
        base.Awake();
        soundPlayerDic = new Dictionary<SoundType, List<SoundPlayer>>();
        //��ųʸ� �ʱ�ȭ

        for(int i = 0; i < initialPoolSize; i++) //SFX���� ����ϱ� ���� ��ü�� �̸� �����
        {
            SoundPlayer sp = CreateSoundPlayer();
            sfxPool.Add(sp);
        }
    }

    private SoundPlayer CreateSoundPlayer() //SoundPlayer �����
    {
        GameObject go = new GameObject("SoundPlayer");
        go.transform.parent = this.transform;
        SoundPlayer sp = go.AddComponent<SoundPlayer>();
        return sp;
    }

    public void SetVolume(SoundType type, float volume) //���� ����
    {
        audioMixer.SetFloat(type.ToString(), Mathf.Log10(volume) * 20);
    }

    public void PlaySound(SoundType type, string name, bool isLoop = false) //���� ���
    {
        if(type==SoundType.BGM && soundPlayerDic.ContainsKey(type) && soundPlayerDic[type].Count >= 1)
        {
            return; //BGM ���� ���
        }
        SoundPlayer sp = GetSoundPlayerFromPool();
        AudioMixerGroup mixerGroup = audioMixer.FindMatchingGroups(type.ToString())[0];
        //AduioMixer���� Ÿ�԰� �´� �ͼ��׷� ã��
        AudioClip clip = audioClipList.Find( x => x.name == name );
        //name���� ����� �˻�

        sp.Setting(mixerGroup, clip, isLoop, type);
        sp.Play();

        if (soundPlayerDic.ContainsKey(type))
        {
            soundPlayerDic[type].Add(sp);
        }
        else
        {
            soundPlayerDic.Add(type, new List<SoundPlayer> { sp });
        }
    }

    public void ChangeBGM(string newBGM)
    {
        if (currentBGM == newBGM)
        {
            return;
        }

        stopBGM();
        PlaySound(SoundType.BGM, newBGM, true);
        currentBGM = newBGM;
    }

    public void stopBGM()
    {
        if (soundPlayerDic.ContainsKey(SoundType.BGM) && soundPlayerDic[SoundType.BGM].Count > 0)
        {
            foreach (var sp in soundPlayerDic[SoundType.BGM])
            {
                sp.AudioSource.Stop();
            }
            soundPlayerDic[SoundType.BGM].Clear();
        }  
    }

    private SoundPlayer GetSoundPlayerFromPool()
    {
        foreach (var sp in sfxPool)
        {
            if (!sp.IsPlaying)
            {
                return sp;
            }
        }

        SoundPlayer newSp = CreateSoundPlayer();
        sfxPool.Add(newSp);
        return newSp;
    }
}

/*
< �� �� ���� >
1. ����ȭ��
1-1. ���� ���� ȭ��
2. �������� ���� ȭ��
2-1. Ŀ���� ȭ��
3. �������� 1
3-1. �������� 2
3-2. �������� 3

< ���尡 �ʿ��� �� >
1. ĳ���� ����
2. ĳ���� ���� = ���� ����
3. ������Ʈ�� ��ȣ�ۿ� (������ ����ġ)
4. �� ����
5. ���� Ŭ����
*/
