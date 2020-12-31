using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private float _spd = 1.0f;
    [SerializeField] private Transform _targetA, _targetB;
    private bool _switching = false;
    private Vector3 _nextTarget;
    void Start()
    {
        transform.position = _targetA.position;
    }

    void Update()
    {
        if (transform.position == _targetA.position)
        {
            _switching = false;
            _nextTarget = _targetB.position;
        }
        else if (transform.position == _targetB.position)
        {
            _switching = true;
            _nextTarget = _targetA.position;
        }

        if (_switching || !_switching)
        {
            transform.position = Vector3.MoveTowards(transform.position, _nextTarget, _spd * Time.deltaTime);
        }
    }
}
