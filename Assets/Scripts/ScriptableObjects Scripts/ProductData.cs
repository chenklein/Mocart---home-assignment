using UnityEngine;

[CreateAssetMenu(fileName = "ProductData", menuName = "Scriptable Objects/ProductData")]
public class ProductData : ScriptableObject
{
    public int id;
    public string name;
    public string description;
    public string price;
    public GameObject productModel;
}
