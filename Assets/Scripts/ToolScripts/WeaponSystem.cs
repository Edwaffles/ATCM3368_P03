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

    [SerializeField][Tooltip("Determines how quickly the player can attack again")] [Range(.5f,2)] private float _rateOfAttack;

    [Header("Advanced Stats")]
    [SerializeField][Tooltip("Determines the distance that the target is knocked back")] private float _knockback;

    [SerializeField][Tooltip("Determines area of a effect size. 0.5-1 is damages a single unit. 2.5 and greater damages multiple units ")]
    private float _areaOfEffect;

    [SerializeField][Tooltip("Determines critical strike chance")]
    [Range(0, 1)] private float _critStrike;
    [SerializeField][Tooltip("Determines critical strike damage modifier. 0 implies regular damage. 1 implies 100% more damage, or double damage")]
    [Range(0, 1)] private float _critDmg;

    [Header("Unique Stats")]
    [SerializeField][Tooltip("If activated, player can hold mouse button to attack in a stream. In this case attack rate determines damage interval")]
    private bool _isStream;

    [SerializeField][Tooltip("If activated, the weapon inflicts a damage over time factor (eg. poison/burn damage)")]
    private bool _isOverTime;
    [SerializeField][Tooltip("Determines how many damage ticks there will be")]
    private float _overTimeLength;
    [SerializeField][Tooltip("Determines the interval between ticks in seconds")]
    private float _overTimeTickRte;
    [SerializeField] private float _overTimeDmg;


    // Getter Code

    public string Name => _name;

    public float Damage => _damage;

    public float Range => _range;

    public float AttackRate => _rateOfAttack;

    public float Knockback => _knockback;

    public float Splash => _areaOfEffect;

    public float Crit => _critStrike;

    public float CritDmg => _critDmg;

    public bool IsStream => _isStream;

    public bool Overtime => _isOverTime;

    public float OvertimeLength => _overTimeLength;

    public float TickRate => _overTimeTickRte;

    public float OvertimeDamage => _overTimeDmg;

}
