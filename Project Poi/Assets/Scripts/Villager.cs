using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Villager : MonoBehaviour
{
    public GameObject gameManager;
    Village village;

    public float f_currentCarryResources;
    public float f_carryCapacity;

    public string villagerType;
    [SerializeField] private float gatherRate;
    [SerializeField] private string villagerState;
        
    private Transform currentWaypoint;

    public Transform resourcePoint;
    public Transform collectionPoint;

    [SerializeField] bool isGatheringResources;
    [SerializeField] bool isAtCollectionPoint;
    [SerializeField] bool isAtResourcePoint;

    UnityEngine.AI.NavMeshAgent agent;

    // Start is called before the first frame update
    //void Start()
    //{
    //    village = gameManager.GetComponent<Village>();
    //    f_carryCapacity = village.villagerCarryCapacity;
    //    gatherRate = village.villagerGatherRate;
    //    villagerState = "goingToResourcePoint";

    //    SetWaypoints();
    //    agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    //    agent.destination = resourcePoint.position;
    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    f_carryCapacity = village.villagerCarryCapacity;
    //    gatherRate = village.villagerGatherRate;
    //    SetWaypoints();
    //    if (villagerState == "goingToResourcePoint")
    //    {
    //        agent.isStopped = false;
    //        SetVillagerGoal();
    //        agent.destination = currentWaypoint.position;
    //        if (isAtResourcePoint)
    //        {
    //            Debug.Log("Switching villager state to gatheringResources");
    //            villagerState = "gatheringResource";
    //        }
    //    }
    //    else if (villagerState == "gatheringResource")
    //    {
    //        Debug.Log("Villager is gathering resources");
    //        agent.isStopped = true;
    //        if (f_currentCarryResources < f_carryCapacity)
    //            GatherResources();
    //        else
    //            villagerState = "goingToCollectionPoint";
    //    }
    //    else if (villagerState == "goingToCollectionPoint")
    //    {
    //        agent.isStopped = false;
    //        SetVillagerGoal();
    //        agent.destination = currentWaypoint.position;
    //        if (isAtCollectionPoint)
    //        {
    //            DropOffResources();
    //            villagerState = "goingToResourcePoint";
    //        }
    //    }
    //}

    private void SetVillagerGoal()
    {
        if (villagerState == "goingToResourcePoint")
            currentWaypoint = resourcePoint;
        else if (villagerState == "goingToCollectionPoint")
            currentWaypoint = collectionPoint;
    }

    private void GatherResources()
    {
        f_currentCarryResources += gatherRate * Time.deltaTime;
    }

    private void SetWaypoints()
    {
        if (villagerType == "Wood Cutter")
        {
            GameObject[] resourceGameObjects = GameObject.FindGameObjectsWithTag("Woodline");
            GameObject[] collectionPointGameObjects = GameObject.FindGameObjectsWithTag("Lumber camp");

            if (resourceGameObjects.Length != 0)
                resourcePoint = resourceGameObjects[0].transform;
            if (collectionPointGameObjects.Length != 0)
                collectionPoint = collectionPointGameObjects[0].transform;
        }
        else if (villagerType == "Farmer")
        {
            GameObject[] resourceGameObjects = GameObject.FindGameObjectsWithTag("Farm");
            GameObject[] collectionPointGameObjects = GameObject.FindGameObjectsWithTag("Mill");

            if (resourceGameObjects.Length != 0)
                resourcePoint = resourceGameObjects[0].transform;
            if (collectionPointGameObjects.Length != 0)
                collectionPoint = collectionPointGameObjects[0].transform;
        }
        else if (villagerType == "Miner")
        {
            GameObject[] resourceGameObjects = GameObject.FindGameObjectsWithTag("Gold Mine");
            GameObject[] collectionPointGameObjects = GameObject.FindGameObjectsWithTag("Mining Camp");

            if (resourceGameObjects.Length != 0)
                resourcePoint = resourceGameObjects[0].transform;
            if (collectionPointGameObjects.Length != 0)
                collectionPoint = collectionPointGameObjects[0].transform;
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        CheckIsAtResourcePoint(collider);       
    }

    private void CheckIsAtResourcePoint(Collider collider)
    {
        if (collider.gameObject.tag == "Woodline")
        {
            Debug.Log("Villager has reached the resource point");
            isAtResourcePoint = true;
            isAtCollectionPoint = false;
        }
        else if (collider.gameObject.tag == "Lumber camp")
        {
            isAtResourcePoint = false;
            isAtCollectionPoint = true;
        }
        else
        {
            isAtResourcePoint = false;
            isAtCollectionPoint = false;
        }
    }

    private void DropOffResources()
    {
        if (villagerType == "Wood Cutter")
            village.wood += (int)f_currentCarryResources;
        else if (villagerType == "Farmer")
            village.food += (int)f_currentCarryResources;
        else if (villagerType == "Miner")
            village.gold += (int)f_currentCarryResources;

        f_currentCarryResources = 0;
    }
}