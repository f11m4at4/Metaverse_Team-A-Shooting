using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
// 게임의 진행 상태를 관리하고 싶다.
// 필요속성 : 현재상태, Ready, Start, Playing, GameOver
public class GameManager : MonoBehaviourPun
{
    // 필요속성 : 현재상태, Ready, Start, Playing, GameOver
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


    public Dictionary<int, PhotonView> dicPlayers = new Dictionary<int, PhotonView>();
    public List<PhotonView> listPlayers = new List<PhotonView>();

    public PhotonView myPhotnView;

    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.SendRate = 60;
        PhotonNetwork.SerializationRate = 60;
    }

    public void CreateEmptyPlayer()
    {
        GameObject go = PhotonNetwork.Instantiate("EmptyPlayer", Vector3.zero, Quaternion.identity);
        myPhotnView = go.GetComponent<PhotonView>();
    }

    public void AddPlayer(PhotonView pv)
    {
        dicPlayers[pv.ViewID] = pv;
        listPlayers.Add(pv);

        if(PhotonNetwork.IsMasterClient)
        {
            GameObject go = PhotonNetwork.Instantiate("Player", Vector3.zero, Quaternion.identity);
            go.GetComponent<PlayerMove>().SetOwner(pv.ViewID);
        }
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

    // 2초간 기다리렸다가 상태를 Start 로 변경하고 싶다.
    float currentTime = 0;
    public float readyDelayTime = 2;
    public float startDelayTime = 2;
    private void ReadyState()
    {
        // 2초간 기다리렸다가 상태를 Start 로 변경하고 싶다.
        // 1. 시간이 흘렀으니까
        currentTime += Time.deltaTime;
        // 2. 시간이 됐으니까.
        if (currentTime > readyDelayTime)
        {
            // 3. 상태를 Start 로 변경
            m_state = GameState.Start;
            currentTime = 0;
        }
    }

    // 2초간 기다리렸다가 상태를 Playing 로 변경하고 싶다.
    private void StartState()
    {
        // 1. 시간이 흘렀으니까
        currentTime += Time.deltaTime;
        // 2. 시간이 됐으니까.
        if (currentTime > startDelayTime)
        {
            // 3. 상태를 Start 로 변경
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
