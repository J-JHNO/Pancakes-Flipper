using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using player;

public class Shop : MonoBehaviour {
    private string packName;
    private string packPrice;

	// Use this for initialization
	void Start () {
        player.Player.getInstance();
        System.Console.Write(player.Player.getName());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void getPack()
    {
        Transform parent = gameObject.transform.parent;
        packName = ((Text)parent.transform.FindChild("Name").GetComponent<Text>()).text;
        packPrice = ((Text)parent.transform.FindChild("Price").GetComponent<Text>()).text;

        bool isOnPurchase = ((PurchaseAnim)GameObject.FindGameObjectWithTag("Purchase").GetComponent("PurchaseAnim")).isOnPurchase;

        if (!isOnPurchase)
        {
            Transform textPackPurchase = GameObject.FindGameObjectWithTag("Purchase").transform.FindChild("Pack name");
            textPackPurchase.GetComponent<Text>().text = "Pack " + packName;

            Transform textPackPrice = GameObject.FindGameObjectWithTag("Purchase").transform.FindChild("Price");
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
}
