
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    [System.Serializable] class ShopItem {
        public string Name;
        public Material Image;
        public int Price;
        public bool IsPurchased = false;
    }
    #region animations
    [SerializeField] Animator NoCoinsAnim;
    [SerializeField] Text CoinsText;
    #endregion

    [SerializeField] List<ShopItem> ShopItemsList;

    GameObject ItemTemplate;
    GameObject g;
    [SerializeField]Transform ShopScrollView;
    Button buyBtn;
    void Start() {
        ItemTemplate = ShopScrollView.GetChild(0).gameObject;

        int len = ShopItemsList.Count;
        for (int i = 0; i <len; i++) {
            g = Instantiate(ItemTemplate, ShopScrollView);
            g.transform.GetChild(0).GetComponent<Text>().text = ShopItemsList[i].Name;
            g.transform.GetChild(1).GetComponent<MeshRenderer>().material = ShopItemsList[i].Image;
            g.transform.GetChild(2).GetChild(0).GetComponent<Text>().text = ShopItemsList[i].Price.ToString();
            buyBtn = g.transform.GetChild(3).GetComponent<Button>();
            buyBtn.gameObject.SetActive(!ShopItemsList[i].IsPurchased);
            if (PlayerPrefs.GetInt(ShopItemsList[i].Name) == 1)
                buyBtn.gameObject.SetActive(false);
            buyBtn.AddEventListener(i, OnShopItemBtnClicked);
            if (ShopItemsList[i].Name == "Eye" ) {
                g.transform.GetChild(1).rotation = new Quaternion(0, 400f, 0, 0);
            }
            if (ShopItemsList[i].Name == "Billiard 8")
            {
                g.transform.GetChild(1).rotation = new Quaternion(27.37f, 180f, 0, 0);
            }

        }
        Destroy(ItemTemplate);
        //change UI text: coins
        SetCoinsUI();
    }

    void OnShopItemBtnClicked(int itemIndex) {
        if (Game.Instance.HasEnoughCoins(ShopItemsList[itemIndex].Price)) {
            Game.Instance.UseCoins(ShopItemsList[itemIndex].Price);
            //purchase item
            ShopItemsList[itemIndex].IsPurchased = true;
            Debug.Log(ShopItemsList[itemIndex].Name);
            PlayerPrefs.SetInt(ShopItemsList[itemIndex].Name, 1);
            //disable the button
            buyBtn = ShopScrollView.GetChild(itemIndex).GetChild(3).GetComponent<Button>();
            buyBtn.gameObject.SetActive(false);
            // buyBtn.transform.GetChild(0).GetComponent<Text>().text = "PURCHASED"; if disabled button change text

            SetCoinsUI();
        } else {
            NoCoinsAnim.SetTrigger("NoCoins");
        }
    }
    /*---------------------shop coins UI------------------*/
    void SetCoinsUI() {
        CoinsText.text = PlayerPrefs.GetInt("Coins").ToString();
    }
}
