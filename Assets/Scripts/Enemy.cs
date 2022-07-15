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
        EnemyBullet.CollisionEnemy(explosionFactory, transform, collision, gameObject);
        // ���� �ø���
        ScoreManager.Instance.CurScore++;
    }
}
