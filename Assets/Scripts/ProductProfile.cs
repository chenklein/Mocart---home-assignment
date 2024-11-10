using System;
using UnityEngine;
using UnityEngine.UI;

public class ProductProfile : MonoBehaviour
{
  
    [SerializeField] private Text p_name;
    [SerializeField] private Text p_description;
    [SerializeField] private Text p_price;
    [SerializeField] private Transform modelParent;
    [SerializeField] private Text p_submited_name;
    [SerializeField] private Text p_submited_price;
    [SerializeField] private Button modifyButton;
    
    public ProductData productData;
    
    private void Start()
    {
        // Populate text fileds with text data
        p_name.text = productData.name;  
        p_price.text = productData.price.ToString();   
        p_description.text = productData.description;
        
        // Instantiate 3D model stored in scriptable object
        Instantiate(productData.productModel, modelParent);
    }

    // Modify internal product data
    public void SubmitNewData()
    {
        if (!string.IsNullOrEmpty(p_submited_name.text)) productData.name = p_submited_name.text;
        else productData.name = p_name.text;
        
        if (!string.IsNullOrEmpty(p_submited_price.text))  productData.price = p_submited_price.text;
        else productData.price = p_price.text;
       
        modifyButton.interactable = false;
    } 
}
