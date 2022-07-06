using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �÷��̾��� ü���� �����ϰ� �ʹ�.
// �ʿ�Ӽ� : ü��
public class PlayerHealth : MonoBehaviour
{
    // �ʿ�Ӽ� : ü��
    int hp = 3;
    // HP => property �� �ٲٰ� �ʹ�.
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
                // ������
                Destroy(gameObject);
            }
        }
    }

    public void SetHP(int value)
    {
        hp = value;
        if (hp <= 0)
        {
            // ������
            Destroy(gameObject);
        }
    }

    public int GetHP()
    {
        return hp;
    }

    // static �� ������ ������ ����� ���� �������.
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
