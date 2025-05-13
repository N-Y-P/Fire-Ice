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

    [HideInInspector]public Dictionary<SoundType, List<SoundPlayer>> soundPlayerDic;
    //��� ���� SoundPlayer�� ����

    public AudioMixer AudioMixer { get { return audioMixer; } }
    //�ܺο��� ����� �ͼ� ���� ���

    protected override void Awake()
    {
        base.Awake();
        soundPlayerDic = new Dictionary<SoundType, List<SoundPlayer>>();
        //��ųʸ� �ʱ�ȭ
        SoundManager.Instance.PlaySound(SoundType.BGM, "Goblins_Den_(Regular)");
    }

    public void SetVolume(SoundType type, float volume) //���� ����
    {
        audioMixer.SetFloat(type.ToString(), Mathf.Log10(volume) * 20);
    }

    public void PlaySound(SoundType type, string name, bool isLoop = false) //���� ���
    {
        if (type == SoundType.BGM && soundPlayerDic.ContainsKey(type) && soundPlayerDic[type].Count >= 1)
        {
            Debug.Log("�뷡 ��� ��");
            if (soundPlayerDic[type][0].AudioSourceComp.clip.name == name)
            {
                Debug.Log("�Ȱ��� BGM");
                return; //BGM�� �ٽ� ��û���� �� �ش� ������ �ٲ�� ����
            }

            foreach (var player in soundPlayerDic[type])
            {
                player.AudioSourceComp.Stop();
                Destroy(player.gameObject);
            }
            soundPlayerDic[type].Clear();
        }

        GameObject go = new GameObject();
        go.transform.parent = transform;
        SoundPlayer sp = go.AddComponent<SoundPlayer>();
        AudioMixerGroup mixerGroup = audioMixer.FindMatchingGroups(type.ToString())[0];
        //AduioMixer���� Ÿ�԰� �´� �ͼ��׷� ã��
        AudioClip clip = audioClipList.Find( x => x.name == name );
        //name���� ����� �˻�

        sp.Setting(mixerGroup, clip, isLoop);
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
