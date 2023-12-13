ComputerCreator computerCreator = new();
Computer asusPC = computerCreator.CreateComputer(new AsusFactory());

#region Abstract Products

interface ICPU
{

}
interface IRAM
{

}
interface IVideoCard
{

}

#endregion

class Computer
{
    public Computer(CPU cpu, RAM ram, VideoCard videoCard)
    {
        CPU = cpu;
        RAM = ram;
        VideoCard = videoCard;
    }
    public CPU CPU { get; set; }
    public RAM RAM { get; set; }
    public VideoCard VideoCard { get; set; }
}

#region Concrete Products
class CPU : ICPU
{
    public CPU(string text)
    {
        Console.WriteLine( text);

    }
}

class RAM : IRAM
{
    public RAM(string text)
    {
        Console.WriteLine(text);

    }
}

class VideoCard : IVideoCard
{
    public VideoCard(string text)
    {
        Console.WriteLine(text);

    }
}
#endregion

#region Abstract Factory
interface IComputerFactory
{
    ICPU CreateCPU();
    IRAM CreateRAM();
    IVideoCard CreateVideoCard();
}
#endregion

#region Concrete Factories

class AsusFactory : IComputerFactory
{
    public ICPU CreateCPU()
    
       => new CPU("Asus CPU created");
    

    public IRAM CreateRAM()
       => new RAM("Asus RAM created");


    public IVideoCard CreateVideoCard()
    
       => new VideoCard("Asus VideoCard created");
    
}

class HpFactory : IComputerFactory
{
    public ICPU CreateCPU()

       => new CPU("Hp CPU created");


    public IRAM CreateRAM()
       => new RAM("Hp RAM created");


    public IVideoCard CreateVideoCard()

       => new VideoCard("Hp VideoCard created");

}

class MSIFactory : IComputerFactory
{
    public ICPU CreateCPU()

       => new CPU("MSI CPU created");


    public IRAM CreateRAM()
       => new RAM("MSI RAM created");


    public IVideoCard CreateVideoCard()

       => new VideoCard("MSI VideoCard created");

}
#endregion

#region Creator
class ComputerCreator
{
    ICPU _cpu;
    IRAM _ram;
    IVideoCard _videoCard;

    public Computer CreateComputer(IComputerFactory computerFactory)
    {
        _cpu = computerFactory.CreateCPU();
        _ram = computerFactory.CreateRAM();
        _videoCard = computerFactory.CreateVideoCard();

        return new Computer(_cpu as CPU, _ram as RAM, _videoCard as VideoCard);
    }
}
#endregion