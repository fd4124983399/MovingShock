using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMover : MonoBehaviour
{
    [SerializeField] bool UseMovePosition, UseFixedUpdate;
    Rigidbody2D rigid;
    Vector3 originPos;
    int counter = 0;

    void Awake(){
        rigid = GetComponent<Rigidbody2D>();
        originPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Update " + counter);

        if (UseFixedUpdate)
            return;

        if (Input.GetKeyDown(KeyCode.Space))
            transform.position = originPos;
        else
            transform.position += Vector3.right * Time.deltaTime;
    }

    void LateUpdate(){
        counter++;
    }

    void OnRenderObject(){
         Debug.Log("Object rendered " + counter);       
    }

    void FixedUpdate(){
        Debug.Log("FixedUpdate " + counter);

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
