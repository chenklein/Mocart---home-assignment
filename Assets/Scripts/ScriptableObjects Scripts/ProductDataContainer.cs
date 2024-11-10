using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "ProductDataContainer", menuName = "Scriptable Objects/ProductDataContainer")]
public class ProductDataContainer : ScriptableObject
{
    public List<ProductData> productsData = new List<ProductData>();
}
