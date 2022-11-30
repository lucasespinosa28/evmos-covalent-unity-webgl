using System;
using System.Threading.Tasks;
using UnityEngine;

namespace Covalent
{
    public partial class Base
    {
        public class AllChains
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
                public string db_schema_name;
                public string label;
                public string category_label;
                public string logo_url;
                public bool is_appchain;
            }
        }
        /// <summary>Returns a list of all chains.</summary>
        public static async Task<AllChains.Request> AsyncGetAllChains()
        {
            string url = $"https://api.covalenthq.com/v1/chains/?quote-currency=USD&format=JSON&key={Settings.Apikey}";
            var result = await WebRequest.AsyncGetRquest(url);
            if (result.Item2 != 200)
            {
                return null;
            }
            return JsonUtility.FromJson<AllChains.Request>(result.Item1);
        }
    }
}