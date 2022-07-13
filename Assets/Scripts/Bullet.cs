using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 계속 위로 이동하고 싶다.
// 필요속성 : 속도
public class Bullet : MonoBehaviour
{
    // 필요속성 : 속도
    public float speed = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 계속 위로 이동하고 싶다.
        // 2. 방향이 필요
        Vector3 dir = transform.up;
        dir.Normalize();
        // 3. 이동하고 싶다.
        // P = P0 + vt
        transform.position += dir * speed * Time.deltaTime;
    }
}
