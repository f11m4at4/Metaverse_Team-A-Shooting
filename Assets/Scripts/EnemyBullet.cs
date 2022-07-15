using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 지가 향하는 방향으로 이동하고 싶다.
public class EnemyBullet : MonoBehaviour
{
    public float speed = 5;
    public GameObject explosionFactory;

    Transform target;
    public float angle = 40;
    float currentTime;
    public float rotateTime = 0.2f;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player").transform;
        transform.up = Vector3.down;
    }

    Vector3 vel;
    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;

        //transform.up = Vector3.Lerp(myV, targetV, 5 * Time.deltaTime);
        if (currentTime >= rotateTime)
        {
            Vector3 targetV = target.position - transform.position;
            Vector3 myV = transform.up;
            Vector3 axis = Vector3.Cross(targetV, myV);
            float deltaAngle = angle;
            if(targetV.magnitude < 3)
            {
                deltaAngle = 5;
            }
            transform.rotation *= Quaternion.AngleAxis(deltaAngle, axis);
            currentTime = 0;
        }
        // 지가 향하는 방향으로 이동하고 싶다.
        // P = P0 + vt
        // v = v0 + at
        transform.position += transform.up * speed * Time.deltaTime;
    }

    // 다른 물체와 부딪혔을 때 갸도 죽고 나도 죽고... 
    private void OnCollisionEnter(Collision collision)
    {
        EnemyBullet.CollisionEnemy(explosionFactory, transform, collision, gameObject);
    }

    public static void CollisionEnemy(GameObject explosionFactory, Transform transform, Collision collision, GameObject gameObject)
    {
        // 폭발효과 발생시키기
        GameObject explosion = Instantiate(explosionFactory);
        explosion.transform.position = transform.position;

        // 만약 부딪힌 녀석이 Bullet 라면
        if (collision.gameObject.name.Contains("Bullet"))
        {
            GameObject target = GameObject.Find("Player");
            if (target)
            {
                PlayerFire player = target.GetComponent<PlayerFire>();
                // 3. 탄창에 총알을 넣어주기
                player.bulletPool.Add(collision.gameObject);
                collision.gameObject.SetActive(false);
            }
        }
        // 그렇지 않으면
        else
        {
            PlayerHealth.Instance.HP--;
        }
        Destroy(gameObject);
    }
}
