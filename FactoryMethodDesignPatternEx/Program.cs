GarantiBank garanti = BankCreator.Create(BankType.Garanti) as GarantiBank;
HalkBank halkbank = BankCreator.Create(BankType.Halkbank) as HalkBank;
VakıfBank vakifBank = BankCreator.Create(BankType.Vakifbank) as VakıfBank;

#region Abstract Product
interface IBank
{

}
#endregion
#region Concrete Products
class GarantiBank : IBank
{
    string _userCode, _password;
    public GarantiBank(string userCode, string password)
    {
        Console.WriteLine($"{nameof(GarantiBank)} object created.");
        _userCode = userCode;
        _password = password;
    }

    public void ConnectGaranti()
        => Console.WriteLine($"{nameof(GarantiBank)} - Connected");
    public void SendMoney(int amount)
        => Console.WriteLine($"{nameof(amount)}  money sent.");
}

class HalkBank : IBank
{
    string _userCode, _password;
    public HalkBank(string userCode)
    {
        Console.WriteLine($"{nameof(HalkBank)} object created.");
        _userCode = userCode;
    }
    public string Password { set => _password = value; }

    public void Send(int amount, string accountNumber)
        => Console.WriteLine($"{amount} money sent.");
}

class CredentialVakifBank
{
    public string UserCode { get; set; }
    public string Email { get; set; }
}
class VakıfBank : IBank
{
    string _userCode, _email, _password;
    public bool IsAuthentcation { get; set; }
    public VakıfBank(CredentialVakifBank credential, string password)
    {
        Console.WriteLine($"{nameof(VakıfBank)} object created.");
        _userCode = credential.UserCode;
        _email = credential.Email;
        _password = password;
    }

    public void ValidateCredential()
    {
        if (true)
            IsAuthentcation = true;
    }

    public void SendMoneyToAccountNumber(int amount, string recipientName, string accountNumber)
        => Console.WriteLine($"{amount} money sent.");
}
#endregion

#region Abstract Factory
interface IBankFactory
{
    IBank CreateInstance();
}
#endregion

#region Concrete Factories
class GarantiFactory : IBankFactory
{
    public IBank CreateInstance()
    {
        GarantiBank garanti = new GarantiBank("asd", "123");
        garanti.ConnectGaranti();
        return garanti;
    }
}
class HalkBankFactory : IBankFactory
{
    public IBank CreateInstance()
    {
        HalkBank halkBank = new("asd");
        halkBank.Password = "123";
        return halkBank;
    }
}
class VakıfBankFactory : IBankFactory
{
    public IBank CreateInstance()
    {
        VakıfBank vakifBank = new(new() { Email = "emre@emremenekse.com", UserCode = "emre" }, "123");
        vakifBank.ValidateCredential();
        return vakifBank;
    }
}
#endregion

#region Creator
public enum BankType
{
    Garanti, Halkbank, Vakifbank
}
public static class BankCreator
{
    
    internal static IBank Create(BankType bankType)
    {
        IBankFactory _bankFactory = bankType switch
        {
            BankType.Garanti => new VakıfBankFactory(),
            BankType.Halkbank => new HalkBankFactory(),
            BankType.Vakifbank => new VakıfBankFactory(),
        };

        return _bankFactory.CreateInstance();
    }
}
#endregion