using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// ������ �����ϰ� UI ǥ�ø� �ϰ� �ʹ�.
// �ʿ�Ӽ� : ��������, �ְ�����, ��������UI, �ְ�����UI

// ������ �����ϰ�
// -> ���� ���� ������ ���� ���� +1 ����
// -> ���� ������ �ְ������� �Ѿ�� �ְ����� �������ֱ�
public class ScoreManager : MonoBehaviour
{
    // �ʿ�Ӽ� : ��������, �ְ�����, ��������UI, �ְ�����UI
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
            // ���� ������ ���ŵ� �� UI �� ��������� �Ѵ�.
            curScoreUI.text = "Current Score : " + curScore;

            // -> ���� ������ �ְ������� �Ѿ�� �ְ����� �������ֱ�
            if (curScore > topScore)
            {
                topScore = curScore;
                // ���� ������ ���ŵ� �� UI �� ��������� �Ѵ�.
                topScoreUI.text = "Top Score : " + topScore;

                // ���� �����ϱ�
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
        // �ؽ�Ʈ���� ����
        curScoreUI.text = "Current Score : " + curScore;
        topScoreUI.text = "Top Score : " + topScore;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
