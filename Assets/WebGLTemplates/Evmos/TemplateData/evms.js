const erc20Abi = [
    "function name() view returns (string)",
    "function symbol() view returns (string)",
    "function decimals() view returns (uint)",
    "function totalSupply() view returns(uint)",
    "function balanceOf(address) view returns (uint)",
    "function transfer(address to, uint amount)",
    "function allowance(address owner, address spender)",
    "function approve(address spender, uint256 amount)",
];
const erc721Abi = [
    "function name() view returns (string)",
    "function symbol() view returns (string)",
    "function tokenURI(tokenId) view returns (string)",
    "function balanceOf(owner) view returns (uint)",
    "function ownerOf(tokenId) view returns (address )",
    "function safeTransferFrom(from, to,tokenId,data)",
    "function safeTransferFrom(from, to,tokenId)",
    "function transferFrom(from, to,tokenId)",
    "function approve(to, tokenId)",
    "function setApprovalForAll(operator, _approved)",
    "function getApproved(tokenId) view returns (address)",
    "function getApproved(owner,operator) view returns (bool)",
    "function Transfer(from, to, tokenId)",
    "function Approval(owner, approved, tokenId)",
    "function ApprovalForAll(owner, approved, approved)",
]
const erc777Abi = [
    "function name() view returns (string)",
    "function symbol() view returns (string)",
    "function granularity() view returns (uint)",
    "function totalSupply() view returns(uint)",
    "function balanceOf(address) view returns (uint)",
    "function send(recipient,amount,data)",
    "function burn(amount,data)",
    "function isApprovedForAll(operator,tokenHolder) view returns (bool)",
    "function authorizeOperator(operator)",
    "function revokeOperator(operator)",
    "function defaultOperators(operator,tokenHolder) view returns (address[])",
    "function operatorSend(sender,recipient,amount,data,operatorData)",
    "function operatorBurn(account,amount,amount,data,operatorData)",
    "function Minted(operator,to,amount,data,operatorData)",
    "function Minted(operator,to,amount,data,operatorData)",
    "function AuthorizedOperator(operator,tokenHolder)",
    "function RevokedOperator(operator,tokenHolder)",
    "function Sent(account,from ,to,amount,data,operatorData)",
    "function allowance(holder,spender) view returns (uint)",
    "function approve(spender,value) view returns (bool)",
    "function transferFrom(holder, recipient, amount) view returns (bool)",
]
const erc1155Abi = [
    "function uri(id) view returns (string)",
    "function balanceOf(account,id) view returns (uint)",
    "function balanceOfBatch(account[],ids[]) view returns (uint[])",
    "function setApprovalForAll(address operator, bool approved)",
    "function isApprovedForAll(account,operator) view returns (bool)",
    "function safeTransferFrom(address from, address to, uint256 id, uint256 amount, bytes data)",
    "function safeBatchTransferFrom(address from, address to, uint256[] ids, uint256[] amounts, bytes data)",
    "function TransferSingle(address operator, address from, address to, uint256 id, uint256 value)",
    "function TransferBatch(address operator, address from, address to, uint256[] ids, uint256[] values)",
    "function ApprovalForAll(account,operator,approved)",
]
// 0xd069C8944c73Dc84391a61B3fee317693c1f3a21
const Settings = {
    Provider: null,
    Signer: null,
    Address: null,
}

const Native = {
    Unity:{
        Address: function (address) {
            myGameInstance.SendMessage('Wallet', 'NativeAddress', address);
        },
        Balance: function (balance) {
            myGameInstance.SendMessage('Wallet', 'NativeBalance', balance);
        },
        TxHash: function(txHash){
            myGameInstance.SendMessage('Wallet', 'NativeTxHash', txHash);
        }
    },
    Browser:{
        Connect: async function(){
           
            const provider = new ethers.providers.Web3Provider(window.ethereum)
            await provider.send("eth_requestAccounts", []);
            await ethereum.request({
                method: 'wallet_switchEthereumChain',
                params: [{ chainId: '0x2328' }],
            });
            try {
               
            } catch (switchError) {
                if (switchError.code === 4902) {
                    try {
                        await ethereum.request({
                            method: 'wallet_addEthereumChain',
                            params: [
                                {
                                    chainId: '0x2328',
                                    chainName: 'Evmos Testnet',
                                    rpcUrls: ['https://eth.bd.evmos.dev:8545']
                                },
                            ],
                        });
                    } catch (addError) {
                        alert(addError.message)
                    }
                }
            }
            Settings.Provider = provider;
            Settings.Signer = provider.getSigner();
            const address = await ethereum.request({ method: 'eth_accounts' })
            Settings.Address = address[0];
            Native.Unity.Address(Settings.Address);
        },
        Balance: async  function(){
            const provider = Settings.Provider;
            const balance = await provider.getBalance(Settings.Address)
            const result = ethers.utils.formatEther(balance)
            Native.Unity.Balance(result.toString());
        },
    }
}

