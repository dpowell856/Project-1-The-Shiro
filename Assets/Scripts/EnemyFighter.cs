using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFighter : Damageable
{

    protected float _speed;
    protected float _range;

    // Update is called once per frame
    void Update()
    {
        fixedUpdate();
    }


    void fixedUpdate()
    {
        move();
    }

    
    void move()
    {
        Fighter closestPlayer = findPlayer();
        Vector3 direction = closestPlayer.transform.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(direction);
        transform.rotation = rotation;
        transform.position += direction*0.01f;
    }

    Fighter findPlayer()
    {
        float distanceToClosestPlayer = Mathf.Infinity;
        Fighter closestPlayer = null;
        Fighter[] allPlayers = GameObject.FindObjectsOfType<Fighter>();

        foreach(Fighter currentPlayer in allPlayers)
        {
            float distanceToPlayer = (currentPlayer.transform.position - this.transform.position).sqrMagnitude;
            if (distanceToPlayer < distanceToClosestPlayer)
            {
                distanceToClosestPlayer = distanceToPlayer;
                closestPlayer = currentPlayer;
            }
        }
        Debug.DrawLine(this.transform.position, closestPlayer.transform.position);
        return closestPlayer;
        
    }

}
