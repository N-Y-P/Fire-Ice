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

    [SerializeField] private AudioMixer mAudioMixer;
    //���� Ÿ���� ���� ����

    private float mCurrentBGMVolume, mCurrentSFXVolume;
    //���� �������, ȿ�� ���� ����

    private Dictionary<string, AudioClip> mClipsDictionary;
    //Ŭ�� ��ųʸ�

    [SerializeField] private AudioClip[] mPreloadClips;
    //�̸� �ε��س��� Ŭ���� =============================== �ʿ��Ѱ�?

    private List<TemporarySoundPlayer> mInstantiatedSounds;

    private void Start()
    {
        mClipsDictionary = new Dictionary<string, AudioClip>();
        //����� Ŭ�� �̸�(string), ����� Ŭ���� ������ �����ϴ� ��ųʸ�
        foreach(AudioClip clip in mPreloadClips)
        //mPreloadClips : Unity �����Ϳ��� �̸� �����صδ� ����� Ŭ�� �迭
        {
            mClipsDictionary.Add(clip.name, clip);
            //clip.name�� Ű��, clip�� ������ ����
        }
        mInstantiatedSounds = new List<TemporarySoundPlayer>();
        //
    }
}

public class TemporarySoundPlayer : MonoBehaviour
{

}