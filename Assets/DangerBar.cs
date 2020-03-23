using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DangerBar : MonoBehaviour
{
    [SerializeField] private float _lengthOfEachState;

    private float _timeToReachNextState, _timeElapsed = 0;

    private Animator _animator;

    private BarFillerUI _barFillerUI;

    void Awake()
    {
        _barFillerUI = GetComponentInChildren<BarFillerUI>();
        _animator = GetComponent<Animator>();
    }

    void Start()
    {
        _timeToReachNextState = _lengthOfEachState;
    }

    void Update()
    {
        if (_timeElapsed >= _timeToReachNextState)
        {
            ActivateNextState();
            _timeToReachNextState += _lengthOfEachState;
        }

        _barFillerUI.SetBarFillProportion(_timeElapsed / (_lengthOfEachState * 4));

        _timeElapsed += Time.deltaTime;
    }

    private void ActivateNextState()
    {
        _animator.SetTrigger("NextState");
    }
}
