using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using UnityEngine;

namespace Covalent
{
    public partial class Balance
    {
#pragma warning disable IDE1006 // Naming Styles
        public class TokenBalancesAddres
        {
            [Serializable]
            public class Request
            {
                public Data data;
                public bool error;
                public object? error_message;
                public object? error_code;
            }
            [Serializable]
            public class Data
            {
                public string address;
                public string updated_at;
                public string next_update_at;
                public string quote_currency;
                public int chain_id;
                public Item[]? items;
                public object? pagination;
            }
            [Serializable]
            public class Item
            {
                public int contract_decimals;
                public string contract_name;
                public string contract_ticker_symbol;
                public string contract_address;
                public string[]? supports_erc;
                public string logo_url;
                public DateTime last_transferred_at;
                public bool native_token;
                public string type;
                public string balance;
                public string balance_24h;
                public float? quote_rate;
                public object? quote_rate_24h;
                public float? quote;
                public object? quote_24h;
                public Nft_Data[]? nft_data;
            }
            [Serializable]
            public class Nft_Data
            {
                public string token_id;
                public string token_balance;
                public string token_url;
                public string[]? supports_erc;
                public object? token_price_wei;
                public object? token_quote_rate_eth;
                public string original_owner;
                public External_Data external_data;
                public object? owner;
                public object? owner_address;
                public object? burned;
            }
            [Serializable]
            public class External_Data
            {
                public string name;
                public string description;
                public string image;
                public string image_256;
                public string image_512;
                public string image_1024;
                public object? animation_url;
                public string external_url;
                public Attribute[]? attributes;
                public object? owner;
            }
            [Serializable]
            public class Attribute
            {

                public string value;

                public string trait_type;
            }
#pragma warning restore IDE1006 // Naming Styles

        }
        /// <summary>Given chain_id and wallet address , return current token balances along with their spot prices. This endpoint supports a variety of token standards like ERC20, ERC721 and ERC1155. As a special case, network native tokens like ETH on Ethereum are also returned even though it's not a token contract.</summary>
        /// <param name="address">Passing in an ENS resolves automatically.</param>
        /// <param name="nft">Set to true to return ERC721 and ERC1155 assets. Defaults to false.</param>
        /// <param name="noNftFetch">Set to true to skip fetching NFT metadata, which can result in faster responses. Defaults to false and only applies when nft=true.</param>
        public static async Task<TokenBalancesAddres.Request> AsyncGetTokenBalancesAddress(string address, bool nft = false, bool noNftFetch = false)
        {
            var result = await WebRequest.AsyncGetRquest($"https://api.covalenthq.com/v1/{Settings.ChainId}/address/{address}/balances_v2/?quote-currency=USD&format=JSON&nft={nft}&no-nft-fetch={noNftFetch}&key={Settings.Apikey}");
            if (result.Item2 != 200)
            {
                return null;
            }
            return JsonUtility.FromJson<TokenBalancesAddres.Request>(result.Item1);
        }
    }
}