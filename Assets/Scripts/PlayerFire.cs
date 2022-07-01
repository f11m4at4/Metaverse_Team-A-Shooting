using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//사용자가 발사버튼을 누르면 총알을 발사하고 싶다.
// 필요속성 : 총알공장, 총구(자기자신)
// 탄창에 총알을 미리 생성해 놓고 발사하고 싶다.
// 필요속성 : 탄창 -> 콜렉션(배열, 리스트)
public class PlayerFire : MonoBehaviour
{
    
    // 필요속성 : 총알공장
    public GameObject bulletFactory;
    // Start is called before the first frame update
    void Start()
    {
        // for(초깃값설정;조건;증감)
        for(int i=0;i<100;i++)
        {
            print(i);
        }
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
