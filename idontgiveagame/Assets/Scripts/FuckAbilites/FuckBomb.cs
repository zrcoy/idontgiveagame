using System.Collections;
using System.Collections.Generic;
using idgag.AI;
using idgag.GameState;
using UnityEngine;
using UnityEngine.AI;

public class FuckBomb : MonoBehaviour
{
    public float delay = 2.0f;
    public float radius = 5.0f;
    public float force = 2000.0f;
    public GameObject explosionEffect;


    bool hasExploded = false;
    float countdown;

    // Start is called before the first frame update
    void Start()
    {
        countdown = delay;
    }

    // Update is called once per frame
    void Update()
    {
        countdown -= Time.deltaTime;
        if(countdown<=0.0f && !hasExploded)
        {
            Explode();
            hasExploded = true;
        }
    }

    void Explode()
    {
        // show effect
        Instantiate(explosionEffect, transform.position, Quaternion.identity);

        // get nearby objects
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        AiController[] controllers = new AiController[colliders.Length];

        for (int i = 0; i < colliders.Length; i++)
        {
            Collider nearbyOBJ = colliders[i];

            Rigidbody rb = nearbyOBJ.GetComponent<Rigidbody>();
            NavMeshAgent agent = nearbyOBJ.GetComponent<NavMeshAgent>();
            AiController aiController = nearbyOBJ.GetComponent<AiController>();
            if (rb!=null)
            {
                if(agent)
                {
                    //if(m_TargetPeople == nearbyOBJ.gameObject.tag)
                    {
                        nearbyOBJ.transform.position += new Vector3(0, 1.5f, 0);
                        agent.enabled = false;
                    }
                }

                if (aiController)
                {
                    controllers[i] = aiController;
                }

                rb.AddExplosionForce(force, transform.position, radius);
            }
        }

        MeshRenderer meshRenderer = gameObject.GetComponent<MeshRenderer>();
        if (meshRenderer)
        {
            meshRenderer.enabled = false;
        }

        StartCoroutine(RemoveAfterTime(controllers));
    }

    WaitForSeconds timeBeforeRemove = new WaitForSeconds(2);
    private IEnumerator<object> RemoveAfterTime(AiController[] aiControllers)
    {
        yield return timeBeforeRemove;

        foreach (AiController aiController in aiControllers)
        {
            if (aiController == null)
                continue;

            aiController.Remove();

            switch (aiController)
            {
                case EconomistAi ecoAi:
                    GameState.Singleton.CrowdGenerator.m_BusinessCrowdPool.Remove(ecoAi);
                    break;

                case EnvironmentalistAi envAi:
                    GameState.Singleton.CrowdGenerator.m_EnvironmentalCrowdPool.Remove(envAi);
                    break;
            }

            Destroy(aiController.gameObject);
        }

        //remove grenade
        Destroy(gameObject);
    }

    void setTarget(string t)
    {
        m_TargetPeople = t;
    }


    string m_TargetPeople;
}
