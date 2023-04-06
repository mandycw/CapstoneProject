using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Enemy_Experimental : MonoBehaviour
{
    //audio for shooting projectile
    //public AudioSource projectileSound;

   //identifying what is and is not a target
    public NavMeshAgent agent;
    
    public Transform player;
   
    public  LayerMask WhatIsGround, WhatIsPlayer;
    public float hp;

    //patrol state
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //attack state
    public float AtkCD;
    bool onCD;
    public GameObject projectile;

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
    if (playerInsight && playerInrange)
       {
         AttackPlayer();
         //projectileSound.Play();
       }

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
        
        
        
        if(!onCD) {
         //Attack code
         Rigidbody rb = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * 32f, ForceMode.Impulse);
            rb.AddForce(transform.up * 8f, ForceMode.Impulse);
         
         onCD = true;
        Invoke(nameof(ResetAttack), AtkCD);
        }

       }
       private void ResetAttack(){
        onCD = false;
       }
       public void TakeDamage(int damage)
    {
        hp -= damage;

        if (hp <= 0) Invoke(nameof(DestroyEnemy), 0.5f);
    }
    private void DestroyEnemy()
    {
        Destroy(gameObject);
    }
     private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }
}
