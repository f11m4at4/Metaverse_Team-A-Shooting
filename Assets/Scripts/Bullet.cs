using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
// ��� ���� �̵��ϰ� �ʹ�.
// �ʿ�Ӽ� : �ӵ�
public class Bullet : MonoBehaviourPun
{
    // �ʿ�Ӽ� : �ӵ�
    public float speed = 10;

    public PlayerFire owner;
    // Start is called before the first frame update
    void Start()
    {
        if(PhotonNetwork.IsMasterClient)
        {
            GetComponent<Collider>().enabled = true;
        }
    }

    public void SetOwner(PlayerFire pm)
    {
        owner = pm;
    }

    // Update is called once per frame
    void Update()
    {
        if(photonView.IsMine)
        {
            // ��� ���� �̵��ϰ� �ʹ�.
            // 2. ������ �ʿ�
            Vector3 dir = transform.up;
            dir.Normalize();
            // 3. �̵��ϰ� �ʹ�.
            // P = P0 + vt
            transform.position += dir * speed * Time.deltaTime;
        }        
    }

    public GameObject explosionFactory;
    private void OnTriggerEnter(Collider other)
    {
        photonView.RPC("RpcExplo", RpcTarget.All, transform.position);

        PhotonNetwork.Destroy(gameObject);
    }
    [PunRPC]
    void RpcExplo(Vector3 pos)
    {
        // ����ȿ�� �߻���Ű��
        GameObject explosion = Instantiate(explosionFactory);
        explosion.transform.position = pos;
    }
}
