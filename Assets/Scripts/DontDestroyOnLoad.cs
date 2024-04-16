using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DontDestroyOnLoad : MonoBehaviour
{

    [SerializeField] string myTag;

    // Start is called before the first frame update
    void Start()
    {
        
        
    }


    private void Awake() {
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag(myTag);
        if (gameObjects.Length > 1) {
            Destroy(gameObject);

        }
        else {
            DontDestroyOnLoad(gameObject);

        }

    }

}
