using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
// 계속 위로 이동하고 싶다.
// 필요속성 : 속도
public class Bullet : MonoBehaviourPun
{
    // 필요속성 : 속도
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
            // 계속 위로 이동하고 싶다.
            // 2. 방향이 필요
            Vector3 dir = transform.up;
            dir.Normalize();
            // 3. 이동하고 싶다.
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
        // 폭발효과 발생시키기
        GameObject explosion = Instantiate(explosionFactory);
        explosion.transform.position = pos;
    }
}
