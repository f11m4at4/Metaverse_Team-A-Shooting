using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HOJoystick
{
    static bool bDown = false;
    static Vector3 firstPosition;

    public static float GetAxis(string axis)
    {
#if UNITY_ANDROID || UNITY_IPHONE
        bool bJoystick = true;
#else
        bool bJoystick = false;
#endif
        if(bJoystick == false)
        {
            return Input.GetAxisRaw(axis);
        }
        if(axis == "Horizontal")
        {
            return GetDirection().x;
        }
        else if(axis == "Vertical")
        {
            return GetDirection().y;
        }

        return 0;
    }

    // ���ⱸ�ϱ�
    public static Vector3 GetDirection()
    {
        Vector3 dir = Vector3.zero;
        // ����ڰ� ó�� Ŭ���ߴٸ�
        if(Input.GetButtonDown("Fire1"))
        {
            // Ŭ�� ���̴�.
            bDown = true;
            // ù��° ���� Ŭ���� ������ ���콺 ��ġ
            firstPosition = Input.mousePosition;
        }
        if (Input.GetButtonUp("Fire1"))
        {
            bDown = false;
        }
        // ���콺�� Ŭ�����̶��
        if(bDown)
        {
            //������ ���� -> ���ⱸ�ϱ�
            dir = Input.mousePosition - firstPosition;
        }

        return dir;//.normalized;
    }
}
