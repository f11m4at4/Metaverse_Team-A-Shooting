using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//����ڰ� �߻��ư�� ������ �Ѿ��� �߻��ϰ� �ʹ�.
// �ʿ�Ӽ� : �Ѿ˰���, �ѱ�(�ڱ��ڽ�)
public class PlayerFire : MonoBehaviour
{
    // �ʿ�Ӽ� : �Ѿ˰���
    public GameObject bulletFactory;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //����ڰ� �߻��ư�� ������ �Ѿ��� �߻��ϰ� �ʹ�.
        // 1. ����ڰ� �߻��ư�� �������ϱ�
        // -> ���� ����ڰ� �߻��ư�� �����ٸ�
        if (Input.GetButtonDown("Fire1"))
        {
            // 2. �Ѿ��� �־���Ѵ�.
            GameObject bullet = Instantiate(bulletFactory);
            // 3. �Ѿ��� �߻��ϰ� �ʹ�.(��ġ)
            bullet.transform.position = transform.position;
        }
    }
}
