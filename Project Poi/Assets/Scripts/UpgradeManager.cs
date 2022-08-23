using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    public int level_stockpilling;
    public int level_logFelling;
    public int level_bountifulharvest;
    public int level_cropRotation;
    public int level_fertilisedPastures;
    public int level_miningShaft;
    public int level_wheelBarrow;

    // Start is called before the first frame update
    void Start()
    {
        level_stockpilling = 0;
        level_logFelling = 0;
        level_bountifulharvest = 0;
        level_cropRotation = 0;
        level_fertilisedPastures = 0;
        level_miningShaft = 0;
        level_wheelBarrow = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int CalculateStockpillingEffect(int level)
    {
        return level + 2;
    }

    public int CalculateLogFellingEffect(int level)
    {
        return (int)(level + 0.01 * level);
    }

    public int CalculateBountifulHarvestEffect(int level)
    {
        return level + 2;
    }

    public int CalculateCropRotationEffect(int level)
    {
        return level + 2;
    }

    public int CalculateFertilisedPasturesEffect(int level)
    {
        return level + 2;
    }

    public int CalculateMiningShaftEffect(int level)
    {
        return (int)(level + 0.01 * level);
    }

    public int CalculateWheelbarrowEffect(int level)
    {
        return level + 2;
    }
}
