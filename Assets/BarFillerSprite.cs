using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarFillerSprite : MonoBehaviour
{
    [SerializeField] private bool _barStartsFull;

    private float _lerpBarFillMoveTime;

    private SpriteRenderer _image;

    private float _startPosition;

    void Awake()
    {
        _image = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        _startPosition = transform.localPosition.x;
    }

    public void SetBarFillProportion(float proportion)
    {

        float positionToBe = _startPosition - (1 - proportion) * transform.localScale.x;

        StopAllCoroutines();
        StartCoroutine(MoveBarFillToLocalPosition(positionToBe));
    }

    private IEnumerator MoveBarFillToLocalPosition(float localPositionTarget)
    {
        while(!Mathf.Approximately(transform.localPosition.x, localPositionTarget))
        {
            Vector2 positionToPlace = transform.localPosition;
            positionToPlace.x = Mathf.Lerp(transform.localPosition.x, localPositionTarget, _lerpBarFillMoveTime);
            transform.localPosition = positionToPlace;
            _lerpBarFillMoveTime += Time.deltaTime;
            yield return null;
        }
    }

}
