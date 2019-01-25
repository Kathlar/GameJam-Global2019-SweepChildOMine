using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    public CountryPackageObject.Country countryToCollect = CountryPackageObject.Country.None;

    private void OnTriggerEnter(Collider other)
    {
        CountryPackageObject countryPackage = other.GetComponent<CountryPackageObject>();
        if (countryPackage)
        {
            CollectCountryPackageObject(countryPackage);
        }
        else
        {
            PackageObject package = other.GetComponent<PackageObject>();
            if (package)
            {
                CollectPackage(package);
            }
            else
            {
                ItemObject item = other.GetComponent<ItemObject>();

                if (item)
                {
                    CollectItem(item);
                }
            }
        }
    }

    void CollectItem(ItemObject item)
    {
        Destroy(item.gameObject);
    }

    void CollectPackage(PackageObject package)
    {
        if(package.goodCondition)
            GameStatistics.AddPoints(10);
        CollectItem(package);
    }

    void CollectCountryPackageObject(CountryPackageObject package)
    {
        if(package.goodCondition && (countryToCollect == CountryPackageObject.Country.None || package.country == countryToCollect))
            GameStatistics.AddPoints(10);
        CollectItem(package);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, transform.localScale);
    }
}
