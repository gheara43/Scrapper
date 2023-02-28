using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollowPlayer : MonoBehaviour
{
    public float speed;
    public float lineOfSite;
    private Transform player;
    public float shootingRange;
    public GameObject bullet;
    public GameObject bulletParent;
    
    void Start()
    {
         player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    
    void Update()
    {   
        float distanceFromPlayer = Vector2.Distance(player.position,transform.position);
        if(distanceFromPlayer < lineOfSite && distanceFromPlayer>shootingRange)
        {
        transform.position = Vector2.MoveTowards(this.transform.position, player.position, speed*Time.deltaTime);
        }
        else if(distanceFromPlayer<=shootingRange)
        {
            Instantiate(bullet, bulletParent.transform.position,Quaternion.identity);
        }
        
    }
}

