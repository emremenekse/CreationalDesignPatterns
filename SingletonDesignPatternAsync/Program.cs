

//Example.GetInstance();
//Example.GetInstance();
//Example.GetInstance();

var t1 = Task.Run(() =>
{
    Example.GetInstance();
});
var t2 = Task.Run(() =>
{
    Example.GetInstance();
});
await Task.WhenAll(t1, t2);
var t3 = Task.Run(() =>
{
    Example.GetInstance();
});
var t4 = Task.Run(() =>
{
    Example.GetInstance();
});
await Task.WhenAll(t3, t4);

class Example
{
    private Example()
    {
        Console.WriteLine("Object created.");
    }

    static Example _example;
    static object _obj = new object();
    static public Example GetInstance()
    {
        lock (_obj)
        {
            if (_example == null)
            {
                _example = new Example();
            }
        }
        
        return _example;
    }
}