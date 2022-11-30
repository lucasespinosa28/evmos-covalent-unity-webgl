mergeInto(LibraryManager.library, {
    WalletConnect: async function () {
        Native.Browser.Connect();
    },
    WalletBalance: async function(){
        Native.Browser.Balance();
    },
    RequestERC20Name: async function(contract){
        ERC20.Browser.Name(UTF8ToString(contract));
    },
    RequestERC20Symbol: async function(contract){
        ERC20.Browser.Symbol(UTF8ToString(contract));
    },
    RequestERC20Decimals: async function(contract){
        ERC20.Browser.Decimals(UTF8ToString(contract));
    },
    RequestERC20TotalSupply: async function(contract){
        ERC20.Browser.TotalSupply(UTF8ToString(contract));
    },
    RequestERC20BalanceOf: async function(contract){
        ERC20.Browser.BalanceOf(UTF8ToString(contract));
    },
    SendERC20Transfer: async function(contract,to,amount){
        ERC20.Browser.Transfer(UTF8ToString(contract),UTF8ToString(to),amount);
    },
    SendERC20Allowance: async function(contract,sender){
        ERC20.Browser.Allowance(UTF8ToString(contract),UTF8ToString(sender));
    },
    SendERC20Approve: async function(contract,sender,amount){
        ERC20.Browser.Approve(UTF8ToString(contract),UTF8ToString(sender),amount);
    },
    RequestERC1155Uri: async function(contract,id){
        ERC1155.Browser.Uri(UTF8ToString(contract),id);
    },
    RequestERC1155BalanceOf: async function(contract,account,id){
        ERC1155.Browser.BalanceOf(UTF8ToString(contract),UTF8ToString(account),id);
    },
    RequestERC1155BalanceOfBatch: async function(contract,account,id){
        ERC1155.Browser.BalanceOfBatch(UTF8ToString(contract),UTF8ToString(account),id);
    },
    SendERC1155SetApprovalForAll: async function(contract,operator,approved){
        ERC1155.Browser.SetApprovalForAll(UTF8ToString(contract),UTF8ToString(operator),approved);
    },
    RequestERC1155IsApprovedForAll: async function(contract,account,approved){
        ERC1155.Browser.IsApprovedForAll(UTF8ToString(contract),UTF8ToString(account),approved);
    },
    SendERC1155SafeTransferFrom: async function(contract,from,to,id,amount,data){
        ERC1155.Browser.SafeTransferFrom(UTF8ToString(contract),CS(from),CS(to),amount,CS(data));
    },
    SendERC1155SafeBatchTransferFrom: async function(contract,from,to,id,amount,data){
        ERC1155.Browser.SafeBatchTransferFrom( UTF8ToString(contract), UTF8ToString(from), UTF8ToString(to),amount, UTF8ToString(data));
    },
    SendERC1155TransferSingle: async function(contract,operator,from,to,id,amount,data){
        ERC1155.Browser.TransferSingle(CS(contract),CS(operator),CS(from),CS(to),id,amount,CS(data));
    },
    SendERC1155TransferBatch: async function(contract,operator,from,to,id,amount,data){
        ERC1155.Browser.TransferBatch( UTF8ToString(contract), UTF8ToString(operator), UTF8ToString(from), UTF8ToString(to),id,amount, UTF8ToString(data));
    },
    SendERC1155ApprovalForAll: async function(contract,account,operator,approved){
        ERC1155.Browser.ApprovalForAll( UTF8ToString(contract), UTF8ToString(account), UTF8ToString(operator),approved);
    },
    SendMintNFT: async  function(contract,id){
        CustomContract.Browser.MintNFT(UTF8ToString(contract),id)
    }
});