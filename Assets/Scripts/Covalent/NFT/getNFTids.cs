using System;
using System.Collections;
using System.Threading.Tasks;
using UnityEngine;

namespace Covalent
{
    public partial class NFT
    {
        public class NFTTokenIDsContract
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
                public int contract_decimals;
                public string contract_name;
                public string contract_ticker_symbol;
                public string contract_address;
                public object supports_erc;
                public string logo_url;
                public string token_id;
            }
        }
        /// <summary>Given chain_id and contract_address, return a list of all token IDs for the NFT contract on the blockchain.</summary>
        /// <param name="contract">Smart contract address.</param>
        /// <param name="pageNumber">The specific page to be returned.</param>
        /// <param name="pageSize">The number of results per page.</param>
        public static async Task<NFTTokenIDsContract.Request> AsyncGetNFTTokenIDsContract(string contract, int pageNumber = 0, int pageSize = 100)
        {
            string url = $"https://api.covalenthq.com/v1/{Settings.ChainId}/tokens/{contract}/nft_token_ids/?quote-currency=USD&format=JSON&page-number={pageNumber}&page-size={pageSize}&key={Settings.Apikey}";
            var result = await WebRequest.AsyncGetRquest(url);
            if (result.Item2 != 200)
            {
                return null;
            }
            return JsonUtility.FromJson<NFTTokenIDsContract.Request>(result.Item1);
        }
    }
}