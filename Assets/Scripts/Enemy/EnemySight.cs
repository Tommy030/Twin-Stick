using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemySight : MonoBehaviour
{
    [SerializeField]  public float Angle = 10f;
    [SerializeField] public float Radius;
    [SerializeField]private float Turnspeed;
    [SerializeField] Transform Player;


    [SerializeField] LayerMask Layer;

    public bool PlayerSEE;

    [SerializeField]public Vector3 LastLocPlayerSeen;

    
    private void Update()
    {
        PlayerSEE = InFOV(transform, Player, Angle, Radius);
        if (PlayerSEE)
        {
            LastLocPlayerSeen = Player.position;
            //get dir
            Vector3 dir = Player.position - transform.position;
            //get target rot
            Quaternion rot = Quaternion.LookRotation(dir);
            // smooth speed with lerp
            transform.rotation = Quaternion.Lerp(transform.rotation, rot, Turnspeed * Time.deltaTime);
        }
      
    }
    
    private void OnDrawGizmos()
    {
        

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
    public  bool InFOV(Transform Check, Transform Target, float MaxAngle, float Radius)
    {
        // adds colliders into this list
        Collider[] Overlaps = new Collider[30];

        //takes count of the amount of colliders in the radius drawn by the gizmos
        int count = Physics.OverlapSphereNonAlloc(Check.position, Radius, Overlaps, Layer);

        for (int i = 0; i < count + 1 ; i++)
        {
            
            if (Overlaps[i] != null)
            {
                //checks every colllider
                if (Overlaps[i].transform == Target)
                {
                    
                    Vector3 directionbetween = (Target.position - Check.position).normalized;
                    directionbetween.y = 0;

                    float angle = Vector3.Angle(Check.forward, directionbetween);


                    if (angle <= MaxAngle)
                    {
                        //raycasts are cool af
                        Ray ray = new Ray(Check.position, Target.position - Check.position);
                        RaycastHit hit;
                        if (Physics.Raycast(ray,out hit, Radius,Layer))
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
