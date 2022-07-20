using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class joystick : MonoBehaviour
{
    //조이스틱 ui 좌표를 가져온다.
    //마우스 포인터 좌표를 가져온다.
    RectTransform rectTransform;
    
    public RectTransform bg;
    //조이스틱의 현재좌표를 저장한다.
    Vector2 originPosition;
    // 마우스 좌표와 bg사이 거리
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
        //마우스를 클릭했을때
        // 마우스를 계속누르고 있을때
        // 마우스를 떼고있을때
        if (Input.GetMouseButton(0))
        {
            bDown = true;
            //  dir = (Vector2)Input.mousePosition - rectTransform.position;
            distance = HOJoystick.GetDirection();
            //distance = distance.normalized * 100;
            distance = Vector2.ClampMagnitude(distance, 100);
            //마우스를 클릭하게 되면 화면에 그좌표가 남게됨
            //마우스가 남긴좌표와 흰배경 사이 거리를 알아야 됨
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
