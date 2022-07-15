using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ���� ���ϴ� �������� �̵��ϰ� �ʹ�.
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
        // ���� ���ϴ� �������� �̵��ϰ� �ʹ�.
        // P = P0 + vt
        // v = v0 + at
        transform.position += transform.up * speed * Time.deltaTime;
    }

    // �ٸ� ��ü�� �ε����� �� ���� �װ� ���� �װ�... 
    private void OnCollisionEnter(Collision collision)
    {
        EnemyBullet.CollisionEnemy(explosionFactory, transform, collision, gameObject);
    }

    public static void CollisionEnemy(GameObject explosionFactory, Transform transform, Collision collision, GameObject gameObject)
    {
        // ����ȿ�� �߻���Ű��
        GameObject explosion = Instantiate(explosionFactory);
        explosion.transform.position = transform.position;

        // ���� �ε��� �༮�� Bullet ���
        if (collision.gameObject.name.Contains("Bullet"))
        {
            GameObject target = GameObject.Find("Player");
            if (target)
            {
                PlayerFire player = target.GetComponent<PlayerFire>();
                // 3. źâ�� �Ѿ��� �־��ֱ�
                player.bulletPool.Add(collision.gameObject);
                collision.gameObject.SetActive(false);
            }
        }
        // �׷��� ������
        else
        {
            PlayerHealth.Instance.HP--;
        }
        Destroy(gameObject);
    }
}
