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

    TextMeshProUGUI woodDisplay;
    TextMeshProUGUI foodDisplay;
    TextMeshProUGUI goldDisplay;

    Vector3 v_villagerSpawn;

    // Start is called before the first frame update
    void Start()
    {
        woodDisplay = GameObject.Find("Wood Display").GetComponent<TextMeshProUGUI>();
        foodDisplay = GameObject.Find("Food Display").GetComponent<TextMeshProUGUI>();
        goldDisplay = GameObject.Find("Gold Display").GetComponent<TextMeshProUGUI>();

        villageLevel = 1;

        villagerCarryCapacity = 10;
        villagerGatherRate = 1;
        v_villagerSpawn = villagerSpawn.position;

        SetUISettings();

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

    public void SetUISettings()
    {
        woodDisplay.fontSize = 15;
        foodDisplay.fontSize = 15;
        goldDisplay.fontSize = 15;
    }
    public void DisplayVillageStats()
    {
        woodDisplay.text = "Wood: \n" + wood;
        foodDisplay.text = "Food: \n" + food;
        goldDisplay.text = "Gold: \n" + gold;
    }
}
