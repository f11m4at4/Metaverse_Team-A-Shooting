using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//����ڰ� �߻��ư�� ������ �Ѿ��� �߻��ϰ� �ʹ�.
// �ʿ�Ӽ� : �Ѿ˰���, �ѱ�(�ڱ��ڽ�)
// źâ�� �Ѿ��� �̸� ������ ���� �߻��ϰ� �ʹ�.
// �ʿ�Ӽ� : źâ -> �ݷ���(�迭, ����Ʈ)
// źâ�� List �� �̿��ϵ��� �����ϰ� �ʹ�.
public class PlayerFire : MonoBehaviour
{
    
    // �ʿ�Ӽ� : �Ѿ˰���
    public GameObject bulletFactory;
    // �ʿ�Ӽ� : źâ -> �ݷ���(�迭, ����Ʈ)
    // GameObject[] bulletPool;
    public List<GameObject> bulletPool = new List<GameObject>();
    // źâ�� �� �Ѿ� ����
    public int bulletPoolSize = 10;

    // Start is called before the first frame update
    void Start()
    {
        // �¾�� �� źâ�� �Ѿ��� �̸� �����ؼ� �ְ� �ʹ�.
        // 1. źâ�� �־���Ѵ�.
        //bulletPool = new GameObject[bulletPoolSize];
        for (int i = 0; i < bulletPoolSize; i++)
        {
            // 2. �Ѿ��� �־���Ѵ�.
            GameObject bullet = Instantiate(bulletFactory);
            // 3. źâ�� �Ѿ��� �ְ� �ʹ�.
            bulletPool.Add(bullet);
            // 4. �Ѿ��� ��Ȱ��ȭ ��Ű��
            bullet.SetActive(false);
            // ���� �ݺ��� 5�� �ƴٸ� �׸��ϰ� �ʹ�.
        }
    }

    // Update is called once per frame
    void Update()
    {
        //����ڰ� �߻��ư�� ������ �Ѿ��� �߻��ϰ� �ʹ�.
        // 1. ����ڰ� �߻��ư�� �������ϱ�
        // -> ���� ����ڰ� �߻��ư�� �����ٸ�
        if (Input.GetButtonDown("Fire1"))
        {
            // źâ���� ��Ȱ��ȭ �Ǿ� �ִ� �Ѿ��� ������ �ʹ�.
            // ���� źâ�� �Ѿ��� �ִٸ�
            if(bulletPool.Count > 0)
            {
                // �� �Ѿ��� �߻��ϰ� �ʹ�.
                // 1. źâ���� ���� �Ѿ��� ������.
                GameObject bullet = bulletPool[0];
                bullet.SetActive(true);
                // 3. �Ѿ��� �߻��ϰ� �ʹ�.(��ġ)
                bullet.transform.position = transform.position;
                // źâ���� �Ѿ� �����ϱ� 
                bulletPool.RemoveAt(0);
            }
        }
    }
}
