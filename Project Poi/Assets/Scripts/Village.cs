using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Village : MonoBehaviour
{
    public int food;
    public int wood;
    public int gold;

    public int villageLevel;

    public float villagerGatherRate;
    public int villagerCarryCapacity;

    public GameObject villagerPrefab;
    public Transform villagerSpawn;

    [SerializeField] Button spawnWoodCutterButton;
    [SerializeField] Button spawnFarmerButton;
    [SerializeField] Button spawnMinerButton;

    [SerializeField] GameObject woodDisplay_GO;
    [SerializeField] GameObject foodDisplay_GO;
    [SerializeField] GameObject goldDisplay_GO;

    TextMeshProUGUI woodDisplay;
    TextMeshProUGUI foodDisplay;
    TextMeshProUGUI goldDisplay;

    Vector3 v_villagerSpawn;

    // Start is called before the first frame update
    void Start()
    {
        woodDisplay = woodDisplay_GO.GetComponent<TextMeshProUGUI>();
        foodDisplay = foodDisplay_GO.GetComponent<TextMeshProUGUI>();
        goldDisplay = goldDisplay_GO.GetComponent<TextMeshProUGUI>();

        villageLevel = 1;

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
        DisplayVillageStats();
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

    public void DisplayVillageStats()
    {
        woodDisplay.text = "Wood: \n" + wood;
        foodDisplay.text = "Food: \n" + food;
        goldDisplay.text = "Gold: \n" + gold;
    }
}
