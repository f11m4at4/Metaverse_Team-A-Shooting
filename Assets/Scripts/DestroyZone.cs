using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyZone : MonoBehaviour
{
    // ���� �ε��� �༮�� �� ���ֹ����ڴ�.
    private void OnTriggerEnter(Collider other)
    {
        // ���� �ε��� �༮�� Bullet ���
        // Layer �� ����
        //if (other.gameObject.name.Contains("Bullet"))
        if(other.gameObject.layer == LayerMask.NameToLayer("PlayerBullet"))
        {
            GameObject target = GameObject.Find("Player");
            PlayerFire player = target.GetComponent<PlayerFire>();
            // 3. źâ�� �Ѿ��� �־��ֱ�
            player.bulletPool.Add(other.gameObject);
            // źâ�� ���� �ְ�ʹ�.
            other.gameObject.SetActive(false);
        }
        // �׷��� ������
        else
        {
            // ������
            Destroy(other.gameObject);
        }
    }
}
