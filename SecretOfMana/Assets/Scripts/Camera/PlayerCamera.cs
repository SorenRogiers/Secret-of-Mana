using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour {

    private Transform _cameraTarget;

    private Vector3 _cameraOffset = new Vector3(0, 10, -5);
    private float _speed = 5.0f;

    public void SetCameraTarget(Transform target)
    {
        _cameraTarget = target;
    }

    private void Update()
    {
        if (_cameraTarget == null)
        {
            Debug.LogError("Camera target is not set!",_cameraTarget);
            return;
        }

        transform.position = Vector3.Lerp(this.transform.position, _cameraTarget.position + _cameraOffset, Time.deltaTime *_speed);
    }
}
