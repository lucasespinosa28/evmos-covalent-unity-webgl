using Covalent;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class BaseScript : MonoBehaviour
{
    [SerializeField]
    public UIDocument m_UIDocument;
    // Use this for initialization
    async void Start()
    {
        var root = m_UIDocument.rootVisualElement;
        var getBlock = root.Q<VisualElement>("getBlock");
        var Block = await Covalent.Base.AsyncGetblock();
        if (!Block.IsUnityNull())
        {
            getBlock.Add(new Label { text = $"Updated at: {Block.data.updated_at}" });
            getBlock.Add(new Label { text = $"Signed at: {Block.data.items[0].signed_at}" });
            getBlock.Add(new Label { text = $"height: {Block.data.items[0].height}" });
        }

        var getBlockHeights = root.Q<VisualElement>("getBlockHeights");
        var BlockHeight = await Covalent.Base.AsyncGetBlockHeight("2021-01-01", "2021-01-03");
        if (!BlockHeight.IsUnityNull())
        {
            getBlockHeights.Add(new Label { text = $"Updated at: {BlockHeight.data.updated_at}" });
            foreach (var item in BlockHeight.data.items)
            {
                getBlockHeights.Add(new Label { text = $"height: {item.signed_at}" });
                getBlockHeights.Add(new Label { text = $"Signed at: {item.height}" });
            }
        }
        var getLogContract = root.Q<VisualElement>("getLogContract");
        var LogEventsContract = await Covalent.Base.AsyncGetLogEventsContract("0xc0da01a04c3f3e0be433606045bb7017a7323e38", 12115107, 12240004);
        if (!LogEventsContract.IsUnityNull())
        {
            getLogContract.Add(new Label { text = $"Updated at: {LogEventsContract.data.updated_at}" });
            foreach (var item in LogEventsContract.data.items)
            {
                getLogContract.Add(new Label { text = $"Block height: {item.block_height}" });
                getLogContract.Add(new Label { text = $"Tx hash: {item.tx_hash}" });
            }
        }
        var getLogTopic = root.Q<VisualElement>("getLogTopic");
        var LogEventsTopic = await Covalent.Base.AsyncGetLogEventsTopic("0x804c9b842b2748a22bb64b345453a3de7ca54a6ca45ce00d415894979e22897a", 12500000, 12500100);
        if (!LogEventsTopic.IsUnityNull())
        {
            getLogTopic.Add(new Label { text = $"Updated at: {LogEventsTopic.data.updated_at}" });
            foreach (var item in LogEventsTopic.data.items)
            {
                getLogTopic.Add(new Label { text = $"Block height: {item.block_height}" });
                getLogTopic.Add(new Label { text = $"Tx hash: {item.tx_hash}" });
            }
        }
        var getAllChains = root.Q<VisualElement>("getAllChains");
        var AllChains = await Covalent.Base.AsyncGetAllChains();
        if (!AllChains.IsUnityNull())
        {
            getAllChains.Add(new Label { text = $"Updated at: {AllChains.data.updated_at}" });
            foreach (var item in AllChains.data.items)
            {
                getAllChains.Add(new Label { text = $"Name: {item.name}" });
                getAllChains.Add(new Label { text = $"Chain Id: {item.chain_id}" });
                getAllChains.Add(new Label { text = $"Testnet: {item.is_testnet}" });
                getAllChains.Add(new Label { text = $"Db schema name: {item.db_schema_name}" });
                getAllChains.Add(new Label { text = $"Label: {item.label}" });
                getAllChains.Add(new Label { text = $"Category label: {item.category_label}" });
                var result1 = await WebRequest.AsyncGetTexture(item.logo_url);
                var UrlImage = new ImageFromUrl(result1);
                UrlImage.AddToClassList("imageBox");
                getAllChains.Add(UrlImage);
            }
        }

        var getAllChainsStatus = root.Q<VisualElement>("getAllChainsStatus");
        var AllChainStatuses = await Covalent.Base.AsyncGetAllChainStatuses();
        if (!AllChainStatuses.IsUnityNull())
        {
            getAllChainsStatus.Add(new Label { text = $"Updated at: {AllChainStatuses.data.updated_at}" });
            foreach (var item in AllChainStatuses.data.items)
            {
                getAllChainsStatus.Add(new Label { text = $"Name: {item.name}" });
                getAllChainsStatus.Add(new Label { text = $"Chain Id: {item.chain_id}" });
                getAllChainsStatus.Add(new Label { text = $"Testnet: {item.is_testnet}" });
                var result1 = await WebRequest.AsyncGetTexture(item.logo_url);
                var UrlImage = new ImageFromUrl(result1);
                UrlImage.AddToClassList("imageBox");
                getAllChainsStatus.Add(UrlImage);
                getAllChainsStatus.Add(new Label { text = $"Synced block height: {item.synced_blocked_signed_at}" });
                getAllChainsStatus.Add(new Label { text = $"Synced blocked signed at: {item.synced_blocked_signed_at}" });
                getAllChainsStatus.Add(new Label { text = $"Has data: {item.has_data}" });
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
