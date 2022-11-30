using System;
using System.Collections;
using System.Net;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking.Types;
using UnityEngine.Networking;

namespace Covalent
{
    public class Settings
    {
        /// <summary>Set aa api key to access covalent Api.</summary>
        public static string Apikey;
        /// <summary>Get or Set chain id, default is EVMOS Testnet 9000.</summary>
        public static string ChainId = "9000";
        /// <summary>Use mainnet to get EVMOS mainnet id or Testnet for it id</summary>
        /// <param name="contract">Smart contract address.</param>
        public static void SetChainId(string id)
        {
            if (id == "mainnet")
            {
                ChainId = "9001";
            }
            if (id == "testnet")
            {
                ChainId = "9000";
            }

            ChainId = id;
        }
    }
}