using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyZone : MonoBehaviour
{
    // 나랑 부딪힌 녀석은 다 없애버리겠다.
    private void OnTriggerEnter(Collider other)
    {
        // 만약 부딪힌 녀석이 Bullet 라면
        // Layer 로 변경
        //if (other.gameObject.name.Contains("Bullet"))
        if(other.gameObject.layer == LayerMask.NameToLayer("PlayerBullet"))
        {
            GameObject target = GameObject.Find("Player");
            PlayerFire player = target.GetComponent<PlayerFire>();
            // 3. 탄창에 총알을 넣어주기
            player.bulletPool.Add(other.gameObject);
            // 탄창에 집어 넣고싶다.
            other.gameObject.SetActive(false);
        }
        // 그렇지 않으면
        else
        {
            // 없애자
            Destroy(other.gameObject);
        }
    }
}
