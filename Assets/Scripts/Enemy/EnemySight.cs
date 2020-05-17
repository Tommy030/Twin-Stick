using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySight : MonoBehaviour
{
  [SerializeField]  public float Angle = 10f;
    [SerializeField] public float Radius;
    public bool PlayerSEE;
    public Vector3 LastLocPlayerSighted;

    public float Hoogte;

   [SerializeField] Transform Player;

    private void Update()
    {
        PlayerSEE = inFov(transform, Player, Angle, Radius);
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position,Radius );

        Vector3 FovLine1 = Quaternion.AngleAxis(Angle, transform.up) * transform.forward * Radius;
        Vector3 FovLine2 = Quaternion.AngleAxis(-Angle, transform.up) * transform.forward * Radius;

        Gizmos.color = Color.blue;
        Gizmos.DrawRay(transform.position, FovLine1);
        Gizmos.DrawRay(transform.position, FovLine2);

        if (!PlayerSEE)
            Gizmos.color = Color.red;
        else
            Gizmos.color = Color.green;
        Gizmos.DrawRay(transform.position, (Player.position - transform.position).normalized * Radius);
         
        
        Gizmos.color = Color.black;
        Gizmos.DrawRay(transform.position, transform.forward * Radius);
         
    }
    public  bool inFov(Transform Check, Transform Target, float MaxAngle, float Radius)
    {
        Collider[] Overlaps = new Collider[30];

        int count = Physics.OverlapSphereNonAlloc(Check.position, Radius, Overlaps);

        for (int i = 0; i < count + 1 ; i++)
        {
            if (Overlaps != null)
            {
                if (Overlaps[i].transform == Target)
                {
                    Vector3 directionbetween = (Target.position - Check.position).normalized;
                    directionbetween.y = 0;

                    float angle = Vector3.Angle(Check.forward, directionbetween);


                    if (angle <= MaxAngle)
                    {
                        Ray ray = new Ray(Check.position, Target.position - Check.position);
                        RaycastHit hit;
                        if (Physics.Raycast(ray,out hit, Radius))
                        {
                            if (hit.transform == Target)
                            {
                                return true;
                            }
                           
                        }

                    }
                    else
                        return false;
                }
            }
        }
        return false;
    }
}
