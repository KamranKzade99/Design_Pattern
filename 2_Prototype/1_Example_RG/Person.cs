namespace _2_Prototype.Example_RG;

#nullable disable
using static Console;


public class Person
{
	public int Age;
	public DateTime BirthDate;
	public string Name;
	public IdInfo IdInfo;

	public Person ShallowCopy()
	{
		return MemberwiseClone() as Person;
	}

	public Person DeepCopy()
	{
		Person clone = (Person)MemberwiseClone();
		clone.IdInfo = new IdInfo(IdInfo.IdNumber);
		return clone;
	}
}

public class IdInfo
{
	public int IdNumber;

	public IdInfo(int idNumber)
	{
		IdNumber = idNumber;
	}
}




class Program
{
	static void Main()
	{
		Person p1 = new Person();
		p1.Age = 25;
		p1.BirthDate = Convert.ToDateTime("2000-01-01");
		p1.Name = "Jack Daniels";
		p1.IdInfo = new IdInfo(666);


		Person p2 = p1.ShallowCopy();
		Person p3 = p1.DeepCopy();


		WriteLine("Original values of p1, p2, p3:");

		WriteLine("   p1 instance values: ");
		DisplayValues(p1);

		WriteLine("   p2 instance values:");
		DisplayValues(p2);

		WriteLine("   p3 instance values:");
		DisplayValues(p3);


		p1.Age = 35;
		p1.BirthDate = Convert.ToDateTime("1990-01-01");
		p1.Name = "Frank";
		p1.IdInfo.IdNumber = 7878;

		WriteLine("\nValues of p1, p2 and p3 after changes to p1:");

		WriteLine("   p1 instance values: ");
		DisplayValues(p1);

		WriteLine("   p2 instance values (reference values have changed):");
		DisplayValues(p2);

		WriteLine("   p3 instance values (everything was kept the same):");
		DisplayValues(p3);
	}


	public static void DisplayValues(Person p)
	{
		WriteLine($"\tName: {p.Name}, Age: {p.Age}, BirthDate: {p.BirthDate.ToShortDateString()}");
		WriteLine($"\tID#: {p.IdInfo.IdNumber}");
	}
}


