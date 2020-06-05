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
    EnemySight Sight;
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


    //Weapon
    [SerializeField] public ScriptEnemy Stats;
    [SerializeField] private float Timer;
    [SerializeField] Transform Firepos;
    [SerializeField] private float REadout;

    [SerializeField] float timer;
    private Vector3 Previous;
    [SerializeField] float Currrentspeed;
    private void Awake()
    {
        Stats = Instantiate(Stats);

        WaitingTimerLeft= WaitingTime;

        Waypoints = GameObject.FindGameObjectsWithTag("Waypoint");
      


        
        Sight = GetComponent<EnemySight>();
        Agent = GetComponent<NavMeshAgent>();
    

    }
    private void Update()
    {
        REadout = Stats.HP;
        EnemyMechanics();
    }

    void EnemyMechanics()
    {
        States();
        AtDest();
        Chasing();
        Shoot();
        Die();
        Debug();
    }
    void Debug()
    {
        if (State != EnemyState.Shooting)
        {
            Vector3 Curm = transform.position - Previous;
            Currrentspeed = Curm.magnitude / Time.deltaTime;
            Previous = transform.position;
            if (Currrentspeed < 2)
            {
                timer += Time.deltaTime;

                if (timer >= 3)
                {
                Patrol();
                    timer = 0;
                }
            }
        }
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
            if(Timer <= 0 && !Pause.StaticPause.Paused)
            {
                Timer = 50;
                Stats.AmmoInClip -= 1;
                GameObject Bullets = ObjectPooling.ObjectPooler.GetPooledObject("Bullet");
                if (Bullets != null)
                {
                    Bullets.transform.position = Firepos.position;
                    Bullets.transform.rotation = transform.rotation;
                    Bullets.SetActive(true);
                    Bullet Bul = Bullets.GetComponent<Bullet>();
                    Bul.BulletInfo(Stats.BulletSpeed, Stats.Damage, false,"Patrolling Enemy");

                }

            }


        }
        else if (Stats.AmmoInClip <= 0 )
        {
            Timer = 300;
            Stats.AmmoInClip = Stats.AmmoMax;
        }
        else
        {
            Agent.isStopped = false;      
            
        }
        TimerMinus(Stats.FireRate);
    }
    void TimerMinus (float FireRate)
    {

        if (Timer > 0)
        {
            Timer -= 0.5f * FireRate;
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
        int oldint = Amount;
        Amount = Random.Range(0,Waypoints.Length);
        while (Amount == oldint)
            Amount = Random.Range(0, Waypoints.Length);

       
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
    void Die()
    {
        if (Stats.HP < 0)
            gameObject.SetActive(false);
    }
}
