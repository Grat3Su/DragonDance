using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public enum KeyMode
    {
        GETAXIS, KEYDOWN
    }

    public enum MoveType
    {
        POSITION, TRANSLATE,RIGID
    }

    Rigidbody rigid;
    public KeyMode kmode;
    public MoveType mtype;
    public float speed = 5.0f;
    void Start()
    {
        rigid = gameObject.GetComponent<Rigidbody>();  
    }

    // Update is called once per frame
    void Update()
    {
        float h = 0;
        float v = 0;

        // 키 타입
        if(kmode == KeyMode.GETAXIS)
        {
            h = Input.GetAxis("Horizontal");
            v = Input.GetAxis("Vertical");

            h = h * speed * Time.deltaTime;
            v = v * speed * Time.deltaTime;
        }
        else if(kmode == KeyMode.KEYDOWN)
        {
            if (Input.GetKey(KeyCode.W))
            {
                v = speed * Time.deltaTime;
            }
            else if (Input.GetKey(KeyCode.S))
            {
                v = -speed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.A))
            {
                h = -speed * Time.deltaTime;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                h = speed * Time.deltaTime;
            }
        }

        // 움직임 타입
        if(mtype == MoveType.POSITION)
        {
            PositionMove(h, v);
        }
        else if(mtype == MoveType.RIGID)
        {
            RigidMove(h, v);
        }
        else if(mtype == MoveType.TRANSLATE)
        {
            TranslateMove(h, v);
        }
    }

    private void PositionMove(float h,  float v)
    {
        transform.position += new Vector3(h, v, 0);
    }

    void TranslateMove(float h, float v)
    {
        transform.Translate(Vector3.right * h);
        transform.Translate(Vector3.up * v);
    }

    void RigidMove(float h, float v)
    {
        rigid.AddForce(new Vector3(h * 10, v * 10,0));
    }
}
