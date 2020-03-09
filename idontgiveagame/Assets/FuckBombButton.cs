using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuckBombButton : MonoBehaviour
{
    public GameObject bombPrefab;

    void Start()
    {
        m_crowdGeneratorRef = GameObject.FindGameObjectWithTag("CrowdGenerator").GetComponent<CrowdGenerator>();
    }

    public void SpawnBomb()
    {
        int rand = Random.Range(0, 2);
        Vector3 spawnPos = new Vector3(0,0,0);

        //if (rand == 0)
        //{
        //    int r = Random.Range(0, m_crowdGeneratorRef.m_BusinessCrowdPool.Count);
        //    int start = 0;
        //    foreach (idgag.AI.EconomistAi ai in m_crowdGeneratorRef.m_BusinessCrowdPool)
        //    {
        //        if (start == r)
        //        {
        //            if(ai)
        //            {

        //                spawnPos = ai.transform.position + new Vector3(0, 5, 0);
        //                break;
        //            }
        //        }
        //        start++;
        //    }
        //    if(spawnPos!=new Vector3(0,0,0))
        //    {
        //        start = 0;
        //        foreach (idgag.AI.EconomistAi ai in m_crowdGeneratorRef.m_ActiveBusinessCrowd)
        //        {
        //            if (start == r)
        //            {
        //                if (ai)
        //                {

        //                    spawnPos = ai.transform.position + new Vector3(0, 5, 0);
        //                    break;
        //                }
        //            }
        //            start++;
        //        }
        //    }
        //}
        //else
        //{
        //    int r = Random.Range(0, m_crowdGeneratorRef.m_EnvironmentalCrowdPool.Count);
        //    int start = 0;
        //    foreach (idgag.AI.EnvironmentalistAi ai in m_crowdGeneratorRef.m_EnvironmentalCrowdPool)
        //    {
        //        if (start == r)
        //        {
        //            if(ai)
        //            {
        //                spawnPos = ai.transform.position + new Vector3(0, 5, 0);
        //                break;
        //            }

        //        }
        //        start++;
        //    }
        //    if (spawnPos != new Vector3(0, 0, 0))
        //    {
        //        start = 0;
        //        foreach (idgag.AI.EnvironmentalistAi ai in m_crowdGeneratorRef.m_ActiveEnvironmentalCrowd)
        //        {
        //            if (start == r)
        //            {
        //                if (ai)
        //                {

        //                    spawnPos = ai.transform.position + new Vector3(0, 5, 0);
        //                    break;
        //                }
        //            }
        //            start++;
        //        }
        //    }
        //}

        //Vector3 spawnPos = new Vector3(0, 0, 0);
        //spawnPos = new Vector3(Random.Range(1, 20), 5, Random.Range(1, 8));
        //GameObject bomb = Instantiate(bombPrefab, spawnPos, Quaternion.identity);
        
    }

    CrowdGenerator m_crowdGeneratorRef;
}
