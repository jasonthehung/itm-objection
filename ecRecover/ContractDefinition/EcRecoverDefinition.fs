namespace Itm_objection.Contracts.ecRecover.ContractDefinition

open System
open System.Threading.Tasks
open System.Collections.Generic
open System.Numerics
open Nethereum.Hex.HexTypes
open Nethereum.ABI.FunctionEncoding.Attributes
open Nethereum.RPC.Eth.DTOs
open Nethereum.Contracts.CQS
open Nethereum.Contracts
open System.Threading

    
    
    type EcRecoverDeployment(byteCode: string) =
        inherit ContractDeploymentMessage(byteCode)
        
        static let BYTECODE = "608060405234801561001057600080fd5b5061001a3361001f565b61006f565b600080546001600160a01b038381166001600160a01b0319831681178455604051919092169283917f8be0079c531659141344cd1fd0a4f28419497f9722a3daafe3b4186f6b6457e09190a35050565b6104ef8061007e6000396000f3fe608060405234801561001057600080fd5b50600436106100625760003560e01c806319045a25146100675780636c19e78314610097578063715018a6146100ac5780638da5cb5b146100b4578063a7bb5803146100c5578063f2fde38b146100f6575b600080fd5b61007a610075366004610405565b610109565b6040516001600160a01b0390911681526020015b60405180910390f35b6100aa6100a536600461044c565b610188565b005b6100aa6101b2565b6000546001600160a01b031661007a565b6100d86100d336600461047c565b6101c6565b60408051938452602084019290925260ff169082015260600161008e565b6100aa61010436600461044c565b61023f565b600080600080610118856101c6565b6040805160008152602081018083528b905260ff8316918101919091526060810184905260808101839052929550909350915060019060a0016020604051602081039080840390855afa158015610173573d6000803e3d6000fd5b5050604051601f190151979650505050505050565b6101906102b8565b600180546001600160a01b0319166001600160a01b0392909216919091179055565b6101ba6102b8565b6101c46000610312565b565b600080600083516041146102215760405162461bcd60e51b815260206004820152601860248201527f696e76616c6964207369676e6174757265206c656e677468000000000000000060448201526064015b60405180910390fd5b50505060208101516040820151606090920151909260009190911a90565b6102476102b8565b6001600160a01b0381166102ac5760405162461bcd60e51b815260206004820152602660248201527f4f776e61626c653a206e6577206f776e657220697320746865207a65726f206160448201526564647265737360d01b6064820152608401610218565b6102b581610312565b50565b6000546001600160a01b031633146101c45760405162461bcd60e51b815260206004820181905260248201527f4f776e61626c653a2063616c6c6572206973206e6f7420746865206f776e65726044820152606401610218565b600080546001600160a01b038381166001600160a01b0319831681178455604051919092169283917f8be0079c531659141344cd1fd0a4f28419497f9722a3daafe3b4186f6b6457e09190a35050565b634e487b7160e01b600052604160045260246000fd5b600082601f83011261038957600080fd5b813567ffffffffffffffff808211156103a4576103a4610362565b604051601f8301601f19908116603f011681019082821181831017156103cc576103cc610362565b816040528381528660208588010111156103e557600080fd5b836020870160208301376000602085830101528094505050505092915050565b6000806040838503121561041857600080fd5b82359150602083013567ffffffffffffffff81111561043657600080fd5b61044285828601610378565b9150509250929050565b60006020828403121561045e57600080fd5b81356001600160a01b038116811461047557600080fd5b9392505050565b60006020828403121561048e57600080fd5b813567ffffffffffffffff8111156104a557600080fd5b6104b184828501610378565b94935050505056fea26469706673582212205f39fa647dd0cdc9978bba070db2a1460c1262a607ba41da06518fac92f2157764736f6c63430008130033"
        
        new() = EcRecoverDeployment(BYTECODE)
        

        
    
    [<Function("owner", "address")>]
    type OwnerFunction() = 
        inherit FunctionMessage()
    

        
    
    [<Function("recover", "address")>]
    type RecoverFunction() = 
        inherit FunctionMessage()
    
            [<Parameter("bytes32", "_ethSignedMessageHash", 1)>]
            member val public EthSignedMessageHash = Unchecked.defaultof<byte[]> with get, set
            [<Parameter("bytes", "_signature", 2)>]
            member val public Signature = Unchecked.defaultof<byte[]> with get, set
        
    
    [<Function("renounceOwnership")>]
    type RenounceOwnershipFunction() = 
        inherit FunctionMessage()
    

        
    
    [<Function("setSigner")>]
    type SetSignerFunction() = 
        inherit FunctionMessage()
    
            [<Parameter("address", "signer_", 1)>]
            member val public Signer = Unchecked.defaultof<string> with get, set
        
    
    [<Function("splitSignature", typeof<SplitSignatureOutputDTO>)>]
    type SplitSignatureFunction() = 
        inherit FunctionMessage()
    
            [<Parameter("bytes", "sig", 1)>]
            member val public Sig = Unchecked.defaultof<byte[]> with get, set
        
    
    [<Function("transferOwnership")>]
    type TransferOwnershipFunction() = 
        inherit FunctionMessage()
    
            [<Parameter("address", "newOwner", 1)>]
            member val public NewOwner = Unchecked.defaultof<string> with get, set
        
    
    [<Event("OwnershipTransferred")>]
    type OwnershipTransferredEventDTO() =
        inherit EventDTO()
            [<Parameter("address", "previousOwner", 1, true )>]
            member val PreviousOwner = Unchecked.defaultof<string> with get, set
            [<Parameter("address", "newOwner", 2, true )>]
            member val NewOwner = Unchecked.defaultof<string> with get, set
        
    
    [<FunctionOutput>]
    type OwnerOutputDTO() =
        inherit FunctionOutputDTO() 
            [<Parameter("address", "", 1)>]
            member val public ReturnValue1 = Unchecked.defaultof<string> with get, set
        
    
    [<FunctionOutput>]
    type RecoverOutputDTO() =
        inherit FunctionOutputDTO() 
            [<Parameter("address", "addr", 1)>]
            member val public Addr = Unchecked.defaultof<string> with get, set
        
    
    
    
    
    
    [<FunctionOutput>]
    type SplitSignatureOutputDTO() =
        inherit FunctionOutputDTO() 
            [<Parameter("bytes32", "r", 1)>]
            member val public R = Unchecked.defaultof<byte[]> with get, set
            [<Parameter("bytes32", "s", 2)>]
            member val public S = Unchecked.defaultof<byte[]> with get, set
            [<Parameter("uint8", "v", 3)>]
            member val public V = Unchecked.defaultof<byte> with get, set
        
    


