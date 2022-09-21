using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using Photon.Pun;
// ����� �Է¿� ���� �����¿�� �̵��ϰ� �ʹ�.
// �ʿ�Ӽ� : �̵��ӵ�
public class PlayerMove : MonoBehaviourPun, IPunObservable
{
    // �ʿ�Ӽ� : �̵��ӵ�
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
        // ���ӻ��°� Playing �� �ƴϸ�??
        if (GameManager.Instance.m_state != GameManager.GameState.Playing)
        {
            // -> ó������ ���ϰ� ����.
            return;
        }

        if(isMine)
        {
            // ����� �Է¿� ���� �����¿�� �̵��ϰ� �ʹ�.
            // 1. ������� �Է¿� ����
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
            // 3. �̵��ϰ� �ʹ�.
            // P = P0 + vt
            Vector3 myPos = transform.position;
            myPos += dir * speed * Time.deltaTime;
            // �������� -4.3, ���������� +4.3 �Ѿ�� �ʵ��� �ϰ�ʹ�.
            myPos.x = Mathf.Clamp(myPos.x, -width, width);
        
            transform.position = myPos;
        }
    }

    Vector3 dir;
    public int ownerViewId;
    //������ isMine;
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
        // 2. ������ �ʿ�
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
