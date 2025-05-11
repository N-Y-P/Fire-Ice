using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BtnController : MonoBehaviour
{

    public void OnStartBtn()
    {
        SceneManager.LoadScene(1);
    }

    public void OnExitBtn()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
        // ���� ����� ���ӿ����� ���ø����̼� ����
        Application.Quit();
#endif
    }

}
