using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drone : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody rb;
    float horz,vert,dep,yaw;
    float horzto;

    Vector3 pos;

    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        horz=Input.GetAxis("Horizontal"); //左右LR
        vert=Input.GetAxis("Vertical"); //前後UpDown
        dep=Input.GetAxis("Depth"); //上下ws
        yaw=Input.GetAxis("Yaw"); //回転ad

        // //左右旋回
        // rb.AddTorque(0,yaw,0);

        // //前傾後傾
        // if(this.transform.rotation.x > 15 || this.transform.rotation.x < -15){
        //     vert=0;
        // }
        // rb.MoveRotation(Quaternion.AngleAxis(vert*10, Vector3.right));
        

        // //左右傾
        // if(this.transform.rotation.z > 15){
        //     horz=0;
        // }
        // rb.MoveRotation(Quaternion.AngleAxis(horz*10, Vector3.back));
        // //はなしたら0に近づく
        
        // //上下　
        // rb.AddForce(horz*10,dep*20,vert*0.1f,ForceMode.Acceleration);

        // //自動ホバリング
        // // if(dep < 0.1){
        // //     rb.AddForce(horz*10,dep*20,vert*3,ForceMode.Acceleration);
        // // }

        // pos = this.transform.position;
        // pos.x=horz;
        // pos.y=dep;
        // pos.z=vert;
        // this.transform.position = pos;

        // 左右移動の傾きが再現できない
        // if(dep<0) dep/=4;  
        // this.transform.Translate(horz,dep/1.5f,vert);
        // this.transform.Rotate(0, yaw*4, 0);
        //this.transform.rotation = Quaternion.Euler(0, 0, horz*15);


        pos=this.transform.position;
        pos.x = pos.x + vert * Mathf.Sin(this.transform.eulerAngles.y * Mathf.Deg2Rad)
                        +horz * Mathf.Cos(this.transform.eulerAngles.y * Mathf.Deg2Rad);
        if(dep<0) dep/=4; 
        pos.y+=dep/1.5f;
        pos.z = pos.z + vert * Mathf.Cos(this.transform.eulerAngles.y * Mathf.Deg2Rad)
                        +horz * -Mathf.Sin(this.transform.eulerAngles.y * Mathf.Deg2Rad);
        this.transform.position = pos;
        
        //this.transform.rotation = Quaternion.Euler(0, 0, (horz+1)*(horz+1)*40);
        
        if(horz>0.1f && -25<this.transform.rotation.y){
            this.transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, transform.rotation.y, -25), 5);
            horzto = -5f;
        }else if(horz<-0.1f && this.transform.rotation.y<25){
        this.transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, transform.rotation.y, 25), 5);
            horzto = 5f;
        }else{
            this.transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, transform.rotation.y, 0), 6);
            //horzto=0;
        }
        this.transform.Rotate(0, yaw*20, 0);
        


        //https://stickpan.hatenablog.com/entry/2014/05/23/165110
        // this.transform.position = this.transform.position +
        //         new Vector3(Mathf.Sin(this.transform.eulerAngles.y * Mathf.Deg2Rad) ,
        //         0 ,
        //         Mathf.Cos(this.transform.eulerAngles.y * Mathf.Deg2Rad));

        
    }
}


/*
地面に近づきすぎると着陸する 50cm
衝突時（重力おん）->ゲームオーバー画面　ー＞　Restartボタン・Homeボタン
ゆかはゲームオーバーにならない
離陸着陸ボタン
FPSカメラ　rotationあり

*/