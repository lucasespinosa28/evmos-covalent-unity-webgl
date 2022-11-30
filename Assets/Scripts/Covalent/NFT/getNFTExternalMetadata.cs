using System;
using System.Collections;
using System.Threading.Tasks;
using UnityEngine;

namespace Covalent
{
    public partial class NFT
    {
        public class NFTExternalMetadata
        {
            [Serializable]
            public class Request
            {
                public Data data;
                public bool error;
                public object error_message;
                public object error_code;
            }
            [Serializable]
            public class Data
            {
                public string updated_at;
                public Item[] items;
                public object pagination;
            }
            [Serializable]
            public class Item
            {
                public int contract_decimals;
                public string contract_name;
                public string contract_ticker_symbol;
                public string contract_address;
                public string[] supports_erc;
                public string logo_url;
                public string type;
                public Nft_Data[] nft_data;
            }
            [Serializable]
            public class Nft_Data
            {
                public string token_id;
                public object token_balance;
                public string token_url;
                public string[] supports_erc;
                public string token_price_wei;
                public string token_quote_rate_eth;
                public string original_owner;
                public External_Data external_data;
                public object owner;
                public string owner_address;
                public bool burned;
            }
            [Serializable]
            public class External_Data
            {
                public string name;
                public object description;
                public string image;
                public string image_256;
                public string image_512;
                public string image_1024;
                public object animation_url;
                public string external_url;
                public Attribute[] attributes;
                public object owner;
            }
            [Serializable]
            public class Attribute
            {
                public string trait_type;
                public object value;
                public string display_type;
            }

        }
        /// <summary>Given chain_id, contract_address and token_id, fetch and return the external metadata. Both ERC721 as well as ERC1155 standards are supported.</summary>
        /// <param name="contractAddress">Smart contract address.</param>
        /// <param name="tokenId">The token ID</param>
        public static async Task<NFTExternalMetadata.Request> AsyncGetNFTExternalMetadata(string contractAddress,int tokenId)
        {
            string url = $"https://api.covalenthq.com/v1/{Settings.ChainId}/tokens/{contractAddress}/nft_metadata/{tokenId}/?key={Settings.Apikey}";
            var result = await WebRequest.AsyncGetRquest(url);
            if (result.Item2 != 200)
            {
                return null;
            }
            return JsonUtility.FromJson<NFTExternalMetadata.Request>(result.Item1);
        }
    }
}