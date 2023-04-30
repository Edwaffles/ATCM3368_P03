using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Target : MonoBehaviour
{
    [SerializeField] private float _hitpoints;
    private float knockbackForce;
   

    // Update is called once per frame
    public void RayTargetHit(WeaponSystem usedWeapon)
    {
        float dDmg = Random.Range(.01f, 1f);

        if(dDmg > usedWeapon.Crit)
        {
            _hitpoints -= (usedWeapon.Damage) ;
        }
        else
        {
            _hitpoints -= (usedWeapon.Damage) + (usedWeapon.Damage * usedWeapon.CritDmg);
        }
        Knocked(usedWeapon.Knockback);
        Debug.Log(usedWeapon.Name + " : "+ _hitpoints);
    }

    public void RayTargetBurn(WeaponSystem usedWeapon)
    {
        float dmg = usedWeapon.OvertimeDamage;
        float length = usedWeapon.OvertimeLength;
        float tickRate = usedWeapon.TickRate;
        StartCoroutine(LetBurn(dmg, length, tickRate));
        //Debug.Log(usedWeapon.Name + " : " + _hitpoints);
        //Debug.Log(Time.time);
    }

    IEnumerator LetBurn(float damage, float length, float ticker) 
    {
        for(int x = 1; x <= length; x++)
        {
            _hitpoints -= damage;
            yield return new WaitForSeconds(ticker);
            Debug.Log("Burning: " + _hitpoints);
        }
    }

    private void Knocked(float knockbackForce)
    {
        this.transform.position += transform.forward * Time.deltaTime * knockbackForce;
    }
}
