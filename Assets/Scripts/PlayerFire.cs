using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//사용자가 발사버튼을 누르면 총알을 발사하고 싶다.
// 필요속성 : 총알공장, 총구(자기자신)
public class PlayerFire : MonoBehaviour
{
    // 필요속성 : 총알공장
    public GameObject bulletFactory;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //사용자가 발사버튼을 누르면 총알을 발사하고 싶다.
        // 1. 사용자가 발사버튼을 눌렀으니까
        // -> 만약 사용자가 발사버튼을 눌렀다면
        if (Input.GetButtonDown("Fire1"))
        {
            // 2. 총알이 있어야한다.
            GameObject bullet = Instantiate(bulletFactory);
            // 3. 총알을 발사하고 싶다.(위치)
            bullet.transform.position = transform.position;
        }
    }
}
