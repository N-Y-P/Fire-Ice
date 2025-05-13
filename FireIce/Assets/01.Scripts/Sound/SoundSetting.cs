using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundSetting : MonoBehaviour
{
    [SerializeField] private Slider bgmSlider;
    [SerializeField] private Slider sfxSlider;

    private void Start()
    {
        bgmSlider.value = 1f; //�⺻ ���� 100%
        sfxSlider.value = 1f;

        bgmSlider.onValueChanged.AddListener(OnBGMChanged);
        sfxSlider.onValueChanged.AddListener(OnSFXChanged);
        //Slider ���� �� ȣ��
    }

    private void OnBGMChanged(float value) //BGM ���� �� ȣ��
    {
        SoundManager.Instance.SetVolume(SoundType.BGM, value);
    }

    private void OnSFXChanged(float value) //SFX ���� �� ȣ��
    {
        SoundManager.Instance.SetVolume(SoundType.SFX, value);
    }
}
