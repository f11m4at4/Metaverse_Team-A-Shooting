using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 플레이어의 체력을 관리하고 싶다.
// 필요속성 : 체력
public class PlayerHealth : MonoBehaviour
{
    // 필요속성 : 체력
    int hp = 3;
    // HP => property 로 바꾸고 싶다.
    public int HP
    {
        get
        {
            return hp;
        }
        set
        {
            hp = value;
            if (hp <= 0)
            {
                // 없애자
                Destroy(gameObject);
            }
        }
    }

    public void SetHP(int value)
    {
        hp = value;
        if (hp <= 0)
        {
            // 없애자
            Destroy(gameObject);
        }
    }

    public int GetHP()
    {
        return hp;
    }

    // static 에 관리자 변수만 등록해 놓고 사용하자.
    public static PlayerHealth Instance = null;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool Save()
    {
        return true;
    }
}
