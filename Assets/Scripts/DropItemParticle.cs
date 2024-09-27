using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItemParticle : MonoBehaviour
{
    public Material dropMaterial;
    public GameObject flowerToSpawn;

    ParticleSystem particle;
    ParticleSystem.Particle[] particles;

    public void Initiate()
    {
        particle = GetComponent<ParticleSystem>();
        particles = new ParticleSystem.Particle[particle.main.maxParticles];

        particle.GetComponent<ParticleSystemRenderer>().material = dropMaterial;

        //TerrainCollider terrainCollider = GameObject.FindGameObjectWithTag("Terrain").GetComponent<TerrainCollider>();

        particle.trigger.AddCollider(GameObject.FindGameObjectWithTag("Terrain").GetComponent<Collider>());
    }

    public void Play()
    {
        var shape = particle.shape;
        shape.rotation = new Vector3(-90, Random.Range(0f, 360f), 0);

        particle.Play();
    }

    void OnParticleTrigger()
    {
        int particleCount = particle.GetParticles(particles);
        print("flowers hit collider and spawned to position: " + particles[0].position);

        Instantiate(flowerToSpawn, particles[0].position, Quaternion.identity);

        Destroy(gameObject);
    }
}
