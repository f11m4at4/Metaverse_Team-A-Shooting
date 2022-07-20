using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class joystick : MonoBehaviour
{
    //���̽�ƽ ui ��ǥ�� �����´�.
    //���콺 ������ ��ǥ�� �����´�.
    RectTransform rectTransform;
    
    public RectTransform bg;
    //���̽�ƽ�� ������ǥ�� �����Ѵ�.
    Vector2 originPosition;
    // ���콺 ��ǥ�� bg���� �Ÿ�
    Vector2 distance;
    public Vector2 dir;
    Vector2 curPos;
    float count = 0;


    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }
    void Start()
    {
        originPosition = rectTransform.position;
    }
    bool bDown = false;
    // Update is called once per frame
    void Update()
    {
        //���콺�� Ŭ��������
        // ���콺�� ��Ӵ����� ������
        // ���콺�� ����������
        if (Input.GetMouseButton(0))
        {
            bDown = true;
            //  dir = (Vector2)Input.mousePosition - rectTransform.position;
            distance = HOJoystick.GetDirection();
            //distance = distance.normalized * 100;
            distance = Vector2.ClampMagnitude(distance, 100);
            //���콺�� Ŭ���ϰ� �Ǹ� ȭ�鿡 ����ǥ�� ���Ե�
            //���콺�� ������ǥ�� ���� ���� �Ÿ��� �˾ƾ� ��
            rectTransform.position = originPosition + distance;
        }
        if (Input.GetMouseButtonUp(0))
        {
            bDown = false;
            
            count = 0;
        }

        if(bDown == false)
        {
            rectTransform.position = Vector3.Lerp(rectTransform.position, originPosition, 10 * Time.deltaTime);
        }
    }
}
