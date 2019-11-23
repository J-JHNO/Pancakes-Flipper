using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DataBank;

public class Shop : MonoBehaviour {
    private string packName;
    private string packPrice;
    private static string packValue;

    private SQLiteHelper helper;

    // Use this for initialization
    void Start () {
        helper = new SQLiteHelper();
        //helper.createPlayerTable();
        helper.seePlayerTable();

        Debug.Log(helper.getTotalPlayerFlips(Player.getName()));


    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void getPack()
    {
        Transform parent = gameObject.transform.parent;
        packName = ((Text)parent.transform.Find("Name").GetComponent<Text>()).text;
        packPrice = ((Text)parent.transform.Find("Price").GetComponent<Text>()).text;
        packValue = ((Text)parent.transform.Find("Intern Panel").Find("Value").GetComponent<Text>()).text;

        bool isOnPurchase = ((PurchaseAnim)GameObject.FindGameObjectWithTag("Purchase").GetComponent("PurchaseAnim")).isOnPurchase;

        if (!isOnPurchase)
        {
            Transform textPackPurchase = GameObject.FindGameObjectWithTag("Purchase").transform.Find("Pack name");
            textPackPurchase.GetComponent<Text>().text = "Pack " + packName;

            Transform textPackPrice = GameObject.FindGameObjectWithTag("Purchase").transform.Find("Price");
            textPackPrice.GetComponent<Text>().text = packPrice;

            ((PurchaseAnim)GameObject.FindGameObjectWithTag("Purchase").GetComponent("PurchaseAnim")).Play();
            ((PurchaseAnim)GameObject.FindGameObjectWithTag("Purchase").GetComponent("PurchaseAnim")).Reverse();

        }

        
    }

    public void Cancel()
    {
        ((PurchaseAnim)GameObject.FindGameObjectWithTag("Purchase").GetComponent("PurchaseAnim")).Test();
        ((PurchaseAnim)GameObject.FindGameObjectWithTag("Purchase").GetComponent("PurchaseAnim")).Play();

        //StartCoroutine(Wait());

        ((PurchaseAnim)GameObject.FindGameObjectWithTag("Purchase").GetComponent("PurchaseAnim")).Reverse();
        ((PurchaseAnim)GameObject.FindGameObjectWithTag("Purchase").GetComponent("PurchaseAnim")).Test();
    }

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(20);
    }

    public void Purchase()
    {
        bool isOnPurchase = ((PurchaseAnim)GameObject.FindGameObjectWithTag("Purchase").GetComponent("PurchaseAnim")).isOnPurchase;

        if (isOnPurchase)
        {
            Transform parentPanel = gameObject.transform.parent.parent.parent;
            Text t = parentPanel.Find("Header").Find("PancakeCoins").Find("Value").GetComponent<Text>();
            int now;
            System.Int32.TryParse(packValue, out now);
            //t.text = ((before + now).ToString());


            int flips = helper.getTotalPlayerFlips(Player.getName());
            flips += (now);
            helper.updatePlayer(Player.getName(), flips);

            t.text = helper.getTotalPlayerFlips(Player.getName()).ToString();

          
            
        }
    }
}
