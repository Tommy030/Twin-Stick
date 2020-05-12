using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPlayer : MonoBehaviour
{
    [Header("Adjustables")]
    [SerializeField] KeyCode Upwards_;
    [SerializeField] KeyCode Left_;
    [SerializeField] KeyCode Right_;
    [SerializeField] KeyCode Down_;

    [SerializeField] KeyCode CheatKnop;

    [Header("Non-Adjustables")]
    private PlayerStats Stats;

    private void Awake()
    {
        Stats = GetComponent<PlayerStats>();
    }

    private void FixedUpdate()
    {
        Upwards();
        Left();
        Right();
        Down();
    }

    void Upwards()
    {
        if (Input.GetKey(Upwards_))
            transform.position += Vector3.forward * Stats.MovementSpeed * Time.deltaTime;
    }
    void Left()
    {
         if (Input.GetKey(Left_))
            transform.position += Vector3.left* Stats.MovementSpeed * Time.deltaTime;
    }
    void Right()
    {
        if (Input.GetKey(Right_))
            transform.position += Vector3.back* Stats.MovementSpeed * Time.deltaTime;
    }
    void Down()
    {
        if (Input.GetKey(Down_))
            transform.position += Vector3.right* Stats.MovementSpeed * Time.deltaTime;
    }
}
