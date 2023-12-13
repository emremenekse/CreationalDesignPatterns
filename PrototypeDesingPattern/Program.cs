
Person person = new("Emre", "Menekse", Department.C, 100, 10);

Person person1 = person.Clone();
person1.Name = "Test";

#region Abstract Prototype
interface IPersonCloneable
{
    Person Clone();
}
#endregion

#region Concrete Prototype
class Person : IPersonCloneable
{
    public Person(string name, string surName, Department department, int salary, int premium)
    {
        Name = name;
        Surname = surName;
        Department = department;
        Salary = salary;
        Premium = premium;
        Console.WriteLine("Person Object Created");
    }

    public string Name { get; set; }
    public string Surname { get; set; }
    public Department Department { get; set; }
    public int Salary { get; set; }
    public int Premium { get; set; }

    public Person Clone()
    {
        return  (Person)base.MemberwiseClone();
    }
} 
#endregion
enum Department
{
    A,B,C
}

// Concrete Prototype can inherited from ICloneable this interface has a Clone method so you do not need to create Abstract Prototype