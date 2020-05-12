using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    private void Update()
    {
        Ray Cam = Camera.main.ScreenPointToRay(Input.mousePosition);

        Plane InvisP = new Plane(Vector3.up, Vector3.zero);
        float RayL;
        if (InvisP.Raycast(Cam, out RayL))
        {
            Vector3 Target = Cam.GetPoint(RayL);
            Debug.DrawLine(Cam.origin, Target, Color.red);

            transform.LookAt(new Vector3(Target.x,transform.position.y,Target.z)) ;

              
        }
    }
}
