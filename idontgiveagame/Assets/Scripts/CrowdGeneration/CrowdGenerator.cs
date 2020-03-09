using System.Collections.Generic;
using idgag.AI;
using idgag.GameState;
using UnityEngine;

public class CrowdGenerator : MonoBehaviour
{
    public int BusinessPoolSize = 100;
    public int EnvironmentalPoolSize = 100;

    public List<EnvironmentalistAi> m_ActiveEnvironmentalCrowd = new List<EnvironmentalistAi>();
    public List<EconomistAi> m_ActiveBusinessCrowd = new List<EconomistAi>();
    public int TotalPPLPerWave = 10;

    public GameObject BusinessPersonPrefab;
    public GameObject EnvironmentalPersonPrefab;

    public List<EconomistAi> m_BusinessCrowdPool = new List<EconomistAi>();
    public List<EnvironmentalistAi> m_EnvironmentalCrowdPool = new List<EnvironmentalistAi>();

    // Start is called before the first frame update
    void Awake()
    {
        SpawnPool();
    }

    void SpawnPool()
    {
        for (int i = 0; i < BusinessPoolSize; i++)
        {

            GameObject obj = Instantiate(BusinessPersonPrefab, transform.GetChild(0).transform, true);
            obj.SetActive(false);
            m_BusinessCrowdPool.Add(obj.GetComponent<EconomistAi>());
        }

        for (int i = 0; i < EnvironmentalPoolSize; i++)
        {
            GameObject obj = Instantiate(EnvironmentalPersonPrefab, transform.GetChild(1).transform, true);
            obj.SetActive(false);
            m_EnvironmentalCrowdPool.Add(obj.GetComponent<EnvironmentalistAi>());
        }
    }

    EconomistAi TakeFromBusinessPool()
    {
        foreach (EconomistAi p in m_BusinessCrowdPool)
        {
            if (!p.gameObject.activeInHierarchy)
            {
                return p;
            }
        }

        GameObject obj = Instantiate(BusinessPersonPrefab, transform.GetChild(0).transform, true);
        obj.SetActive(false);
        EconomistAi economistAi = obj.GetComponent<EconomistAi>();
        m_BusinessCrowdPool.Add(economistAi);

        return economistAi;
    }

    EnvironmentalistAi TakeFromEnvironmentalPool()
    {
        foreach (EnvironmentalistAi p in m_EnvironmentalCrowdPool)
        {
            if (!p.gameObject.activeInHierarchy)
            {
                return p;
            }
        }

        GameObject obj = Instantiate(EnvironmentalPersonPrefab, transform.GetChild(1).transform, true);
        obj.SetActive(false);
        EnvironmentalistAi environmentalistAi = obj.GetComponent<EnvironmentalistAi>();
        m_EnvironmentalCrowdPool.Add(environmentalistAi);

        return environmentalistAi;
    }

    // call this func every wave
    public void GenerateActiveCrowd(int waveSize, float businessPercentage, float environmentalPercentage, Lane currentLane)
    {
        for (int i = 0; i < waveSize; i++)
        {
            // grab a business person
            if (Random.Range(0f, 1f) < businessPercentage)
            {
                EconomistAi p = TakeFromBusinessPool();
                currentLane.AddAiController(p, currentLane.transform.position);
                m_ActiveBusinessCrowd.Add(p);
            }

            // grab a environmental person
            else
            {
                EnvironmentalistAi p = TakeFromEnvironmentalPool();
                currentLane.AddAiController(p, currentLane.transform.position);
                m_ActiveEnvironmentalCrowd.Add(p);
            }
        }
    }

    public void Plot(float offsetHorizontal, float offsetVertical, int columnMax, Vector3 businessAppearLoc, Vector3 environmentalAppearLoc)
    {
        PlotBusinessPeople(offsetHorizontal, offsetVertical, columnMax, businessAppearLoc);
        PlotEnvironmentalPeople(offsetHorizontal, offsetVertical, columnMax, environmentalAppearLoc);
    }

    public void PlotBusinessPeople(float offset_horizontal, float offset_vertical, int Column_Max, Vector3 BusinessAppearLoc)
    {
        Vector3 offsetHorizontal = new Vector3(offset_horizontal, 0, 0);
        Vector3 offsetVertical = new Vector3(0, 0, -offset_vertical);

        int steps_x = 0;
        int steps_z = 0;

        foreach (EconomistAi p in m_ActiveBusinessCrowd)
        {
            if (p == null)
                continue;

            p.transform.position = BusinessAppearLoc + offsetHorizontal * steps_x + offsetVertical * steps_z;

            if (steps_x == Column_Max - 1)
            {
                steps_x = 0;
                steps_z++;
                continue;
            }

            steps_x++;
        }

        m_ActiveBusinessCrowd.Clear();
    }

    public void PlotEnvironmentalPeople(float offset_horizontal, float offset_vertical, int Column_Max, Vector3 EnvironmentalAppearLoc)
    {
        Vector3 offsetHorizontal = new Vector3(offset_horizontal, 0, 0);
        Vector3 offsetVertical = new Vector3(0, 0, -offset_vertical);

        int steps_x = 0;
        int steps_z = 0;

        foreach (EnvironmentalistAi p in m_ActiveEnvironmentalCrowd)
        {
            if (p == null)
                continue;

            p.transform.position = EnvironmentalAppearLoc + offsetHorizontal * steps_x + offsetVertical * steps_z;

            if (steps_x == Column_Max - 1)
            {
                steps_x = 0;
                steps_z++;
                continue;
            }

            steps_x++;
        }

        m_ActiveEnvironmentalCrowd.Clear();
    }
}
