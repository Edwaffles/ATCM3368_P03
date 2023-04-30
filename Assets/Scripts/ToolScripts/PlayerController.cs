using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Vector2 turn;
    public float sensitivity = .5f;
    public Vector3 deltaMove;
    public float speed = 5f;
    public GameObject player;

    private float jumpAmount = .5f;
    private Rigidbody playerBody;


    [SerializeField] private WeaponSystem _melee;
    [SerializeField] private WeaponSystem _midRanged;
    [SerializeField] private WeaponSystem _longRanged;

    private WeaponSystem _currentWeapon;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        playerBody = gameObject.GetComponent<Rigidbody>();

        _currentWeapon = _melee;
    }

    // Update is called once per frame  
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(0.001f, 0f, 0f);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-0.001f, 0f, 0f);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(0.0f, 0f, -0.001f);
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(0.0f, 0f, 0.001f);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            playerBody.AddForce(Vector3.up * jumpAmount, ForceMode.Impulse);
        }


        float y = Input.GetAxis("Mouse X") * speed;
        player.transform.eulerAngles = new Vector3(0, player.transform.eulerAngles.y + y, 0);

        if (Input.GetKey(KeyCode.Alpha1))
        {
            _currentWeapon = _melee;
        }
        if (Input.GetKey(KeyCode.Alpha2))
        {
            _currentWeapon = _midRanged;
        }
        if (Input.GetKey(KeyCode.Alpha3))
        {
            _currentWeapon = _longRanged;
        }




    }

    public WeaponSystem CurrentWeapon()
    {
        return _currentWeapon;
    }
}
