using System.Collections.Generic;
using UnityEngine;

public class ProductionService : SaganService
{
    public void StartProduction(Item item)
    {
        StartCoroutine(StartProductionAsync(item));
    }

    private IEnumerator<WaitForSeconds> StartProductionAsync(Item item)
    {
        Debug.Log("Started producing " + item.GetName());
        yield return new WaitForSeconds(item.GetProductionTimeSeconds());
        Debug.Log("Finished producing " + item.GetName());
    }
}
