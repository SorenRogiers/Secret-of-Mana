using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenMainDoor : MonoBehaviour {

    public GameObject Lever01;
    public GameObject Lever02;

    private float _offset = 3.0f;
    private float _lerpTime = 2.0f;
    private float _currentLerpTime = 0.0f;

    private Vector3 _startPosition;
    private Vector3 _endPosition;

    private Lever _leverComponent01;
    private Lever _leverComponent02;

    private void Start()
    {
        _startPosition = transform.position;
        _endPosition = transform.position + (Vector3.down * _offset);

        _leverComponent01 = Lever01.GetComponent<Lever>();
        _leverComponent02 = Lever02.GetComponent<Lever>();
    }

    private void Update()
    {
        if (_leverComponent01.Activated && _leverComponent02.Activated)
            Open();
    }

    private void Open()
    {
        _currentLerpTime += Time.deltaTime;

        if (_currentLerpTime > _lerpTime)
            _currentLerpTime = _lerpTime;

        float percentage = _currentLerpTime / _lerpTime;

        transform.position = Vector3.Lerp(_startPosition, _endPosition, percentage);

    }
}
