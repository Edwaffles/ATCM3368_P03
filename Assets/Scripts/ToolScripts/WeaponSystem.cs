using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponSystem_", menuName = "WeaponGroup/Weapons")]
public class WeaponSystem : ScriptableObject
{
    [SerializeField] private string _name;
    [Header("Basic Stats")]
    [SerializeField] private float _damage;

    [SerializeField][Range(1,50)] private float _range;

    [SerializeField] [Range(.5f,2)] private float _rateOfAttack;

    [Header("Advanced Stats")]
    [SerializeField] private float _knockback;

    [SerializeField][Tooltip("Area Of Effect or Splash Damage")] private float _aoe;

    [SerializeField] [Range(0, 1)] private float _critStrike;

    [Header("Unique Stats")]
    [SerializeField] private bool _isStream;

    [SerializeField] private bool _isOverTime;



    // Getter Code

    public string Name => _name;

    public float Damage => _damage;
    public float Range => _range;
    public float AttackRate => _rateOfAttack;
    public float Knockback => _knockback;
    public float Splash => _aoe;
    public float Crit => _critStrike;

    public bool IsStream => _isStream;

    public bool Overtime => _isOverTime;

}
