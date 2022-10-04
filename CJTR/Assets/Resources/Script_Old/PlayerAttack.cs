using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class PlayerAttack : MonoBehaviour
{
    private Transform PlayerWeaponInitPoint;
    // Start is called before the first frame update
    void Start()
    {
        PlayerWeaponInitPoint = GameObject.FindGameObjectWithTag("PlayerWeaponInitPoint").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("x"))
        {
            Attack();
        }
    }
#region 玩家攻击
    public void Attack()
    {
        GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/Weapon/PlayerWeapon/PlayerArrow_1"), PlayerWeaponInitPoint);
    }
#endregion
}
