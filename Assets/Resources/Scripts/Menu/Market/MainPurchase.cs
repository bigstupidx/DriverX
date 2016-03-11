using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;
using UnityEngine.Purchasing.Security;

public class MainPurchase : MonoBehaviour, IStoreListener
{
    private static IStoreController m_StoreController;                                                                  
    private static IExtensionProvider m_StoreExtensionProvider;                                                        

    

    private static string firstCurrencyId = "1_currency";
   

    private static string firstCurrencyIdGooglePlay = "1_currency";

    LibraryMenu libraryMenu;
    void Start()
    {
        libraryMenu = GameObject.FindObjectOfType<LibraryMenu>();
        // If we haven't set up the Unity Purchasing reference
        if (m_StoreController == null)
        {
            // Begin to configure our connection to Purchasing
            InitializePurchasing();
        }
    }

    public void InitializePurchasing()
    {
        // If we have already connected to Purchasing ...
        if (IsInitialized())
        {
            // ... we are done here.
            return;
        }

        // Create a builder, first passing in a suite of Unity provided stores.
        var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());

        // Add a product to sell / restore by way of its identifier, associating the general identifier with its store-specific identifiers.
        builder.Configure<IGooglePlayConfiguration>().SetPublicKey("MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEA2O/9/H7jYjOsLFT/uSy3ZEk5KaNg1xx60RN7yWJaoQZ7qMeLy4hsVB3IpgMXgiYFiKELkBaUEkObiPDlCxcHnWVlhnzJBvTfeCPrYNVOOSJFZrXdotp5L0iS2NVHjnllM+HA1M0W2eSNjdYzdLmZl1bxTpXa4th+dVli9lZu7B7C2ly79i/hGTmvaClzPBNyX+Rtj7Bmo336zh2lYbRdpD5glozUq+10u91PMDPH+jqhx10eyZpiapr8dFqXl5diMiobknw9CgcjxqMTVBQHK6hS0qYKPmUDONquJn280fBs1PTeA6NMG03gb9FLESKFclcuEZtvM8ZwMMRxSLA9GwIDAQAB");


        builder.AddProduct(firstCurrencyId, ProductType.Consumable, new IDs() {  { firstCurrencyIdGooglePlay, GooglePlay.Name }, });
        
        UnityPurchasing.Initialize(this, builder);
       
    }


    private bool IsInitialized()
    {
        return m_StoreController != null && m_StoreExtensionProvider != null;
    }


    public void BuyFirstCurrency()
    {
        BuyProductID(firstCurrencyId);
    }




    void BuyProductID(string productId)
    {
        try
        {
            if (IsInitialized())
            {
                Product product = m_StoreController.products.WithID(productId);

                if (product != null && product.availableToPurchase)
                {
                    Debug.Log(string.Format("Purchasing product asychronously: '{0}'", product.definition.id));
                    m_StoreController.InitiatePurchase(product);
                }
                else
                {
                    libraryMenu.windowWarning.Show("Произошла ошибка покупки. Ваши деньги не списаны");

                    Debug.Log("BuyProductID: FAIL. Not purchasing product, either is not found or is not available for purchase");
                }
            }
            else
            {
                libraryMenu.windowWarning.Show("Произошла ошибка покупки. Ваши деньги не списаны");

                Debug.Log("BuyProductID FAIL. Not initialized.");
            }
        }
        catch (Exception e)
        {
            libraryMenu.windowWarning.Show("Произошла ошибка покупки. Ваши деньги не списаны");

            Debug.Log("BuyProductID: FAIL. Exception during purchase. " + e);
        }
    }


    public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
    {
        m_StoreController = controller;



        m_StoreExtensionProvider = extensions;

    }




    public void OnInitializeFailed(InitializationFailureReason error)
    {
        Debug.Log("OnInitializeFailed InitializationFailureReason:" + error);
    }


    public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs args)
    {
       



        // Unity IAP's validation logic is only included on these platforms.
#if UNITY_ANDROID || UNITY_IOS || UNITY_STANDALONE_OSX || UNITY_TVOS
        // Prepare the validator with the secrets we prepared in the Editor
        // obfuscation window.
        var validator = new CrossPlatformValidator(GooglePlayTangle.Data(),
            AppleTangle.Data(), Application.bundleIdentifier);

        try
        {
            // On Google Play, result will have a single product Id.
            // On Apple stores receipts contain multiple products.
            var result = validator.Validate(args.purchasedProduct.receipt);
            Debug.Log("Receipt is valid. Contents:");
            foreach (IPurchaseReceipt productReceipt in result)
            {
                if (String.Equals(productReceipt.productID, firstCurrencyId, StringComparison.Ordinal))
                {
                    Bank.PlusMoney(MoneyPrice.firstPurchase);
                    PreferencesSaver.SetPurchaseComplete();
                    Debug.Log(string.Format("ProcessPurchase: PASS. Product: '{0}'", args.purchasedProduct.definition.id));
                }
                else
                {
                    libraryMenu.windowWarning.Show("Произошла ошибка покупки. Ваши деньги не списаны");

                    Debug.Log(string.Format("ProcessPurchase: FAIL. Unrecognized product: '{0}'", args.purchasedProduct.definition.id));
                }

               

            }
            // Unlock the appropriate content here.
        }
        catch (IAPSecurityException)
        {
            libraryMenu.windowWarning.Show("Произошла ошибка покупки. Ваши деньги не списаны");
        }
#endif


        return PurchaseProcessingResult.Complete;
        
    }


    public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
    {
        libraryMenu.windowWarning.Show("Произошла ошибка покупки. Ваши деньги не списаны");

        Debug.Log(string.Format("OnPurchaseFailed: FAIL. Product: '{0}', PurchaseFailureReason: {1}", product.definition.storeSpecificId, failureReason));
    }
}
 

