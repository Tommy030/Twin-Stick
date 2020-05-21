using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum EnemyState
{
    Patroling,
    Investigating,
    HoldingPosition,
    Shooting
}
public class EnemyFollow : MonoBehaviour
{

    NavMeshAgent Agent;
    [SerializeField] EnemySight Sight;
    [SerializeField] GameObject[] Waypoints;
    [SerializeField] private int Amount;
    [SerializeField] private EnemyState State = EnemyState.Patroling;
    private Vector3 LastSeen;

   [SerializeField] private float Angle;
   [SerializeField] private float TurnSpeed;

    [Tooltip("Does The AI Wait when he is at a patrol spot")]
    [SerializeField]private bool Wait;
    [SerializeField] private float WaitingTime;
    private float WaitingTimerLeft;
    private void Awake()
    {

        WaitingTimerLeft= WaitingTime;
        Amount = Random.Range(0, Waypoints.Length);

        Sight = GetComponent<EnemySight>();
        Agent = GetComponent<NavMeshAgent>();

    }
    private void Update()
    {
        EnemyMechanics();
    }

    void EnemyMechanics()
    {
        States();
        AtDest();
        Chasing();
        Shoot();
    }
    void States()
    {
        if (Sight.PlayerSEE)
        {
            LastSeen = Sight.LastLocPlayerSeen;
            State = EnemyState.Shooting;
            
        }
        else if (State == EnemyState.Shooting && !Sight.PlayerSEE)
        {
            State = EnemyState.Investigating;
        }
    }
    void Shoot()
    {
        if (State == EnemyState.Shooting)
        {
            Agent.isStopped = true;
            //a fucking shooting script.
        }
        else
        {
            Agent.isStopped = false;      
            
        }
    }
    void AtDest()
    {
        if (Agent.remainingDistance <= Agent.stoppingDistance)
        {
          if (!Agent.hasPath || Agent.velocity.sqrMagnitude == 0f)
          {
                if (State == EnemyState.Patroling && !Wait)
                    Patrol();
                if (Wait)
                {
                    WaitingTimerLeft -= Time.deltaTime;
                    if (WaitingTimerLeft <= 0)
                    {
                        WaitingTimerLeft = WaitingTime;
                        Patrol();
                    }
                }

                if (State == EnemyState.Investigating)
                    Turn();
          }
        }
       
    }
    
    void Patrol()
    {
        Amount += 1;
        if (Amount >= Waypoints.Length)
        {
            Amount = 0;

        }
        Agent.SetDestination(Waypoints[Amount].transform.position);

    }
    void Chasing()
    {
        if (State == EnemyState.Investigating)
        {
            Agent.SetDestination(LastSeen);
        }
    }
    void Turn()
    {
        //turn 360 degrees
        Angle -= 1;
        transform.Rotate(Vector3.up, -TurnSpeed * Time.deltaTime);
        if (Angle <=0)
        {
            Angle = 360;
            State = EnemyState.Patroling;
        }
    }
}
