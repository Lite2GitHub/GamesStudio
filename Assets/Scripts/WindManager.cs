using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindManager : MonoBehaviour
{
    public GameObject[] particles;
    public GameObject[] locations;

    float particleDuration = 10;
    GameObject currentParticle;


    // Update is called once per frame
    void Update()
    {
        //StartCoroutine(Wait(Random.Range(2, 6)));
        instantiateParticle();
    }

    IEnumerator Wait(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        instantiateParticle();
    }

    void instantiateParticle()
    {
        int particle = Random.Range(0, particles.Length);
        int location = Random.Range(0, locations.Length);

        //only instantiate particle if there is not already one present
        if (locations[location].transform.childCount < 1)
        {
            GameObject windParticle = Instantiate(particles[particle], locations[location].transform);
            windParticle.GetComponent<ParticleSystem>().Play();
            currentParticle = windParticle;
        }
        
    }
}
