using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCollider : MonoBehaviour
{

    private Collider2D objectCollider;
    [SerializeField] private ContactFilter2D colliderFilter;
    private List<Collider2D> colliders = new List<Collider2D>(2);

    // Start is called before the first frame update
    void Start()
    {
        objectCollider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        objectCollider.Overlap(colliderFilter, colliders);
        foreach(var i in colliders)
        {
            Debug.Log("Collided with " + i.name);
        }
    }
}
