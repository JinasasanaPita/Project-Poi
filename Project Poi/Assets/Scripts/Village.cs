using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Village : MonoBehaviour
{
    public int food;
    public int wood;
    public int gold;

    public float villagerGatherRate;
    public int villagerCarryCapacity;

    public GameObject villagerPrefab;
    public Transform villagerSpawn;

    [SerializeField] Button spawnWoodCutterButton;
    [SerializeField] Button spawnFarmerButton;
    [SerializeField] Button spawnMinerButton;

    Vector3 v_villagerSpawn;

    // Start is called before the first frame update
    void Start()
    {
        villagerCarryCapacity = 10;
        villagerGatherRate = 1;
        v_villagerSpawn = villagerSpawn.position;
        

        spawnWoodCutterButton.onClick.AddListener(SpawnWoodCutter);
        spawnFarmerButton.onClick.AddListener(SpawnFarmer);
        spawnMinerButton.onClick.AddListener(SpawnMiner);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnWoodCutter()
    {
        Villager villager = villagerPrefab.GetComponent<Villager>();
        villager.villagerType = "Wood Cutter";
        villager.gameManager = GameObject.FindGameObjectWithTag("Game Manager");
        Instantiate(villagerPrefab, v_villagerSpawn, Quaternion.identity);
    }

    public void SpawnFarmer()
    {
        Villager villager = villagerPrefab.GetComponent<Villager>();
        villager.villagerType = "Farmer";
        Instantiate(villagerPrefab, v_villagerSpawn, Quaternion.identity);
    }

    public void SpawnMiner()
    {
        Villager villager = villagerPrefab.GetComponent<Villager>();
        villager.villagerType = "Miner";
        Instantiate(villagerPrefab, v_villagerSpawn, Quaternion.identity);
    }
}
