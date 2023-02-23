using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Enemy_Experimental : MonoBehaviour
{
   //identifying what is and is not a target
    public NavMeshAgent agent;
    
    public Transform player;
   
    public  LayerMask WhatIsGround, WhatIsPlayer;

    //patrol state
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //attack state
    public float AtkCD;
    bool onCD;

    //States
    public float sightRange, attackRange;
    public bool playerInsight, playerInrange;

    private void Awake()
    {
       player = GameObject.Find("Player").transform;
       agent = GetComponent<NavMeshAgent>();


       

}
private void Update() {
    //check if player is in range
    playerInsight = Physics.CheckSphere(transform.position, sightRange, WhatIsPlayer);
    playerInrange = Physics.CheckSphere(transform.position, attackRange, WhatIsPlayer);
    if (!playerInsight && !playerInrange) Patrol();
    if (playerInsight && !playerInrange) ChasePlayer();
    if (playerInrange && playerInrange) AttackPlayer();

}
private void Patrol()
       {
         if (!walkPointSet) Searchwalkpoint();
         if (walkPointSet) 
         agent.SetDestination(walkPoint);
         Vector3 distanceTowalkPoint = transform.position - walkPoint;
         //Walkpoint reached
         if (distanceTowalkPoint.magnitude < 1f)
         walkPointSet = false;

       }
       private void  Searchwalkpoint() 
       {
        // calculate random point in range 
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
         float randomX = Random.Range(-walkPointRange, walkPointRange);
         walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);
         
         if (Physics.Raycast(walkPoint, -transform.up, 2f, WhatIsGround))
         walkPointSet = true;

       }
       private void ChasePlayer()
       {
        agent.SetDestination(player.position);
       }

       private void AttackPlayer()
       {
        // make sure enemy doesnt move
        agent.SetDestination(transform.position);
        
        transform.LookAt(player);
        
        if(!onCD) {
         //Attack code
         
         
         onCD = true;
        Invoke(nameof(ResetAttack), AtkCD);
        }

       }
       private void ResetAttack(){
        onCD = false;
       }
}
