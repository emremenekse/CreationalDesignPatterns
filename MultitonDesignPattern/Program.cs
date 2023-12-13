

var msSql = Database.GetInstance("MSSQL");
var oracle = Database.GetInstance("ORACLE");
var mongoDb = Database.GetInstance("MONGODB");

var msSql2 = Database.GetInstance("MSSQL");
var oracle2 = Database.GetInstance("ORACLE");
var mongoDb2 = Database.GetInstance("MONGODB");

class Database
{
    private Database() 
    {
        Console.WriteLine($"{nameof(Database)} has created. ");
    }

    static Dictionary<string, Database> _databases = new Dictionary<string, Database>();

    public static Database GetInstance(string key)
    {
        if (!_databases.ContainsKey(key))
        {
            _databases[key] = new Database();
        }
        return _databases[key];
    }
    
}