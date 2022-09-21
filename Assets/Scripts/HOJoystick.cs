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

    // 방향구하기
    public static Vector3 GetDirection()
    {
        Vector3 dir = Vector3.zero;
        // 사용자가 처음 클릭했다면
        if(Input.GetButtonDown("Fire1"))
        {
            // 클릭 중이다.
            bDown = true;
            // 첫번째 점은 클릭한 지점의 마우스 위치
            firstPosition = Input.mousePosition;
        }
        if (Input.GetButtonUp("Fire1"))
        {
            bDown = false;
        }
        // 마우스가 클릭중이라면
        if(bDown)
        {
            //벡터의 뺄셈 -> 방향구하기
            dir = Input.mousePosition - firstPosition;
        }

        return dir;//.normalized;
    }
}
