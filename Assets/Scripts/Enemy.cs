using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �Ʒ��� ��� �̵��ϰ� �ʹ�.
// �ʿ�Ӽ� : �̵��ӵ�
// Ÿ�ٸ� ����ٴϱ�
// �ʿ�Ӽ� : Ÿ��
public class Enemy : MonoBehaviour
{
    // �ʿ�Ӽ� : �̵��ӵ�
    public float speed = 5;
    // �ʿ�Ӽ� : Ÿ��
    public Transform target;
    Vector3 dir;

    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.Find("Player");
        // ���� Ÿ���� �ִٸ�
        //if(player != null)
        if (player)
        {
            // Ÿ�� �������� �����ϱ�
            target = player.transform;
            dir = target.position - transform.position;
            dir.Normalize();
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
        // ���� �װ�
        Destroy(collision.gameObject);
        // ���� �װ�
        Destroy(gameObject);
    }
}
