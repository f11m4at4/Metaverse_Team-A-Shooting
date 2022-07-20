using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

// ����� �Է¿� ���� �����¿�� �̵��ϰ� �ʹ�.
// �ʿ�Ӽ� : �̵��ӵ�
public class PlayerMove : MonoBehaviour
{
    // �ʿ�Ӽ� : �̵��ӵ�
    public float speed = 5;

    float width;
    // Start is called before the first frame update
    void Start()
    {
        float worldSize = Camera.main.orthographicSize * 2;
        float meterPerPixel = worldSize / Screen.height;
        width = meterPerPixel * Screen.width * 0.5f - 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        // ���ӻ��°� Playing �� �ƴϸ�??
        if (GameManager.Instance.m_state != GameManager.GameState.Playing)
        {
            // -> ó������ ���ϰ� ����.
            return;
        }

        // ����� �Է¿� ���� �����¿�� �̵��ϰ� �ʹ�.
        // 1. ������� �Է¿� ����
        float h = HOJoystick.GetAxis("Horizontal");
        float v = HOJoystick.GetAxis("Vertical");
        // 2. ������ �ʿ�
        Vector3 dir = Vector3.right * h + Vector3.up * v;
        dir.Normalize();
        // 3. �̵��ϰ� �ʹ�.
        // P = P0 + vt
        Vector3 myPos = transform.position;
        myPos += dir * speed * Time.deltaTime;
        // �������� -4.3, ���������� +4.3 �Ѿ�� �ʵ��� �ϰ�ʹ�.
        myPos.x = Mathf.Clamp(myPos.x, -width, width);

        
        transform.position = myPos;
    }
}
