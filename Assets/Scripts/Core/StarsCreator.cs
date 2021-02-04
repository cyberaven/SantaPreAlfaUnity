using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class StarsCreator : MonoBehaviour
{
    [SerializeField] private ParticleSystem StarsCloud;
    [SerializeField] private Transform FinishPosition;
    [SerializeField] private float SlowTime;

    List<MoveStarsCont> MoveStarsContList = new List<MoveStarsCont>();

    private void OnEnable()
    {
        House.HouseCreateStarsEve += HouseCreateStars;
    }
    private void OnDisable()
    {
        House.HouseCreateStarsEve += HouseCreateStars;
    }

    private void Update()
    {
       CheckStarsCloud();
    }

    private void CheckStarsCloud()
    {        
        for (int i = 0; i < MoveStarsContList.Count; i++)
        {
            ParticleSystem.Particle[] particles = new ParticleSystem.Particle[MoveStarsContList[i].ParticleSystem.main.maxParticles];
            MoveStarsContList[i].ParticleSystem.GetParticles(particles);

            //пробуем двигать частицы к заданой точке.

            for (int j = 0; j < particles.Length; j++)
            {
                Vector3 direction = FinishPosition.position - particles[i].position;

                //particles[j].position = Vector3.MoveTowards(particles[j].position, MoveStarsContList[i].FinishPosition, Time.deltaTime * 100);
                particles[i].velocity = direction.normalized * MoveStarsContList[i].ParticleSystem.main.startSpeed.constant;
            }
        }
    }

    private void HouseCreateStars(int count, Vector3 starPosition)
    {
        ParticleSystem sc = Instantiate(StarsCloud);
        MoveStarsContList.Add(new MoveStarsCont(sc, count, starPosition, FinishPosition.position, SlowTime));
    }
}

public class MoveStarsCont
{
    private ParticleSystem particleSystem = null;
    private int count = 0;
    private Vector3 starPosition = Vector3.zero;
    private Vector3 finishPosition = Vector3.zero;
    private float slowTime = 0;
    public ParticleSystem ParticleSystem { get => particleSystem; set => particleSystem = value; }
    public int Count { get => count; set => count = value; }
    public Vector3 StarPosition { get => starPosition; set => starPosition = value; }
    public Vector3 FinishPosition { get => finishPosition; set => finishPosition = value; }
    public float SlowTime { get => slowTime; set => slowTime = value; }

    public MoveStarsCont(ParticleSystem particleSystem, int count, Vector3 starPosition, Vector3 finishPosition, float slowTime)
    {
        this.particleSystem = particleSystem;
        this.count = count;
        this.starPosition = starPosition;
        this.finishPosition = finishPosition;
        this.slowTime = slowTime;

        var emission = particleSystem.emission;
        emission.rateOverTime = count;
        particleSystem.transform.position = starPosition;
    }

    
}