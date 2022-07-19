using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ������ ���� ���¸� �����ϰ� �ʹ�.
// �ʿ�Ӽ� : �������, Ready, Start, Playing, GameOver
public class GameManager : MonoBehaviour
{
    // �ʿ�Ӽ� : �������, Ready, Start, Playing, GameOver
    //[System.NonSerialized]
    public enum GameState
    {
        Ready,
        Start,
        Playing,
        GameOver
    };

    //[SerializeField]
    public GameState m_state = GameState.Ready;

    public static GameManager Instance;
    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch(m_state)
        {
            case GameState.Ready:
                ReadyState();
                break;
            case GameState.Start:
                StartState();
                break;
            case GameState.Playing:
                PlayingState();
                break;
            case GameState.GameOver:
                GameOverState();
                break;
        }
    }

    // 2�ʰ� ��ٸ��ȴٰ� ���¸� Start �� �����ϰ� �ʹ�.
    float currentTime = 0;
    public float readyDelayTime = 2;
    public float startDelayTime = 2;
    private void ReadyState()
    {
        // 2�ʰ� ��ٸ��ȴٰ� ���¸� Start �� �����ϰ� �ʹ�.
        // 1. �ð��� �귶���ϱ�
        currentTime += Time.deltaTime;
        // 2. �ð��� �����ϱ�.
        if (currentTime > readyDelayTime)
        {
            // 3. ���¸� Start �� ����
            m_state = GameState.Start;
            currentTime = 0;
        }
    }

    // 2�ʰ� ��ٸ��ȴٰ� ���¸� Playing �� �����ϰ� �ʹ�.
    private void StartState()
    {
        // 1. �ð��� �귶���ϱ�
        currentTime += Time.deltaTime;
        // 2. �ð��� �����ϱ�.
        if (currentTime > startDelayTime)
        {
            // 3. ���¸� Start �� ����
            m_state = GameState.Playing;
            currentTime = 0;
        }
    }

    private void PlayingState()
    {
        
    }

    private void GameOverState()
    {
        
    }
}
