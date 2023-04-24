using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform _objectToFollow = null;

    Vector3 _objectOffset;

    // Start is called before the first frame update
    private void Awake()
    {
        // create an offset between this position and object's position
        _objectOffset = this.transform.position - _objectToFollow.position;
    }



    // Update is called once per frame
    private void LateUpdate()
    {
        this.transform.position = _objectToFollow.position + _objectOffset;
        this.transform.rotation = _objectToFollow.rotation;
    }
}
