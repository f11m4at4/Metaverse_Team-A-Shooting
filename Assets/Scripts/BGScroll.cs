using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ����� ��ũ���ϰ� �ʹ�.
// �ʿ�Ӽ� : �ӵ�, ��Ƽ����
public class BGScroll : MonoBehaviour
{
    // �ʿ�Ӽ� : �ӵ�, ��Ƽ����
    public float speed = 0.2f;
    Material mat;
    // Start is called before the first frame update
    void Start()
    {
        // ��Ƽ���� ã��ʹ�.
        // 1. MeshRenderer ������Ʈ�� �־���Ѵ�.
        MeshRenderer mr = GetComponent<MeshRenderer>();
        mat = mr.material;
    }

    // Update is called once per frame
    void Update()
    {
        // ����� ��ũ���ϰ� �ʹ�.
        // P = P0 + vt
        mat.mainTextureOffset += Vector2.up * speed * Time.deltaTime;
    }
}
