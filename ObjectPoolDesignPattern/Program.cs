using System.Collections.Concurrent;


ObjectPool<X> pools = new ObjectPool<X>();
var x1 = pools.Get(() => new X());

pools.Return(x1);

var x2 = pools.Get(() => new X());



class ObjectPool<T> where T : class
{
    readonly ConcurrentBag<T> _objects;
    public ObjectPool()
    {
        _objects = new ConcurrentBag<T>();
    }

    public T Get(Func<T>? objectGenerator = null)
    {
        return _objects.TryTake(out T instance) ? instance : objectGenerator.Invoke();
    }
    public void Return(T instance)
    {
        _objects.Add(instance);
    }

}
class X
{
    public int Count { get; set; }
    public void Write()
        => Console.WriteLine(Count);
    public X()
    {
        Console.Write("X Creation ");
    }

    ~X()
        => Console.WriteLine("X Destruction");
}