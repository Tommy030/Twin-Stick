using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    [Header("Adjustable")]
    [SerializeField] private float FollowSpeed;

    [Header("Non-Adjustable")]
    public Transform Target;
    public Vector3 Offset;

    private void LateUpdate()
    {
        Vector3 Desiredpos = Target.position + Offset;

        Vector3 Move = Vector3.Lerp(transform.position, Desiredpos, FollowSpeed);

        transform.position = Move;
    }
}
