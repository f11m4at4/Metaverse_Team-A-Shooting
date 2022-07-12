using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 지가 향하는 방향으로 이동하고 싶다.
public class EnemyBullet : MonoBehaviour
{
    public float speed = 5;
    public GameObject explosionFactory;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 지가 향하는 방향으로 이동하고 싶다.
        // P = P0 + vt
        transform.position += transform.up * speed * Time.deltaTime;
    }

    // 다른 물체와 부딪혔을 때 갸도 죽고 나도 죽고... 
    private void OnCollisionEnter(Collision collision)
    {
        // 폭발효과 발생시키기
        GameObject explosion = Instantiate(explosionFactory);
        explosion.transform.position = transform.position;

        Destroy(collision.gameObject);
        Destroy(gameObject);
    }
}
