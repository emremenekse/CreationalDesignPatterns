
Example ex = Example.GetInstance;
Example ex2 = Example.GetInstance;
Example ex3 = Example.GetInstance;
Example ex4 = Example.GetInstance;



class Example
{
    private Example()
    {
        Console.WriteLine($"{nameof(Example)} nesnesi oluşturuldu.");
    }

    static Example()
    {
        _example = new Example();
    }
    private static Example _example;

    public static Example GetInstance 
    { 
        get 
        {
            #region First Type
            //if (_example == null)
            //{
            //    _example = new Example();

            //}
            //return _example;
            #endregion

            #region Second Type
            return _example;
            #endregion
        }

    }
}