using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// ��ư�� Ŭ���Ǹ� ���Ӿ����� ��ȯ��Ű�� �ʹ�.
public class GameStart : MonoBehaviour
{
    public void OnGameStartBtnClick()
    {
        SceneManager.LoadScene(1);
    }
}
