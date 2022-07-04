using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//사용자가 발사버튼을 누르면 총알을 발사하고 싶다.
// 필요속성 : 총알공장, 총구(자기자신)
// 탄창에 총알을 미리 생성해 놓고 발사하고 싶다.
// 필요속성 : 탄창 -> 콜렉션(배열, 리스트)
// 탄창을 List 를 이용하도록 수정하고 싶다.
public class PlayerFire : MonoBehaviour
{
    
    // 필요속성 : 총알공장
    public GameObject bulletFactory;
    // 필요속성 : 탄창 -> 콜렉션(배열, 리스트)
    // GameObject[] bulletPool;
    public List<GameObject> bulletPool = new List<GameObject>();
    // 탄창에 들어갈 총알 개수
    public int bulletPoolSize = 10;

    // Start is called before the first frame update
    void Start()
    {
        // 태어났을 때 탄창에 총알을 미리 생성해서 넣고 싶다.
        // 1. 탄창도 있어야한다.
        //bulletPool = new GameObject[bulletPoolSize];
        for (int i = 0; i < bulletPoolSize; i++)
        {
            // 2. 총알이 있어야한다.
            GameObject bullet = Instantiate(bulletFactory);
            // 3. 탄창에 총알을 넣고 싶다.
            bulletPool.Add(bullet);
            // 4. 총알을 비활성화 시키자
            bullet.SetActive(false);
            // 만약 반복이 5번 됐다면 그만하고 싶다.
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
            // 탄창에서 비활성화 되어 있는 총알을 꺼내고 싶다.
            // 만약 탄창에 총알이 있다면
            if(bulletPool.Count > 0)
            {
                // 그 총알을 발사하고 싶다.
                // 1. 탄창에서 꺼낸 총알을 꺼낸다.
                GameObject bullet = bulletPool[0];
                bullet.SetActive(true);
                // 3. 총알을 발사하고 싶다.(위치)
                bullet.transform.position = transform.position;
                // 탄창에서 총알 제거하기 
                bulletPool.RemoveAt(0);
            }
        }
    }
}
