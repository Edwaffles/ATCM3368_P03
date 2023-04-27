using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseWeapon : MonoBehaviour
{
    [SerializeField] private PlayerController _whoPlayer;

    private WeaponSystem _activeWeapon;

    private string _name;

    private bool _isStream;

    private bool _isReady;

    // Use this for initialization
    private void Awake()
    {
        _activeWeapon = _whoPlayer.CurrentWeapon();
        _isStream = _activeWeapon.IsStream;
        _isReady = true;

    }
    // Update is called once per frame
    void Update()
    {
        _activeWeapon = _whoPlayer.CurrentWeapon();
        _isStream = _activeWeapon.IsStream;

        if (_isStream == true)
        {
            if (Input.GetMouseButton(0))
            {
                RaycastHit hit;
                if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, _activeWeapon.Range))
                {
                    hit.collider.SendMessage("RayTargetHit", _activeWeapon, SendMessageOptions.DontRequireReceiver);
                }
            }
        }
        else if(_isStream == false)
        {
            if (Input.GetMouseButtonDown(0) && _isReady)
            {
                Debug.Log(Time.time);
                RaycastHit hit;
                if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, _activeWeapon.Range))
                {
                    hit.collider.SendMessage("RayTargetHit", _activeWeapon, SendMessageOptions.DontRequireReceiver);

                }

                StartCoroutine(RateOfAttack(_activeWeapon.AttackRate));

            }
        }        
    }

    IEnumerator RateOfAttack(float rate)
    {
        _isReady = false;
        yield return new WaitForSeconds(2 * (1 / rate));
        _isReady = true;
        Debug.Log(Time.time);
    }



   
}
