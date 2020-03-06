using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner : BulletSpawner
{
    [SerializeField] private float _spinSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        base.HandleBulletGeneration();
        transform.Rotate(Vector3.right, _spinSpeed * Time.fixedDeltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*protected override Matrix4x4 MoveBullet(Matrix4x4 matrix)
    {
        Matrix4x4 movedMatrix = matrix;
        movedMatrix += 
        return Movedmatrix;
    }*/
}
