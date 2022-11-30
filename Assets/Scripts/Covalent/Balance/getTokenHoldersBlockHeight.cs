using System;
using System.Threading.Tasks;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using static Covalent.Balance.HistoricalPortfoliValue;
using static Covalent.Base;

namespace Covalent
{
    public partial class Balance
    {
#pragma warning disable IDE1006 // Naming Styles
        public class TokenHoldersBlockHeight
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
                public Pagination pagination;
            }
            [Serializable]
            public class Pagination
            {
                public bool has_more;
                public int page_number;
                public int page_size;
                public object total_count;
            }
            [Serializable]
            public class Item
            {
                public decimal contract_decimals;
                public string contract_name;
                public string contract_ticker_symbol;
                public string contract_address;
                public object supports_erc;
                public string logo_url;
                public string address;
                public string balance;
                public string total_supply;
                public decimal block_height;
            }

        }
        /// <summary>Given chain_id and wallet address, return a paginated list of token holders. If block-height  is omitted, the latest block is used.</summary>
        /// <param name="address">Passing in an ENS resolves automatically.</param>
        /// <param name="blockHeight">Ending block to define a block range. Passing in latest uses the latest block height.</param>
        /// <param name="startingBlock">Starting block to define a block range.</param>
        /// <param name="endingBlock">Ending block to define a block range.</param>
        public static async Task<TokenHoldersBlockHeight.Request> AsyncGetTokenHoldersBlockHeight(string address,string blockHeight = "latest", long startingBlock = -1,long endingBlock = -1)
        {
            string blocks = startingBlock == -1 && endingBlock == -1 ? "" : $"starting-block={startingBlock}&ending-block={endingBlock}&";
            string url = $"https://api.covalenthq.com/v1/{Settings.ChainId}/tokens/{address}/token_holders/?quote-currency=USD&format=JSON&block-height={blockHeight}&{blocks}key={Settings.Apikey}";
            var result = await WebRequest.AsyncGetRquest(url);
            if (result.Item2 != 200)
            {
                return null;
            }
            return JsonUtility.FromJson<TokenHoldersBlockHeight.Request>(result.Item1);
        }
    }
}