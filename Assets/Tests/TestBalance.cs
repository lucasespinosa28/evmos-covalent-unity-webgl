using NUnit.Framework;
using Assets.Tests;
using System.Threading.Tasks;
using System.Collections;
using UnityEngine;

public class TestBalance
{
    public TestBalance()
    {
        Covalent.Settings.Apikey = TestSettings.Apikey;
    }
    [Test]
    public async Task GetTokenBalancesAddress()
    {
        var result = await Covalent.Balance.AsyncGetTokenBalancesAddress(TestSettings.address);
        Assert.IsNotNull(result, JsonUtility.ToJson(result));
        Assert.Greater(result.data.items.Length, 3, "have multiples tokens");
    }
    [Test]
    public async Task GetERC20TokenTransfers()
    {
        var address = "0x197e3eCCD00F07B18205753C638c3E59013A92bf";
        var result = await Covalent.Balance.AsyncGetERC20TokenTransfers(address, "0xa0b86991c6218b36c1d19d4a2e9eb0ce3606eb48");
        Assert.IsNotNull(result, JsonUtility.ToJson(result));
    }
    [Test]
    public async Task GetHistoricalPortfoliValue()
    {
        var result = await Covalent.Balance.AsyncGetHistoricalPortfoliValue(TestSettings.address);
        Assert.IsNotNull(result, JsonUtility.ToJson(result));
        Assert.Greater(result.data.items.Length, 3, "have multiples tokens");
    }
    [Test]
    public async Task GetTokenHoldersBlockHeightAsync()
    {
        var address = "0x3883f5e181fccaf8410fa61e12b59bad963fb645";
        var result = await Covalent.Balance.AsyncGetTokenHoldersBlockHeight(address);
        Assert.IsNotNull(result, JsonUtility.ToJson(result));
    }
}
