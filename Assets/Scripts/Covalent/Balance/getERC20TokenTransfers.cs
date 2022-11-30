using System;
using System.Threading.Tasks;
using UnityEngine;

namespace Covalent
{
    public partial class Balance
    {
#pragma warning disable IDE1006 // Naming Styles
        public class ERC20TokenTransfers
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
                public string address;
                public string updated_at;
                public string next_update_at;
                public string quote_currency;
                public int chain_id;
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
                public DateTime block_signed_at;
                public int block_height;
                public string tx_hash;
                public int tx_offset;
                public bool successful;
                public string from_address;
                public object from_address_label;
                public string to_address;
                public object to_address_label;
                public string value;
                public float value_quote;
                public int gas_offered;
                public int gas_spent;
                public long gas_price;
                public object fees_paid;
                public float gas_quote;
                public float gas_quote_rate;
                public Transfer[] transfers;
            }
            [Serializable]
            public class Transfer
            {
                public DateTime block_signed_at;
                public string tx_hash;
                public string from_address;
                public object from_address_label;
                public string to_address;
                public object to_address_label;
                public int contract_decimals;
                public string contract_name;
                public string contract_ticker_symbol;
                public string contract_address;
                public string logo_url;
                public string transfer_type;
                public string delta;
                public object balance;
                public float quote_rate;
                public float delta_quote;
                public object balance_quote;
                public object method_calls;
            }
        }
        /// <summary>Given chain_id, wallet address and contract-address , return all ERC20 token contract transfers along with their historical prices at the time of their transfer</summary>
        /// <param name="address">Passing in an ENS resolves automatically.</param>
        /// <param name="contract">Smart contract address.</param>
        /// <param name="pageNumber">The specific page to be returned.</param>
        /// <param name="pageSize">The number of results per page.</param>
        /// <param name="startingBlock">Starting block to define a block range.</param>
        /// <param name="endingBlock">Ending block to define a block range.</param>
        public static async Task<ERC20TokenTransfers.Request> AsyncGetERC20TokenTransfers(
                string address, 
                string contract,
                int pageNumber = 0,
                int pageSize = 100,
                long startingBlock = -1,
                long endingBlock = -1)
        {
            string blocks = startingBlock == -1 && endingBlock == -1 ? "" : $"starting-block={startingBlock}&ending-block={endingBlock}&";
            string url = $"https://api.covalenthq.com/v1/{Settings.ChainId}/address/{address}/transfers_v2/?quote-currency=USD&format=JSON&contract-address={contract}&page-number={pageNumber}&page-size={pageSize}&{blocks}key={Settings.Apikey}";
            var result = await WebRequest.AsyncGetRquest(url);
            if (result.Item2 != 200)
            {
                return null;
            }
            return JsonUtility.FromJson<ERC20TokenTransfers.Request>(result.Item1);
        }
    }
}