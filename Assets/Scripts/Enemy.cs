using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �Ʒ��� ��� �̵��ϰ� �ʹ�.
// �ʿ�Ӽ� : �̵��ӵ�
// Ÿ�ٸ� ����ٴϱ�
// �ʿ�Ӽ� : Ÿ��

// ���� �� ����ȿ�� �߻���Ű�� �ʹ�.
// �ʿ�Ӽ� : ����ȿ�� ����
public class Enemy : MonoBehaviour
{
    // �ʿ�Ӽ� : �̵��ӵ�
    public float speed = 5;
    // �ʿ�Ӽ� : Ÿ��
    public Transform target;
    Vector3 dir;
    // �ʿ�Ӽ� : ����ȿ�� ����
    GameObject explosionFactory;
    // Start is called before the first frame update
    void Start()
    {
        // �������� ����ȿ���� �ε��ϰ� �ʹ�.
        explosionFactory = (GameObject)Resources.Load("Prefabs/Explosion");
        GameObject player = GameObject.Find("Player");
        // ���� Ÿ���� �ִٸ�
        //if(player != null)
        if (player)
        {
            target = player.transform;
            //70 % Ȯ���� �Ʒ��� ������ ���
            // 1. Ȯ���� ���ؾ� �Ѵ�.
            int randomic = Random.Range(0, 10);
            
            // Ÿ�� �������� �����ϱ�
            // 2. Ȯ���� 70% �� �������ϱ�
            if (randomic < 7) 
            {
                // 3. ������ �Ʒ��� �����ϰ� �ʹ�.
                dir = Vector3.down;
            }
            //�׷��������� 
            else
            {
                //Ÿ��������
                dir = target.position - transform.position;
                dir.Normalize();
            }
            
        }
        // �׷��� �ʴٸ�
        else
        {
            // �׳� ������ �Ʒ���
            dir = Vector3.down;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Ÿ�ٸ� ����ٴϱ�
        // P = P0 + vt
        // 1. �������ʿ�
        // direction = target - me
        // 2. �̵��ϰ�ʹ�.
        transform.position += dir * speed * Time.deltaTime;
    }

    // �ٸ� ��ü�� �ε����� �� ���� �װ� ���� �װ�... 
    private void OnCollisionEnter(Collision collision)
    {
        // ����ȿ�� �߻���Ű��
        GameObject explosion = Instantiate(explosionFactory);
        explosion.transform.position = transform.position;

        // ���� �ε��� �༮�� Bullet ���
        if (collision.gameObject.name.Contains("Bullet"))
        {
            // źâ�� ���� �ְ�ʹ�.
            // PlayerFire �� �ִ� źâ�� �Ѿ��� �־��־�� �Ѵ�.
            // 1. Player ���ӿ�����Ʈ�� �־���Ѵ�.
            // 2. PlayerFire �� �ʿ��ϴ�.
            PlayerFire player = target.GetComponent<PlayerFire>();
            // 3. źâ�� �Ѿ��� �־��ֱ�
            player.bulletPool.Add(collision.gameObject);
            collision.gameObject.SetActive(false);
        }
        // �׷��� ������
        else
        {
            // �÷��̾��� hp �� �ϳ� ����.
            // 1. Player �� �־���Ѵ�.
            //if (collision.gameObject.name.Contains("Player"))
            //if(collision.gameObject.tag == "Player")
            //if(collision.gameObject.layer == 8)
            // 2. PlayerHealth �� �־���Ѵ�.
            //PlayerHealth player = collision.gameObject.GetComponent<PlayerHealth>();
            //if(player)
            //{
            //    // 3. hp �� ���ҽ�Ű�� �ʹ�.
            //    // ���� hp �� -1 �ؼ� �����ϰ� �ʹ�.
            //    player.HP--;
            //    //player.SetHP(player.GetHP() - 1);
            //}
            PlayerHealth.Instance.HP--;
        }
        // ���� �װ�
        Destroy(gameObject);
    }
}
