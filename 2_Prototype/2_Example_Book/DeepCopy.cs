namespace _2_Prototype._2_Example_Book
{
	using System.Runtime.Serialization.Formatters.Binary;


	[Serializable]
	public abstract class IPrototype<T>
	{
		// Shallow copy
		public T Clone()
		{
			return (T)MemberwiseClone();
		}


		// Deep Copy
		public T DeepCopy()
		{
			using MemoryStream stream = new();

#pragma warning disable SYSLIB0011

			BinaryFormatter formatter = new();

			formatter.Serialize(stream, this);

			stream.Seek(0, SeekOrigin.Begin);

			T copy = (T)formatter.Deserialize(stream);
#pragma warning restore SYSLIB0011

			return copy;
		}
	}
}



namespace Prototype_Example_3
{
	record PersonDTO
	{
		public int Id { get; set; }
		public string Name { get; set; }
	}

	class Program
	{
		static void Main()
		{
			PersonDTO p1 = new();
			PersonDTO p2 = p1 with { Name = "Kamran" };
		}
	}
}

namespace Prototype_Example_4
{
	// interface IPrototype
	// {
	//     IPrototype Clone();
	// }


	class Airplane : ICloneable
	{
		//public IPrototype Clone()
		//{
		//    ShallowCopy
		//    Airplane clone = MemberwiseClone() as Airplane;
		//    return clone;
		//}

		public object Clone()
		{
			// ShallowCopy
			Airplane clone = MemberwiseClone() as Airplane;
			return clone;
		}
	}
}