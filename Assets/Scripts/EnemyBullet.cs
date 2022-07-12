using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ���� ���ϴ� �������� �̵��ϰ� �ʹ�.
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
        // ���� ���ϴ� �������� �̵��ϰ� �ʹ�.
        // P = P0 + vt
        transform.position += transform.up * speed * Time.deltaTime;
    }

    // �ٸ� ��ü�� �ε����� �� ���� �װ� ���� �װ�... 
    private void OnCollisionEnter(Collision collision)
    {
        // ����ȿ�� �߻���Ű��
        GameObject explosion = Instantiate(explosionFactory);
        explosion.transform.position = transform.position;

        Destroy(collision.gameObject);
        Destroy(gameObject);
    }
}
