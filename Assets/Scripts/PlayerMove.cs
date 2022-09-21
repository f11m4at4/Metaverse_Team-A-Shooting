using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using Photon.Pun;
// 사용자 입력에 따라 상하좌우로 이동하고 싶다.
// 필요속성 : 이동속도
public class PlayerMove : MonoBehaviourPun, IPunObservable
{
    // 필요속성 : 이동속도
    public float speed = 5;

    float width;
    // Start is called before the first frame update
    void Start()
    {
        float worldSize = Camera.main.orthographicSize * 2;
        float meterPerPixel = worldSize / Screen.height;
        width = meterPerPixel * Screen.width * 0.5f - 0.5f;
    }

    // Update is called once per frame
    void Update()
    {        
        // 게임상태가 Playing 이 아니면??
        if (GameManager.Instance.m_state != GameManager.GameState.Playing)
        {
            // -> 처리하지 못하게 하자.
            return;
        }

        if(isMine)
        {
            // 사용자 입력에 따라 상하좌우로 이동하고 싶다.
            // 1. 사용자의 입력에 따라
            float h = HOJoystick.GetAxis("Horizontal");
            float v = HOJoystick.GetAxis("Vertical");
            photonView.RPC("RpcMoveDir", RpcTarget.MasterClient, h, v);
        }

        if(PhotonNetwork.IsMasterClient == false)
        {
            transform.position = Vector3.Lerp(transform.position, receivePos, 30 * Time.deltaTime);
        }
        

        if(dir.sqrMagnitude > 0)
        {
            // 3. 이동하고 싶다.
            // P = P0 + vt
            Vector3 myPos = transform.position;
            myPos += dir * speed * Time.deltaTime;
            // 왼쪽으로 -4.3, 오른쪽으로 +4.3 넘어가지 않도록 하고싶다.
            myPos.x = Mathf.Clamp(myPos.x, -width, width);
        
            transform.position = myPos;
        }
    }

    Vector3 dir;
    public int ownerViewId;
    //나만의 isMine;
    public bool isMine;

    Vector3 receivePos;
    public void SetOwner(int viewId)
    {
        photonView.RPC("RpcSetOwner", RpcTarget.All, viewId);
    }
    
    [PunRPC]
    void RpcSetOwner(int viewId)
    {
        ownerViewId = viewId;
        isMine = GameManager.Instance.myPhotnView.ViewID == viewId;       
    }

    [PunRPC]
    void RpcMoveDir(float h, float v)
    {
        // 2. 방향이 필요
        dir = Vector3.right * h + Vector3.up * v;
        dir.Normalize();
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if(stream.IsWriting)
        {
            stream.SendNext(transform.position);
        }
        else
        {
            receivePos = (Vector3)stream.ReceiveNext();
        }
    }
}
