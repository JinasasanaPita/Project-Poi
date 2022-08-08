using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Farm : MonoBehaviour
{
    [SerializeField] GameObject gameManager;
    Village village;

    public float foodGatherRate = 0.0f;
    private float f_food;

    // Start is called before the first frame update
    void Start()
    {
        village = gameManager.GetComponent<Village>();
        f_food = village.food;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private float CalculateFoodGatherRate()
    {
        float _foodGatherRate = 1.0f;
        return _foodGatherRate;
    }

    private void CalculateFoodOffline()
    {
        foodGatherRate = CalculateFoodGatherRate();
        f_food += foodGatherRate * Time.deltaTime * 0.5f;
        village.food = (int)f_food;
    }
}
