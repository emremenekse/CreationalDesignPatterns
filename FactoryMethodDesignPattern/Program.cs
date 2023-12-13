//#region Factory Design Pattern

////IF you need to create an instance of your object.

//A? a = ProductCreator.GetInstance(ProductType.A) as A;
//a.Run();

//#region Abstract Product
//interface IProduct
//{
//    void Run();
//}
//#endregion
//#region Concrete Products
//class A : IProduct
//{
//    public void Run()
//    {
//        throw new NotImplementedException();
//    }
//}
//class B : IProduct
//{
//    public void Run()
//    {
//        throw new NotImplementedException();
//    }
//}
//class C : IProduct
//{
//    public void Run()
//    {
//        throw new NotImplementedException();
//    }
//}
//#endregion

//#region Creator
//enum ProductType
//{
//    A, B, C
//}
//class ProductCreator
//{
//    static public IProduct GetInstance(ProductType productType)
//    {
//        IProduct _product = null;
//        switch (productType)
//        {
//            case ProductType.A:
//                 // ....
//                _product = new A();
//                break;
//            case ProductType.B:
//                  // ....
//                _product = new B();
//                break;
//            case ProductType.C:
//                _product = new C();
//                break;
//            default:
//                break;
//        }

//        return _product;
//    }
//}
//#endregion 
//#endregion

#region Factory Method Design Pattern

//IF you need to create an instance of your object.

A? a = ProductCreator.GetInstance(ProductType.A) as A;
a.Run();

#region Abstract Product
interface IProduct
{
    void Run();
}
#endregion
#region Concrete Products
class A : IProduct
{
    public A()
    {
        Console.WriteLine($"{nameof(A)} object created.");
    }
    public void Run()
    {
        throw new NotImplementedException();
    }
}
class B : IProduct
{
    public B()
    {
        Console.WriteLine($"{nameof(B)} object created.");
    }
    public void Run()
    {
        throw new NotImplementedException();
    }
}
class C : IProduct
{
    public C()
    {
        Console.WriteLine($"{nameof(C)} object created.");
    }
    public void Run()
    {
        throw new NotImplementedException();
    }
}
#endregion

#region Abstract Factory
interface IFactory
{
    IProduct CreateProduct();
}
#endregion
#region Concrete Factories
class AFactory : IFactory
{
    public IProduct CreateProduct()
    {
        A a = new A();
        return a;
    }
}
class BFactory : IFactory
{
    public IProduct CreateProduct()
    {
        B b = new B();
        return b;
    }
}
class CFactory : IFactory
{
    public IProduct CreateProduct()
    {
        C c = new C();
        return c;
    }
}

#endregion
#region Creator 
//This type Creator Has to say which type of Factory will use.
//Because now Create does not have object produce responsibility.
enum ProductType
{
    A, B, C
}
class ProductCreator
{
    static public IProduct GetInstance(ProductType productType)
    {
        IFactory _factory = productType switch
        {
            ProductType.A => new AFactory(),
            ProductType.B => new BFactory(),
            ProductType.C => new CFactory(),
        };
        return _factory.CreateProduct();
    }
}
#endregion
#endregion