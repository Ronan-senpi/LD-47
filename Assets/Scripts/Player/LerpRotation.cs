using Assets.Scripts;
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
            this.angle.y = this.angle.y - 360f;
        }
        SetMoveAxis();
    }
    private void SetMoveAxis()
    {
        switch (angle.y)
        {
            case 360:
            case 0:
                v.z = GameManager.Instance.GetPlayer().transform.position.z;
                GameManager.Instance.SetMoveAxis(Axis.x, 1);
                break; ;
            case 180:
                v.z = GameManager.Instance.GetPlayer().transform.position.z;
                GameManager.Instance.SetMoveAxis(Axis.x, -1);
                break;
            case 90:
                v.x = GameManager.Instance.GetPlayer().transform.position.x;
                GameManager.Instance.SetMoveAxis(Axis.z, 1);
                break;
            case 270:
                v.x = GameManager.Instance.GetPlayer().transform.position.x;
                GameManager.Instance.SetMoveAxis(Axis.z, -1);
                break;
            default:
                break;
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

            v.x = 0;
            v.z = 0;    
            v.y += speed * Time.deltaTime;
            if (v.y <= angle.y)
            {
                transform.eulerAngles = v; 
            }
            else
            {
                v.y = angle.y;
                transform.eulerAngles = v;
                canLerp = false;
                GameEvents.Instance.FreeCam();
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
