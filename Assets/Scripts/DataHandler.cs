using System;
using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;


[System.Serializable]
public class Product
{
    public string name;
    public string description;
    public float price;
}

[System.Serializable]
public class ProductList
{
    public List<Product> products;
}

public class DataHandler : MonoBehaviour
{
    private const string apiUrl = "https://homework.mocart.io/api/products"; // Replace with your actual URL
    private ProductList _productList = new ProductList();
   private AppManager _appManager;

    private void Awake()
    {
        _appManager = GetComponent<AppManager>();
        StartCoroutine(GetProducts());
    }

    // Fetch JSON data from server
    public IEnumerator GetProducts()
    {
        UnityWebRequest request = UnityWebRequest.Get(apiUrl);
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            // Deserialize JSON into ProductList
            _productList = JsonUtility.FromJson<ProductList>(request.downloadHandler.text);
            Debug.Log("Products Loaded Successfully");

            // Log each product's details for debugging
            foreach (Product product in _productList.products)
            {
                _appManager.GetProductsData( product.name, product.description, product.price);
            }
        }
        else
        {
            Debug.LogError($"Error: {request.error}");
            _appManager.userLog.text = $"Error: {request.error}";
        }
    }
}