const ERC20 = {
    Unity:{
        Name : function(name){ 
            myGameInstance.SendMessage('Wallet', 'ERC20Name', name);
        },
        Symbol : function(symbol){
            myGameInstance.SendMessage('Wallet', 'ERC20Symbol', symbol);
        },
        Decimals : function(decimals){ 
            myGameInstance.SendMessage('Wallet', 'ERC20Decimals', decimals);
        },
        TotalSupply : function(totalSupply){ 
            myGameInstance.SendMessage('Wallet', 'ERC20TotalSupply', totalSupply);
        }, 
        BalanceOf: function(balanceOf){
            myGameInstance.SendMessage('Wallet', 'ERC20BalanceOf', balanceOf);
        }
    },
    Browser:{
        Name: async  function(contract){
            const Contract = new ethers.Contract(contract, erc20Abi, Settings.Provider);
            const result = await Contract.name()
            ERC20.Unity.Name(result.toString());
        },
        Symbol: async  function(contract){
            const Contract = new ethers.Contract(contract, erc20Abi, Settings.Provider);
            const result = await Contract.symbol()
            ERC20.Unity.Symbol(result.toString());
        },
        Decimals: async  function(contract){
            const Contract = new ethers.Contract(contract, erc20Abi, Settings.Provider);
            const result = await Contract.decimals()
            ERC20.Unity.Decimals(result.toString());
        },
        TotalSupply: async  function(contract){
            const Contract = new ethers.Contract(contract, erc20Abi, Settings.Provider);
            const result = await Contract.totalSupply()
            ERC20.Unity.TotalSupply(result.toString());
        },
        BalanceOf: async  function(contract,address){
            const Contract = new ethers.Contract(contract, erc20Abi, Settings.Provider);
            const result = await Contract.balanceOf(Settings.Address)
            ERC20.Unity.BalanceOf(result.toString());
        },
        Transfer: async  function(contract,to,amount){
            const Contract = new ethers.Contract(contract, erc20Abi, Settings.Signer);
            const Decimals = await Contract.decimals()
            const value = ethers.utils.parseUnits(amount.toString(), Decimals);
            const tx = await Contract.transfer(to.toString(), value);
            Native.Unity.TxHash(tx.hash);
        },
        Allowance: async  function(contract,spender){
            const Consync = new ethers.Contract(contract, erc20Abi, Settings.Signer);
            const tx = await Contract.allowance(Settings.Address, spender.toString());
            Native.Unity.TxHash(tx.hash);
        },
        Approve: async  function(contract,sender,amount){
            const Contract = new ethers.Contract(contract, erc20Abi, Settings.Signer);
            const tx = await Contract.approve(spender.toString(), value);
            Native.Unity.TxHash(tx.hash);
        }
    }
}
// 0x9C1a92C5586042D93C893Fe0f5e38356B6BbBDF7
const ERC1155 = {
    Unity: {
        Uri: function(uri){
            myGameInstance.SendMessage('Wallet', 'ERC1155Uri', uri);
        },
        BalanceOf: function(balance){
            myGameInstance.SendMessage('Wallet', 'ERC1155balanceOf', balance);
        },
        BalanceOfBatch: function(balance) {
            myGameInstance.SendMessage('Wallet', 'ERC1155BalanceOfBatch', balance);
        },
        IsApprovedForAll: function(approved) {
            myGameInstance.SendMessage('Wallet', 'ERC1155IsApprovedForAll', approved);
        }
    },
    Browser:{
        Uri: async function(contract,id){
            const Contract = new ethers.Contract(contract, erc1155Abi, Settings.Provider);
            const result = await Contract.uri(id)
            Unity.Unity.Uri(result.toString());
        },
        BalanceOf: async function(contract,account,id){
            const Contract = new ethers.Contract(contract, erc1155Abi, Settings.Provider);
            const result = await Contract.balanceOf(account,id)
            Unity.Unity.BalanceOf(result.toString());
        },
        BalanceOfBatch: async function(contract,account,id){
            const Contract = new ethers.Contract(contract, erc1155Abi, Settings.Provider);
            const result = await Contract.balanceOf(account,id)
            Unity.Unity.BalanceOf(result.toString());
        },
        SetApprovalForAll: async function(contract,operator,approved){
            const Contract = new ethers.Contract(contract, erc1155Abi, Settings.Signer);
            const tx = await Contract.setApprovalForAll(operator, approved);
            Native.Unity.TxHash(tx.hash);
        },
        IsApprovedForAll: async function(contract,account,operator){
            const Contract = new ethers.Contract(contract, erc1155Abi, Settings.Provider);
            const result = await Contract.isApprovedForAll(account,operator)
            Unity.Unity.IsApprovedForAll(result.toString());
        },
        SafeTransferFrom: async function(contract,from,to,id,amount,data){
            const Contract = new ethers.Contract(contract, erc1155Abi, Settings.Signer);
            const tx = await Contract.safeTransferFrom(from,to,id,amount,data);
            Native.Unity.TxHash(tx.hash);
        },
        SafeBatchTransferFrom: async function(contract,from,to,id,amount,data){
            const Contract = new ethers.Contract(contract, erc1155Abi, Settings.Signer);
            const tx = await Contract.safeBatchTransferFrom(from,to,id,amount,data);
            Native.Unity.TxHash(tx.hash);
        },
        TransferSingle: async function(contract,operator,from,to,id,amount,data){
            const Contract = new ethers.Contract(contract, erc1155Abi, Settings.Signer);
            const tx = await Contract.TransferSingle(operator,from,to,id,amount,data);
            Native.Unity.TxHash(tx.hash);
        },
        TransferBatch: async function(contract,operator,from,to,id,amount,data){
            const Contract = new ethers.Contract(contract, erc1155Abi, Settings.Signer);
            const tx = await Contract.TransferBatch(operator,from,to,id,amount,data);
            Native.Unity.TxHash(tx.hash);
        },
        ApprovalForAll: async function(contract,account,operator,approved){
            const Contract = new ethers.Contract(contract, erc1155Abi, Settings.Signer);
            const tx = await Contract.ApprovalForAll(account,operator,approved);
            Native.Unity.TxHash(tx.hash);
        }
    }
}
const CustomContract = {
    Browser:{
        MintNFT: async function(contract,Id){
        const Contract = new ethers.Contract(contract, ["function mintNFT(uint256 id)"], Settings.Signer);
        const tx = await Contract.mintNFT(Id);
        Native.Unity.TxHash(tx.hash);
        }
    }
}

