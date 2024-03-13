//using NUnit.Framework.Internal.Filters;
//using System.Collections;
//using System.Collections.Generic;
//using System.Linq;
//using Unity.VisualScripting;
//using UnityEngine;

//public class CrystalLight : MonoBehaviour
//{

//    [SerializeField] float lightLength = 5.0f;
//    [SerializeField] int x, y = 0;

//    LineRenderer lineRenderer;

//    List<int> crystalPodiumIds;
//    List<Vector3> positions;

//    Quaternion rotation = Quaternion.Euler(0, 0, 60);

//    ContactFilter2D contactFilter;


//    // Start is called before the first frame update
//    void Start()
//    {

//        lineRenderer = GetComponent<LineRenderer>();
//        crystalPodiumIds = new List<int>();
//        positions = new List<Vector3>();

//        contactFilter.NoFilter();

//    }

//    // Update is called once per frame
//    void Update()
//    {

//        crystalPodiumIds.Clear();
//        positions.Clear();
//        positions.Add(transform.position);




//        Vector2 temp = new Vector2(1, -1);

//        Ray ray = new Ray(transform.position, temp);

//        Debug.DrawRay(ray.origin, ray.direction * 10);

//        Debug.DrawRay(transform.position, /*transform.forward * lightLength*/temp);

//        //RaycastHit2D hit = Physics2D.Raycast(transform.position, /*rotation * -transform.up*/ temp);

//        //RaycastHit2D hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity);

//        RaycastHit hit;
//        Physics.Raycast(ray.origin, ray.direction, out hit);

//        if (hit.collider != null) {
//            Debug.Log("Hit something!");

//            // Adds the position of the hit
//            positions.Add(hit.point);

//            // Checks if ray hits a CrystalPodium
//            if (hit.collider.tag == "CrystalPodium") {
//                Debug.Log("Hit first Crystal Podium!");

//                crystalPodiumIds.Add(hit.collider.GetInstanceID());
//                //positions.Add(hit.transform.position);

//                //ProcessRaycast(hit);

//            // Checks if ray hits the lights goal
//            } else if (hit.collider.tag == "LightGoal") {
//                Debug.Log("Light Win!");
//                //positions.Add(hit.transform.position);

//            } else {
//            // Curently does not work as intended, light is angled off and gets closer as lightLength is increased // May not be needed if there are colliders on all sides
//            // Adds a position lightLength ahead of the ray origin
//            //positions.Add(new Vector3(transform.forward.x * lightLength, transform.forward.y * lightLength, transform.forward.z * lightLength));

//            }

//        }

//        DrawLight();

//    }

//    void ProcessRaycast(RaycastHit2D hit) {
//        Vector2 temp = new Vector2(0, -1);
//        //Debug.DrawRay(transform.position, /*transform.forward * lightLength*/temp);

//        //hit = Physics2D.Raycast(transform.position, /*rotation * -transform.up*/ temp);

//        hit = Physics2D.GetRayIntersection(new Ray(transform.position, temp), Mathf.Infinity);

//        if (hit.collider != null) {

//            // Adds position of the hit
//            positions.Add(hit.point);

//            // Checks if ray hits a LightReflector
//            if (hit.collider.tag == "CrystalPodium") {
//                // Checks if reflector has not already been hit in this frame
//                if (!crystalPodiumIds.Contains(hit.collider.GetInstanceID())) {
//                    Debug.Log("Hit Crystal Podium!");

//                    crystalPodiumIds.Add(hit.collider.GetInstanceID());
//                    //positions.Add(hit.transform.position);

//                    ProcessRaycast(hit);

//                }

//                // Checks if ray hits the lights goal
//            }
//            else if (hit.collider.tag == "LightGoal") {
//                Debug.Log("Light Win!");
//                //positions.Add(hit.transform.position);

//            }

//        }

//    }


//    void DrawLight() {
//        foreach (Vector3 pos in positions) {
//            Debug.Log(pos);

//        }

//        lineRenderer.positionCount = positions.Count;
//        lineRenderer.SetPositions(positions.ToArray<Vector3>());

//    }

//}

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class PuzzleLight : MonoBehaviour {

    //[SerializeField] bool isSource = false;
    [SerializeField] float lightLength = 5.0f;

    LineRenderer lineRenderer;

    List<int> crystalPodiumIds;
    List<Vector3> positions;

    Quaternion rotation = Quaternion.Euler(0, 0, 45);

    // Start is called before the first frame update
    void Start() {

        lineRenderer = GetComponent<LineRenderer>();
        crystalPodiumIds = new List<int>();
        positions = new List<Vector3>();

    }

    // Update is called once per frame
    void Update() {

        crystalPodiumIds.Clear();
        positions.Clear();
        positions.Add(transform.position);

        RaycastHit hit;
        Debug.DrawRay(transform.position,rotation * -transform.up * lightLength);

        if (Physics.Raycast(transform.position, rotation * -transform.up, out hit)) {
            Debug.Log("Hit something!");



            // Adds the position of the hit
            positions.Add(hit.point);

            // Checks if ray hits a CrystalPodium
            if (hit.collider.tag == "CrystalPodium") {
                Debug.Log("Hit first Crystal Podium!");

                crystalPodiumIds.Add(hit.colliderInstanceID);
                //positions.Add(hit.transform.position);

                ProcessRaycast(hit);

                // Checks if ray hits the Crystal Ball
            }
            else if (hit.collider.tag == "CrystalBall") {
                Debug.Log("Light Win!");
                //positions.Add(hit.transform.position);

            }

        }
        else {
            // Curently does not work as intended, light is angled off and gets closer as lightLength is increased // May not be needed if there are colliders on all sides
            // Adds a position lightLength ahead of the ray origin
            //positions.Add(new Vector3(transform.forward.x * lightLength, transform.forward.y * lightLength, transform.forward.z * lightLength));

        }

        DrawLight();

    }

    void ProcessRaycast(RaycastHit hit) {
        Debug.DrawRay(hit.transform.position, -hit.transform.forward * lightLength);

        

        if (Physics.Raycast(hit.transform.position, -hit.transform.forward, out hit)) {

            // Adds position of the hit
            positions.Add(hit.point);

            // Checks if ray hits a CrystalPodium
            if (hit.collider.tag == "CrystalPodium") {
                // Checks if reflector has not already been hit in this frame
                if (!crystalPodiumIds.Contains(hit.colliderInstanceID)) {
                    Debug.Log("Hit Crystal Podium!");

                    crystalPodiumIds.Add(hit.colliderInstanceID);
                    //positions.Add(hit.transform.position);

                    ProcessRaycast(hit);

                }

                // Checks if ray hits the Crystal Ball
            }
            else if (hit.collider.tag == "CrystalBall") {
                Debug.Log("Light Win!");
                //positions.Add(hit.transform.position);

            }

        }

    }


    void DrawLight() {
        lineRenderer.positionCount = positions.Count;
        lineRenderer.SetPositions(positions.ToArray<Vector3>());

    }


}
