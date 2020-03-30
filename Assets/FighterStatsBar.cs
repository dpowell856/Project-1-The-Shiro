using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FighterStatsBar : MonoBehaviour
{
    private Vector3 _offset;

    private Transform _parent;

    private BarFillerSprite _healthBar, _staminaBar;

    private void Awake()
    {
        _parent = transform.parent;
        foreach(BarFillerSprite barFiller in GetComponentsInChildren<BarFillerSprite>())
        {
            if (barFiller.name == "HealthBar")
            {
                _healthBar = barFiller;
            }else if(barFiller.name == "StaminaBar"){
                _staminaBar = barFiller;
            }
        }
    }

    void Start()
    {
        _offset = transform.localPosition;
    }

    void Update()
    {
        transform.position = _parent.position + _offset;
        transform.rotation = Quaternion.identity;
    }

    public void SetHealthPorportion(float proportion)
    {
        _healthBar.SetBarFillProportion(proportion);
    }

    public void SetStaminaProportion(float proportion)
    {
        _staminaBar.SetBarFillProportion(proportion);
    }
}
