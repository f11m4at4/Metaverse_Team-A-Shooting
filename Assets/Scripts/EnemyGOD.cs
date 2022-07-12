using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ���� �ð��� �ѹ��� ���� ����� �ʹ�.
// �ʿ�Ӽ� : �����ð�, ����ð�, �� ����

// EnemyGOD ��ü�� Static ������ �� �ϳ��� �ΰ� �ʹ�.

public class EnemyGOD : MonoBehaviour
{
    //public static EnemyGOD Instance;
    
    // �ʿ�Ӽ� : �����ð�, ����ð�
    public float createTime = 2;
    float currentTime=0;
    //�� ����
    public GameObject enemyFactory;
    public GameObject enemyFactoryB;

    private void Awake()
    {
        //Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // ���� �ð��� �ѹ��� ���� ����� �ʹ�.
        // 1. �ð��� �귶���ϱ�
        // ����ð��� �����ϰ� �ʹ�.
        currentTime += Time.deltaTime;
        // 2. �����ð��� �����ϱ�
        // -> ���� ����ð��� �����ð��� �ʰ��Ͽ��ٸ�
        if (currentTime > createTime)
        {
            // 3. ���� ����� �ʹ�.
            //EnemyGOD �� 50 % �� Ȯ��
            int rand = Random.Range(0, 10);
            GameObject enemy = null;
            if (rand < 5)
            { 
                enemy = Instantiate(enemyFactory);
            }
            else
            {
                enemy = Instantiate(enemyFactoryB);
            }
            enemy.transform.position = transform.position;
            currentTime = 0;
        }
    }
}
