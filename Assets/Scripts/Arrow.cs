using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour {

    public float MaxLifeTime;

	public Vector3 Velocity { get; set; }

	public Vector3 MaxSize;

	private Vector3 InitialSize;

	private float ElapsedTimeAlive;

    // Start is called before the first frame update
    void Start() {
        //Stores the initial size of an arrow as it is spawned
		InitialSize = gameObject.transform.localScale;
		ElapsedTimeAlive = 0.0f;
    }

    // Fixed update is called once per fixed interval
    void FixedUpdate() {
        float dt = Time.fixedDeltaTime;

		transform.position = transform.position + Velocity * dt;

		Vector3 Scale = InitialSize + MaxSize*Mathf.Sin(ElapsedTimeAlive/MaxLifeTime*Mathf.PI);

		transform.localScale = Scale;
		transform.position = transform.position + this.Velocity * dt;
		ElapsedTimeAlive += dt;

		if (ElapsedTimeAlive > MaxLifeTime) {
			Destroy (gameObject);
		}
    }
}
