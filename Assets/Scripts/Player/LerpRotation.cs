using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpRotation : MonoBehaviour
{
    [SerializeField]
    float speed;

    Vector3 angle;
    bool canLerp = false;
    float t = 0f;
    Vector3 v;
    public void SetAngle(float angle)
    {
        canLerp = true;
        this.angle.y += angle;
        if (this.angle.y > 360f)
        {
            this.angle.y = 360f - this.angle.y;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canLerp)
        {
            v.y += speed * Time.deltaTime;
            if (v.y <= angle.y)
            {
                transform.eulerAngles = v;
            }
            else
            {
                v.y = angle.y;
                transform.eulerAngles = v;
            }
            //Debug.Log(Vector3.up * Time.deltaTime * 90f);
            //transform.Rotate(Vector3.up * Time.deltaTime * 90f);
            //if (transform.rotation.eulerAngles.y >= angle.y)
            //{
            //    transform.Rotate(0f, 90f, 0f);
            //    canLerp = false;
            //}
        }

    }
}
