using System.Data;


DatabaseCreator creator = new DatabaseCreator();
Database database = creator.Create(new OracleDatabaseFActory());




enum DatabaseType
{
    Oracle,
    MsSql,
    MySql,
    PostgreSql
}


class Database
{
    public Database()
    {
            
    }
    public Database(DatabaseType type, Connection connection, Command command)
    {
        Type = type;
        Connection = connection;
        Command = command;
    }

    public DatabaseType Type { get; set; }
    public AbstractConnection Connection { get; set; }
    public AbstractCommand Command { get; set; }
}

#region Abstract Product
abstract class AbstractConnection
{
    public abstract string ConnectionString { get; set; }
    public abstract ConnectionState State { get; set; }
    public abstract bool Connect();
    public abstract bool Disconnect();
}
abstract class AbstractCommand
{
    public abstract void Execute(string query);
}

#endregion

#region Concrete Product
class Connection : AbstractConnection
{
    string _connectionString;
    public Connection()
    {

    }
    public Connection(string connectionString)
    {
        _connectionString = connectionString;
    }


    public override string ConnectionString { get => _connectionString; set => _connectionString = value; }
    public override ConnectionState State { get; set; }
    public override bool Connect()
    {
        State = ConnectionState.Open;
        //processing
        return true;
    }

    public override bool Disconnect()
    {
        State = ConnectionState.Closed;
        return true;
    }
}

class Command : AbstractCommand
{
    public override void Execute(string query)
    {
        //executing
    }
}

#endregion


#region Abstract Factory
abstract class DatabaseFactory
{
    public abstract AbstractCommand CreateCommand();
    public abstract AbstractConnection CreateConnection();
}
#endregion

#region Concrete Factory

class MSSqlDatabaseFActory : DatabaseFactory
{
    public override AbstractCommand CreateCommand()
    {
        Command command = new();
        return command;
    }
    public override AbstractConnection CreateConnection()
    {
        Connection connection = new Connection();
        connection.ConnectionString = "MSSQL ConnectionString";
        return connection;
    }
}

class OracleDatabaseFActory : DatabaseFactory
{
    public override AbstractCommand CreateCommand()
    {
        Command command = new();
        return command;
    }
    public override AbstractConnection CreateConnection()
    {
        Connection connection = new();
        connection.ConnectionString = "Oracle ConnectionString";
        return connection;
    }
}
class MYSqlDatabaseFActory : DatabaseFactory
{
    public override AbstractCommand CreateCommand()
    {
        Command command = new();
        return command;
    }
    public override AbstractConnection CreateConnection()
    {
        Connection connection = new();
        connection.ConnectionString = "MYSQL ConnectionString";
        return connection;
    }
}
#endregion

#region Creator
class DatabaseCreator
{
    AbstractConnection _connection;
    AbstractCommand _command;

    public Database Create(DatabaseFactory databaseFactory)
    {
        _connection = databaseFactory.CreateConnection();
        _command = databaseFactory.CreateCommand();

        return new()
        {
            Connection = _connection,
            Command = _command,
            Type = (DatabaseType)Enum.Parse(typeof(DatabaseType), 
                databaseFactory.GetType().Name.Replace("DatabaseFactory", ""))
        };
    }
}
#endregion
