using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
public class AnimationEvent : MonoBehaviour
{
    public Transform ArrowInitPoint;
    [LabelText("X轴速度"),Range(0,2500)]
    public float X_Speed = 200f;
    [LabelText("Y轴速度"),Range(0,500)]
    public float Y_Speed = 0f;
    // Start is called before the first frame update
    void Start()
    {
        // arrow = (GameObject)Resources.Load("Prefabs/Weapon/PlayerWeapon/Arrow1");
        // rb = arrow.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Event(string _text)
    {
        UnityEngine.Debug.Log(_text);
        GameObject instance = Instantiate(Resources.Load("Prefabs/Weapon/PlayerWeapon/Arrow1", typeof(GameObject)),ArrowInitPoint.position,Quaternion.identity) as GameObject;
        instance.GetComponent<Rigidbody2D>().AddForce(new Vector2(X_Speed,Y_Speed));
        // GameObject.Instantiate(arrow,ArrowInitPoint.position,Quaternion.identity);
        // rb.AddForce(new Vector2(1000,1000));
    }
}
