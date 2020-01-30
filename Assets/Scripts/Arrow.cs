using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour {

    public float MaxLifeTime;

    [SerializeField] private Vector3 _velocity;

    [SerializeField] private Vector3 _maxSize;

	private Vector3 _initialSize;

	private float _elapsedTimeAlive;

    // Start is called before the first frame update
    void Start() {
        //Stores the initial size of an arrow as it is spawned
		_initialSize = gameObject.transform.localScale;

    }

    // Fixed update is called once per fixed interval
    void FixedUpdate() {
        float dt = Time.fixedDeltaTime;

		transform.position = transform.position + _velocity * dt;

		//Vector3 scale = InitialSize + MaxSize*Mathf.Sin(ElapsedTimeAlive/MaxLifeTime*Mathf.PI);

		//transform.localScale = scale;
		transform.position += _velocity * dt;
		_elapsedTimeAlive += dt;

		if (_elapsedTimeAlive > MaxLifeTime) {
			Destroy (gameObject);
		}
    }
}
