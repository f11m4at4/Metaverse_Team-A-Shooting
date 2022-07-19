using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// 버튼이 클릭되면 게임씬으로 전환시키고 싶다.
public class GameStart : MonoBehaviour
{
    public void OnGameStartBtnClick()
    {
        SceneManager.LoadScene(1);
    }
}
