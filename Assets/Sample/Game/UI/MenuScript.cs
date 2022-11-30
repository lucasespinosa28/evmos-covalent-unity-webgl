using System;
using Covalent;
using UnityEngine;
using UnityEngine.UIElements;

public class MenuScript : MonoBehaviour
{
    //SelectFrog
    [SerializeField]
    public UIDocument m_UIDocument;

    [SerializeField] 
    public String Contract = "0x4e604349cd91c223cc92202f754b23a66a3e76bb";
    private  Label BalanceLabel;
    private Button connectBTN;
    private Button FetchAccountBTN;
    private VisualElement root;
    [SerializeField]
    public GameObject NFT1;
    [SerializeField]
    public GameObject NFT2;
    [SerializeField]
    public GameObject NFT3;
    [SerializeField]
    public GameObject NFT4;
    

    public static bool conneteced = false;
    void Start()
    {
        root = m_UIDocument.rootVisualElement;
        connectBTN = root.Q<Button>("Connect");
        connectBTN.RegisterCallback<ClickEvent>(connect);
        FetchAccountBTN = root.Q<Button>("FetchAccount");
        FetchAccountBTN.RegisterCallback<ClickEvent>(getBalance);
        FetchAccountBTN.AddToClassList("Hidden");
        root.Q<Button>("NFTSelect1").RegisterCallback<ClickEvent>(NFTSelect1);
        root.Q<Button>("NFTSelect2").RegisterCallback<ClickEvent>(NFTSelect2);
        root.Q<Button>("NFTSelect3").RegisterCallback<ClickEvent>(NFTSelect3);
        root.Q<Button>("NFTSelect4").RegisterCallback<ClickEvent>(NFTSelect4);
        
        root.Q<Button>("NFTMint1").RegisterCallback<ClickEvent>((evt) => Warning(evt,1));
        root.Q<Button>("NFTMint2").RegisterCallback<ClickEvent>((evt) => Warning(evt,2));
        root.Q<Button>("NFTMint3").RegisterCallback<ClickEvent>((evt) => Warning(evt,3));
        root.Q<Button>("NFTMint4").RegisterCallback<ClickEvent>((evt) => Warning(evt,4));
    }
    void NFTSelect1(ClickEvent evt)
    {
        NFT3.name = "Player";
        Instantiate(NFT1, new Vector2(-5, -2.5f), Quaternion.identity).name = "Player";
    }
    void NFTSelect2(ClickEvent evt)
    {
        NFT3.name = "Player";
        Instantiate(NFT2, new Vector2(-5, -2.5f), Quaternion.identity).name = "Player";
    }
    void NFTSelect3(ClickEvent evt)
    {
        NFT3.name = "Player";
        Instantiate(NFT3, new Vector2(-5, -2.5f), Quaternion.identity).name = "Player";
    }
    void NFTSelect4(ClickEvent evt)
    {
        Instantiate(NFT4, new Vector2(-5, -2.5f), Quaternion.identity).name = "Player";
    }
    void connect(ClickEvent evt)
    {
        //conneteced = true;
        EVM.Wallet.WalletConnect();
    }

    void Warning(ClickEvent evt,int id)
    {
        CustomContract.SendMintNFT(Contract, id);
        root.Q<Label>("warning").RemoveFromClassList("Hidden");
        root.Q<Label>("warning").AddToClassList("Show");
    }
    async void getBalance(ClickEvent evt)
    {
        Covalent.Settings.Apikey = "ckey_ca92549153f74604a03a6b01a87";
        FetchAccountBTN.text = "Loading...";
        try
        {
           // var result = await Covalent.Balance.AsyncGetTokenBalancesAddress("", true, true);
            var result = await Covalent.Balance.AsyncGetTokenBalancesAddress(EVM.Wallet.getAddress, true, true);
            foreach (var item in result.data.items)
            {
                if (item.contract_address.Contains(Contract))
                {
                    foreach (var data in item.nft_data)
                    {
                        root.Q<Button>($"NFTMint{data.token_id}").RemoveFromClassList("Show");
                        root.Q<Button>($"NFTMint{data.token_id}").AddToClassList("Hidden");
                        
                        root.Q<Button>($"NFTSelect{data.token_id}").RemoveFromClassList("Hidden");
                        root.Q<Button>($"NFTSelect{data.token_id}").AddToClassList("Show");
                    }
                }
            }
        }
        catch (Exception e)
        {
            FetchAccountBTN.text = $"Error: {e.Message}, Try again.";
        }finally
        {
            FetchAccountBTN.text = "Fetch account data again.";
            root.Q<VisualElement>("NFTcontainer").RemoveFromClassList("Hidden");
            root.Q<VisualElement>("NFTcontainer").AddToClassList("Show");
        }
       
    }
    private void Update()
    {
        // if (conneteced)
        // {
        //     connectBTN.AddToClassList("Hidden");
        //     FetchAccountBTN.RemoveFromClassList("Hidden");
        //     FetchAccountBTN.AddToClassList("Show");
        //
        // }
        if(EVM.Wallet.getAddress.Contains("0x"))
        {
            connectBTN.AddToClassList("Hidden");
            FetchAccountBTN.RemoveFromClassList("Hidden");
            FetchAccountBTN.AddToClassList("Show");
        }
        if (GameObject.Find("Player") == null)
        {
            root.Q<VisualElement>("Container").RemoveFromClassList("Hidden");
            root.Q<VisualElement>("Container").AddToClassList("Show");
            
        }
        else
        {
            root.Q<VisualElement>("Container").RemoveFromClassList("Show");
            root.Q<VisualElement>("Container").AddToClassList("Hidden");
        }
        
    }
}
