using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class SpecialCube : MonoBehaviour
{
    private float _speed;

    private float _deathDistance;

    private Vector3 _startPosition;

    private Vector3 _endPosition;

    [SerializeField]
    private TextMeshProUGUI _state;


    public void SetData(float _Speed, float _Distance) {
        _speed = _Speed;
        _deathDistance = _Distance;
    }

    public void Start()
    {
        _startPosition = transform.position;
        _endPosition = new Vector3(0, _startPosition.y + _deathDistance, 0);
    }

    public void SetUIState() {
        _state.text = string.Format("Distance: {0}\n Speed: {1}", Math.Round(Vector3.Distance(_startPosition, transform.position), 2), _speed) ;
    }

    public void Update()
    {
        if (Vector3.Distance(_startPosition, transform.position) > _deathDistance) Destroy(transform.gameObject);

        SetUIState();

        transform.position += Vector3.MoveTowards(_startPosition, _endPosition, _speed * Time.deltaTime);
    }
}
