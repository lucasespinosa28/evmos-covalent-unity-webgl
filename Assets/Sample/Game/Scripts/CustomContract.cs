using System.Runtime.InteropServices;

public class CustomContract
{
    [DllImport("__Internal")]
    public static extern void SendMintNFT(string contract, int id);
}
