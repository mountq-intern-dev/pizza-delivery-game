using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoBehaviour
{
    [SerializeField]
    ParticleSystem pizza, done;

    public void PizzaParticle()
    {
          pizza.Play();
    }

    public void DoneParticle()
    {
          done.Play();
    }
}
