using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Sirenix.OdinInspector;

public class SkillIconMove : MonoBehaviour
{
    private Rigidbody2D rb;
    private DOTweenAnimation doTweenAnimation;
    [LabelText("左碰撞")]
    public BoxCollider2D leftCollider;
    [LabelText("右碰撞")]
    public BoxCollider2D rightCollider;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        doTweenAnimation = GetComponent<DOTweenAnimation>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /// <summary>
    /// Sent when an incoming collider makes contact with this object's
    /// collider (2D physics only).
    /// </summary>
    /// <param name="other">The Collision2D data associated with this collision.</param>
    private void OnCollisionEnter2D(Collision2D other)
    {
        // rb.bodyType = RigidbodyType2D.Static;
        if(gameObject.GetComponentInChildren<BoxCollider2D>().IsTouching(leftCollider))
        {
            Debug.Log($"{gameObject.name}碰到左碰撞");
        }
        else
        {
            Debug.Log($"{gameObject.name}碰到右碰撞");
            doTweenAnimation.DOPause();
        }
    }
    /// <summary>
    /// Sent each frame where a collider on another object is touching
    /// this object's collider (2D physics only).
    /// </summary>
    /// <param name="other">The Collision2D data associated with this collision.</param>
    private void OnCollisionStay2D(Collision2D other)
    {
        //rb.bodyType = RigidbodyType2D.Static;
        //doTweenAnimation.DOPause();
    }
    /// <summary>
    /// Sent when a collider on another object stops touching this
    /// object's collider (2D physics only).
    /// </summary>
    /// <param name="other">The Collision2D data associated with this collision.</param>
    private void OnCollisionExit2D(Collision2D other)
    {
        //rb.bodyType = RigidbodyType2D.Dynamic;
        //doTweenAnimation.DOPlay();
    }
}
