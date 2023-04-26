using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseWeapon : MonoBehaviour
{
    [SerializeField] private PlayerController _whoPlayer;

    private WeaponSystem _activeWeapon;

    private string _name;

    private bool _isStream;

    // Use this for initialization
    private void Awake()
    {
        _activeWeapon = _whoPlayer.CurrentWeapon();

    }
    // Update is called once per frame
    void Update()
    {
        _activeWeapon = _whoPlayer.CurrentWeapon();

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, _activeWeapon.Range))
            {
                hit.collider.SendMessage("RayTargetHit",_activeWeapon, SendMessageOptions.DontRequireReceiver);               
            }
        }
        
        
    }

   
}
