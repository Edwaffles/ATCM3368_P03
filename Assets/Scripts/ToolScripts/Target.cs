using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Target : MonoBehaviour
{
    [SerializeField] private float _hitpoints;
    private float knockbackForce;
   

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    public void RayTargetHit(WeaponSystem usedWeapon)
    {
        float dDmg = Random.Range(.01f, 1f);

        if(dDmg > usedWeapon.Crit)
        {
            _hitpoints -= (usedWeapon.AttackRate * usedWeapon.Damage) * 2;
        }
        else
        {
            _hitpoints -= (usedWeapon.AttackRate * usedWeapon.Damage);
        }

        Knocked(usedWeapon.Knockback);
        Debug.Log(usedWeapon.Name + " : "+ _hitpoints);

    }

    private void Knocked(float knockbackForce)
    {
        this.transform.position += transform.forward * Time.deltaTime * knockbackForce;
    }
}
