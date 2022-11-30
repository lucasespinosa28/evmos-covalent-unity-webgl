using System;
using System.Threading.Tasks;
using UnityEngine;

namespace Covalent
{
    public partial class Balance
    {
#pragma warning disable IDE1006 // Naming Styles
        public class HistoricalPortfoliValue
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
                public object pagination;
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
                public Holding[] holdings;
            }
            [Serializable]
            public class Holding
            {
                public DateTime timestamp;
                public float? quote_rate;
                public Open open;
                public High high;
                public Low low;
                public Close close;
            }
            [Serializable]
            public class Open
            {
                public string balance;
                public float? quote;
            }
            [Serializable]
            public class High
            {
                public string balance;
                public float? quote;
            }
            [Serializable]
            public class Low
            {
                public string balance;
                public float? quote;
            }
            [Serializable]
            public class Close
            {
                public string balance;
                public float? quote;
            }

        }
        /// <summary>Given chain_id and wallet address, return wallet value for the last 30 days at 24 hour interval timestamps.</summary>
        /// <param name="address">Passing in an ENS resolves automatically.</param>
        public static async Task<HistoricalPortfoliValue.Request> AsyncGetHistoricalPortfoliValue(string address)
        {
            var result = await WebRequest.AsyncGetRquest($"https://api.covalenthq.com/v1/{Settings.ChainId}/address/{address}/portfolio_v2/?quote-currency=USD&format=JSON&key={Settings.Apikey}");
            if(result.Item2 != 200)
            {
                return null;
            }
            return JsonUtility.FromJson<HistoricalPortfoliValue.Request>(result.Item1);
            
           
        }
    }
}