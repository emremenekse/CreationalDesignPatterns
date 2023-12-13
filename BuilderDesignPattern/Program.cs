
CardDirector cardDirector = new();
Car mercedes = cardDirector.Build(new MercedesBuilder());

Console.WriteLine(mercedes);





#region Director
class CardDirector
{
    public Car Build(ICarBuilder carBuilder)
    {
        carBuilder.SetBrand();
        carBuilder.SetModel();
        carBuilder.SetKm();
        carBuilder.SetTransmission();
        return carBuilder.Car;

    }
}
#endregion


#region Abstract Builder
interface ICarBuilder
{
    Car Car { get;  }
    void SetBrand();
    void SetModel();
    void SetKm();
    void SetTransmission();

}

#endregion

#region Concrete Builder
class MercedesBuilder : ICarBuilder
{
    public Car Car { get;  }
    public MercedesBuilder()
    {
        Car = new Car();
    }
    public void SetBrand()
    {
        Car.Brand = "Mercedes";
    }

    public void SetKm()
    {
        Car.Km = 0;
    }

    public void SetModel()
    {
        Car.Model = "2003";
    }

    public void SetTransmission()
    {
        Car.Auto = true;
    }
}
#endregion


#region Product
class Car
{
    public string Brand { get; set; }
    public string Model { get; set; }
    public decimal Km { get; set; }
    public bool Auto { get; set; }

    public override string ToString()
    {
        Console.WriteLine($"A {Brand} brand car, {Model} model, been produced with an {Auto} transmission and has {Km} kilometers on it.");
        return base.ToString();
    }
} 
#endregion