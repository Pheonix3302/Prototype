using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportWTrigger : MonoBehaviour
{
    public Transform destination;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Teleport(Transform target)
    {
        target.position = destination.position;
        target.rotation = destination.rotation;
    }

    private void OnTriggerEnter(Collider other)
    {
        Teleport(other.transform);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
