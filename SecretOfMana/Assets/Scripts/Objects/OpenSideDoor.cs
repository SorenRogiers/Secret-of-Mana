using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenSideDoor : MonoBehaviour
{
    public GameObject KeyObject;

    private float _offset = 3.0f;
    private float _lerpTime = 2.0f;
    private float _currentLerpTime = 0.0f;

    private Vector3 _startPosition;
    private Vector3 _endPosition;

    private Key _keyComponent;

    private void Start()
    {
        _startPosition = transform.position;
        _endPosition = transform.position + (Vector3.down * _offset);
        _keyComponent = KeyObject.GetComponent<Key>();
    }

    private void Update()
    {
        if (_keyComponent.IsPickedUp)
            Open();
    }

    private void Open()
    {
        _currentLerpTime += Time.deltaTime;

        if (_currentLerpTime > _lerpTime)
            _currentLerpTime = _lerpTime;

        float percentage = _currentLerpTime / _lerpTime;

        transform.position = Vector3.Lerp(_startPosition,_endPosition,percentage);
        
    }
}
