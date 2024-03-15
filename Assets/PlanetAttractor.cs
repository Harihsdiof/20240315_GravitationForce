using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetAttractor : MonoBehaviour
{
    public Rigidbody rb;
    private const float G = 6.67f;
    public static List< PlanetAttractor > pAttractors;
    
    void AttractorFormular(PlanetAttractor other)
    {
        //F = G* ( m1*m2)/d^2 ;
        Rigidbody rbOther = other.rb;
        Vector3 direction = rb.position - rbOther.position;
        float distance = direction.magnitude;

        float forMagnitude = G * (rb.mass * rbOther.mass) / Mathf.Pow(distance, 2);

        Vector3 forceDir = direction.normalized * forMagnitude;
        
        rbOther.AddForce(forceDir);

    }//AttractorFormular
    
    
    // Update is called once per frame
    void FixedUpdate()
    {
        foreach (var attractor in pAttractors)
        {
            if (attractor != this)
            {
                AttractorFormular(attractor);
            }
        }
    }

    private void OnEnable()
    {
        if (pAttractors == null)
        {
            pAttractors = new List<PlanetAttractor>();
        }
        pAttractors.Add(this);
    }
}
