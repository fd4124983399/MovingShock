using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public bool UseMovePosition, UseFixedUpdate;
    Rigidbody2D rigid;
    Vector3 originPos;

    void Awake(){
        rigid = GetComponent<Rigidbody2D>();
        originPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (UseFixedUpdate)
            return;

        if (Input.GetKeyDown(KeyCode.Space))
            transform.position = originPos;
        else
            transform.position += Vector3.right * Time.deltaTime;
    }

    void FixedUpdate(){
        if (!UseFixedUpdate)
            return;

        if (Input.GetKeyDown(KeyCode.Space))
            rigid.position = originPos;
        else{
            if (UseMovePosition)
                rigid.MovePosition(rigid.position + Vector2.right * 0.01f);
            else
                transform.position += Vector3.right * 0.01f;   
        } 
    }
}
