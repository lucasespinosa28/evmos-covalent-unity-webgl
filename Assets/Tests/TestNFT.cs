using NUnit.Framework;
using Assets.Tests;
using System.Threading.Tasks;
using System.Collections;
using UnityEngine;

public class TestNFT
{
    static string Contract = "0x7C3e8096B70a4ddc04C4344b8F33b97c9d12bc4E";
    static int TokenId = 4224;
    public TestNFT()
    {
        Covalent.Settings.Apikey = TestSettings.Apikey;
    }
    [Test]
    public async Task GetNFTExternalMetadata()
    {
        var result = await Covalent.NFT.AsyncGetNFTExternalMetadata(Contract, TokenId);
        Assert.IsNotNull(result,JsonUtility.ToJson(result));
        Assert.IsTrue(result.data.items[0].contract_ticker_symbol.Contains("CARE"));
    }
    [Test]
    public async Task GetNFTTokenIDsContract()
    {
        var result = await Covalent.NFT.AsyncGetNFTTokenIDsContract(Contract);
        Assert.IsNotNull(result, JsonUtility.ToJson(result));
        Assert.IsTrue(result.data.items[0].contract_name.Contains("Care Bears"));
    }
    [Test]
    public async Task GetNFTTransactionsContract()
    {
        var result = await Covalent.NFT.AsyncGetNFTTransactionsContract(Contract, TokenId);
        Assert.IsNotNull(result, JsonUtility.ToJson(result));
        Assert.IsTrue(result.data.items[0].contract_name.Contains("Care Bears"));
    }
}
