using System.Runtime.Serialization.Json;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class Player : MonoBehaviour
{
    private Palyer_Status palyer_Status;
    private Animator animator;//Player动画控制器
    private CharacterController characterController;//Player运动控制器
    [LabelText("Player移动速度"),Range(0,20)]
    public float Movespeed = 5f;
    private float rotateSpeed = 2f;
    private VariableJoystick variableJoystick;//摇杆组件
    void Start()
    {
        variableJoystick = GameObject.FindGameObjectWithTag("Joystick").GetComponent<VariableJoystick>();
        animator = GetComponentInChildren<Animator>();
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        PlayerMove();
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(Time.timeScale == 0)
            {
                Time.timeScale = 1;
            }else
            {
                Time.timeScale = 0;
            }
            
        }
        else if(Input.GetKeyDown(KeyCode.D))
        {
            UnityEngine.Debug.Log("切换至:Attack_Fast");
            animator.SetBool("Idle",false);
            animator.SetBool("Walking",false);
            animator.SetBool("Running",false);
            animator.SetTrigger("Attack_Fast");
        }
        else if(Input.GetKeyDown(KeyCode.F))
        {
            UnityEngine.Debug.Log("切换至:Attack_Strong");
            animator.SetBool("Idle",false);
            animator.SetBool("Walking",false);
            animator.SetBool("Running",false);
            animator.SetTrigger("Attack_Strong");
        }
        else if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            UnityEngine.Debug.Log("切换至:Walking");
            animator.SetBool("Idle",false);
            animator.SetBool("Walking",true);
            animator.SetBool("Running",false);
            transform.Rotate(0, Input.GetAxis("Horizontal") * rotateSpeed, 0);
            Vector3 forward = transform.TransformDirection(Vector3.forward);
            float curSpeed = Movespeed * Input.GetAxis("Vertical");
            characterController.SimpleMove(forward * curSpeed);
        }else if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            UnityEngine.Debug.Log("切换至:Running");
            animator.SetBool("Idle",false);
            animator.SetBool("Walking",false);
            animator.SetBool("Running",true);
        }else if(Input.GetKeyDown(KeyCode.Q))
        {
            UnityEngine.Debug.Log("切换至:Dodge_Front");
            animator.SetBool("Idle",false);
            animator.SetBool("Walking",false);
            animator.SetBool("Running",false);
            animator.SetTrigger("Dodge_Front");
        }else if(Input.GetKeyDown(KeyCode.W))
        {
            UnityEngine.Debug.Log("切换至:Dodge_Back");
            animator.SetBool("Idle",false);
            animator.SetBool("Walking",false);
            animator.SetBool("Running",false);
            animator.SetTrigger("Dodge_Back");
        }else if(Input.GetKeyDown(KeyCode.E))
        {
            UnityEngine.Debug.Log("切换至:sit");
            animator.SetBool("Idle",false);
            animator.SetBool("Walking",false);
            animator.SetBool("Running",false);
            animator.SetTrigger("Sit");
        }else if(Input.GetKeyDown(KeyCode.Z))
        {
            UnityEngine.Debug.Log("切换至:BeHit_Weak");
            animator.SetBool("Idle",false);
            animator.SetBool("Walking",false);
            animator.SetBool("Running",false);
            animator.SetTrigger("BeHit_Weak");
        }else if(Input.GetKeyDown(KeyCode.X))
        {
            UnityEngine.Debug.Log("切换至:BeHit_Strong");
            animator.SetBool("Idle",false);
            animator.SetBool("Walking",false);
            animator.SetBool("Running",false);
            animator.SetTrigger("BeHit_Strong");
        }else if(Input.GetKeyDown(KeyCode.C))
        {
            UnityEngine.Debug.Log("切换至:BeHit_Stun");
            animator.SetBool("Idle",false);
            animator.SetBool("Walking",false);
            animator.SetBool("Running",false);
            animator.SetTrigger("BeHit_Stun");
        }
    }
    public void PlayerIdle()
    {
        //TODO:写玩家Idle相关
    }
    private void PlayerMove()
    {
        //TODO:写玩家移动相关
        float horizontal = Input.GetAxis("Horizontal") ;
        float vertical = Input.GetAxis("Vertical") ;
        horizontal = horizontal == 0 ? variableJoystick.Horizontal : horizontal;
        vertical = vertical == 0 ? variableJoystick.Vertical : vertical;
        if(horizontal > 0)
        {
            this.transform.rotation = Quaternion.Euler(0.0f,0.0f,0.0f);
            animator.SetBool("Idle",false);
            animator.SetBool("Running",true);
            characterController.Move(new Vector3(Movespeed * Time.deltaTime,0,0));
            // if(horizontal <= 0.5)
            // {
            //     animator.SetBool("Walking",true);
            //     animator.SetBool("Running",false);
            // }else
            // {
            //     animator.SetBool("Walking",false);
            //     animator.SetBool("Running",true);
            // }
        }else if(horizontal < -0)
        {
            this.transform.rotation = Quaternion.Euler(0.0f,180.0f,0.0f);
            animator.SetBool("Idle",false);
            animator.SetBool("Running",true);
            characterController.Move(new Vector3(-Movespeed * Time.deltaTime,0,0));
            // if(horizontal >= -0.5)
            // {
            //     animator.SetBool("Walking",true);
            //     animator.SetBool("Running",false);
            // }else
            // {
            //     animator.SetBool("Walking",false);
            //     animator.SetBool("Running",true);
            // }
        }else
        {
            animator.SetBool("Walking",false);
            animator.SetBool("Running",false);
            animator.SetBool("Idle",true);
        }
    }
    public void PlayerAttack()
    {
        //TODO:写玩家攻击相关
        UnityEngine.Debug.Log("切换至:Attack_Slow");
        animator.SetBool("Idle",false);
        animator.SetBool("Walking",false);
        animator.SetBool("Running",false);
        animator.SetTrigger("Attack_Slow");
    }
    public void PlayerBeHit()
    {
        //TODO:写玩家受击相关
    }
    public void PlayerDodge()
    {
        //TODO:写玩家翻滚相关
    }
    public void PlayerDeath()
    {
        //TODO:写玩家死亡相关
    }
    public enum Palyer_Status
    {
        isIdle,
        isWalking,
        isRunning,
        isDodge_Front,
        isDodge_Back,
        isBeHit,
        isDeath
    }
}
