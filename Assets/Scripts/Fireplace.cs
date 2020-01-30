using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireplace : MonoBehaviour
{
    private bool _lit = false;

    private bool _active;

    private SpriteRenderer _spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        float _random = Random.Range(0.0f, 2.0f);

        _active = _random < 1.0f;

        _spriteRenderer = this.GetComponent<SpriteRenderer>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (collision.GetComponent<Fighter>().player.GetAction(Action.Interact))
            {
                print("Player is inside torch usable zone");
            }
        }
    }
}