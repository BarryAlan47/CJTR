using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class Player : MonoBehaviour
{
    private Palyer_Status palyer_Status;
    [LabelText("Player动画控制器")]
    public Animator animator;
    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            UnityEngine.Debug.Log("切换至:Idle");
            animator.SetBool("Idle",true);
            animator.SetBool("Walking",false);
            animator.SetBool("Running",false);
        }else if(Input.GetKeyDown(KeyCode.S))
        {
            UnityEngine.Debug.Log("切换至:Attack_Slow");
            animator.SetBool("Idle",false);
            animator.SetBool("Walking",false);
            animator.SetBool("Running",false);
            animator.SetTrigger("Attack_Slow");
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
    private void PlayerIdle()
    {
        //TODO:写玩家Idle相关
    }
    private void PlayerMove()
    {
        //TODO:写玩家移动相关
    }
    private void PlayerAttack()
    {
        //TODO:写玩家攻击相关
    }
    private void PlayerBeHit()
    {
        //TODO:写玩家受击相关
    }
    private void PlayerDodge()
    {
        //TODO:写玩家翻滚相关
    }
    private void PlayerDeath()
    {
        //TODO:写玩家死亡相关
    }
    public enum Palyer_Status
    {
        Idle,
        IdleRex,
        Dodge_Front,
        Dodge_Back,
        Walking,
        Running,
        BeHit,
        Death
    }
}
