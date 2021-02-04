// Requies Particle System

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GWInputs : MonoBehaviour
{
    [SerializeField] ParticleSystem GWParticles;
    [SerializeField] GameObject player;
    [SerializeField] Transform destinationTransform;
    
    
    void Start()
    {
        player = FindObjectOfType<player_Movement>().gameObject;
        GWParticles.Stop();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.T))
        {
            InstantiateGW();
        }
    }

    private void InstantiateGW()
    {
        transform.SetParent(destinationTransform);
        transform.LookAt(destinationTransform);
        GWParticles.Play();
        StartCoroutine("StopParticles");
    }

    IEnumerator StopParticles(){
        yield return new WaitForSeconds(3);
        GWParticles.Stop();
        transform.SetParent(player.transform); 
    }
}
