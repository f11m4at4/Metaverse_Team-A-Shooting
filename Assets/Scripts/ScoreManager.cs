using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 점수를 관리하고 UI 표시를 하고 싶다.
// 필요속성 : 현재점수, 최고점수, 현재점수UI, 최고점수UI

// 점수를 관리하고
// -> 적을 잡을 때마다 현재 점수 +1 증가
// -> 현재 점수가 최고점수를 넘어서면 최고점수 갱신해주기
public class ScoreManager : MonoBehaviour
{
    // 필요속성 : 현재점수, 최고점수, 현재점수UI, 최고점수UI
    int curScore = 0;
    int topScore = 0;
    public Text curScoreUI;
    public Text topScoreUI;

    public int CurScore
    { 
        get 
        { 
            return curScore; 
        } 
        set
        {
            curScore = value;
            // 현재 점수가 갱신될 때 UI 도 갱신해줘야 한다.
            curScoreUI.text = "Current Score : " + curScore;

            // -> 현재 점수가 최고점수를 넘어서면 최고점수 갱신해주기
            if (curScore > topScore)
            {
                topScore = curScore;
                // 현재 점수가 갱신될 때 UI 도 갱신해줘야 한다.
                topScoreUI.text = "Top Score : " + topScore;

                // 점수 저장하기
                PlayerPrefs.SetInt("Score", topScore);
            }
        }
    }

    public static ScoreManager Instance;
    private void Awake()
    {
        Instance = this;

        topScore = PlayerPrefs.GetInt("Score", 0);
    }

    void Start()
    {
        // 텍스트값을 설정
        curScoreUI.text = "Current Score : " + curScore;
        topScoreUI.text = "Top Score : " + topScore;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
