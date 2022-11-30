using System;
using System.Threading.Tasks;
using UnityEngine;

namespace Covalent
{
    public partial class Base
    {
        public class AllChainsStatuses
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
                public string name;
                public string chain_id;
                public bool is_testnet;
                public string logo_url;
                public int synced_block_height;
                public DateTime synced_blocked_signed_at;
                public bool has_data;
            }
        }
        /// <summary>Returns a list of all chain statuses.</summary>
        public static async Task<AllChainsStatuses.Request> AsyncGetAllChainStatuses()
        {
            string url = $"https://api.covalenthq.com/v1/chains/status/?quote-currency=USD&format=JSON&key={Settings.Apikey}";
            var result = await WebRequest.AsyncGetRquest(url);
            if (result.Item2 != 200)
            {
                return null;
            }
            return JsonUtility.FromJson<AllChainsStatuses.Request>(result.Item1);
        }
    }
}