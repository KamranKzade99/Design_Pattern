using System.Collections;

namespace _16_Iterator;


class Student
{
	public int Id { get; set; }
	public string Name { get; set; }
	public string Surname { get; set; }
}



class StudentCollection : IEnumerable
{
	private readonly List<Student> _students = new();

	public void Add(Student student) => _students.Add(student);

	public IEnumerator GetEnumerator()
	   => _students.GetEnumerator();
}





class Program
{

	static void Main()
	{
		StudentCollection students = new();
		students.Add(new Student { Id = 1, Name = "Kamran1", Surname = "Karimzada1" });
		students.Add(new Student { Id = 2, Name = "Kamran2", Surname = "Karimzada2" });



		var iterator = students.GetEnumerator();

		while (iterator.MoveNext())
		{
			Console.WriteLine((iterator.Current as Student).Name);
		}


		iterator.Reset();


		while (iterator.MoveNext())
		{
			Console.WriteLine((iterator.Current as Student).Name);
		}



		// IIterable == IEnumerable
		// IIterator == IEnumerator
	}
}