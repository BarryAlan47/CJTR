using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Sirenix.OdinInspector;

public class WeaponFly : MonoBehaviour
{
    private Rigidbody2D rb;//玩家武器的Rigidbody2D
    [LabelText("x轴的力的大小"),Range(-3000,3000)]
    public int x_Force = 2500;//x轴力的大小
    [LabelText("y轴的力的大小"),Range(0,1000)]
    public int y_Force = 300;//y轴力的大小
    [LabelText("要旋转的武器子物体")]
    public GameObject bullet;//要旋转的武器子物体
    [LabelText("拖尾特效")]
    public GameObject TrailingVFX;//碰撞特效
    [LabelText("破风特效")]
    public GameObject WindBreakerVFX;//碰撞特效
    [LabelText("碰撞特效")]
    public GameObject HitVFX;//碰撞特效
    private bool hasHit = false;//是否发生了碰撞
    private float angle = 0f;//处理武器旋转的角度
    // Start is called before the first frame update
    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(x_Force,y_Force));
        TrailingVFX.SetActive(true);
        WindBreakerVFX.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        changeAngle();
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        
        if(other.gameObject.layer == LayerMask.NameToLayer("Enemy") ||other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {//处理武器与角色间的碰撞
            hasHit = true;
            rb.velocity = Vector2.zero;
            rb.isKinematic = true;
            UnityEngine.Debug.Log("销毁了");
            TrailingVFX.SetActive(false);
            WindBreakerVFX.SetActive(false);
            HitVFX.SetActive(true);
            GameObject.Destroy(this.gameObject,1);
            this.gameObject.GetComponentInChildren<SpriteRenderer>().DOFade(0,2);
        }else
        {//处理武器与武器间的碰撞
            //TODO:后续处理Weapon相撞
        }
    }
    #region 处理弓箭旋转
    private void changeAngle()
    {
        if(hasHit == false)
        {
            angle = Mathf.Atan2(rb.velocity.y,rb.velocity.x)*Mathf.Rad2Deg;
            bullet.transform.rotation = Quaternion.AngleAxis(angle,Vector3.forward);
        }
    }
    #endregion
}
