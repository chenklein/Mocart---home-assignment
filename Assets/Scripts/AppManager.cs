using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AppManager : MonoBehaviour
{
    [SerializeField] private GameObject productPrefab;
    [SerializeField] private Transform producsParent;
   
    public Text userLog;
    public ProductDataContainer productDataContainer;
    
    public void GetProductsData(string _name, string _description, float _price)
    {
        if (productDataContainer == null) Debug.LogError($"Product data container is null");
        
        // Loop through all 10 scriptable objects products data
        for (int i = 0; i < productDataContainer.productsData.Count; i++)
        {
            // Look only for scriptable objects contaning the same ID as in the JSON description
            if (GetNumberAtEndOfString(_description) == productDataContainer.productsData[i].id)
            {
                // If scriptable data is empty, fill with JSON data
                if(string.IsNullOrEmpty(productDataContainer.productsData[i].description))
                {
                    productDataContainer.productsData[i].name = _name;
                    productDataContainer.productsData[i].price = _price.ToString();
                    productDataContainer.productsData[i].description = _description; 
                }
                
                // Now that we are sure the product has data (from JSOM or previus stores scriptable data) we can spawn the objects 
                SpwanProducts(productDataContainer.productsData[i]);
            }
        }

    }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void SpwanProducts(ProductData _productData)
    {
        GameObject spawnedProduct = Instantiate(productPrefab, producsParent);
        ProductProfile productProfile = spawnedProduct.GetComponent<ProductProfile>();
        productProfile.productData = _productData;
    }
    
    private int GetNumberAtEndOfString(string input)
    {
        // Trim any whitespace and split by space
        string[] words = input.Trim().Split(' ');
    
        // Try to parse the last word as a number
        if (int.TryParse(words[words.Length - 1], out int number))
        {
            return number;
        }

        return -1; // Return -1 if parsing fails
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
