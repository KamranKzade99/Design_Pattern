using _8_Bridge.Task;

namespace _8_Bridge;

// Implementation
interface IColor
{
	string? Name { get; set; }
	(int, int, int) GetRGB();
}



// Concrete implementation 1
class Red : IColor
{
	public string? Name { get; set; } = "Red";
	public (int, int, int) GetRGB() => (255, 0, 0);
}


// Concrete implementation 2
class Blue : IColor
{
	public string? Name { get; set; } = "Blue";
	public (int, int, int) GetRGB() => (0, 0, 255);
}





// Abstraction
abstract class Shape
{
	public IColor Color { get; set; }

	public double Area { get; protected set; }
	public byte Corner { get; init; }
	public string Name { get; set; }


	protected Shape(IColor color, double area, byte corner, string name)
	{
		Color = color;
		Area = area;
		Corner = corner;
		Name = name;
	}
}



// Refined abstraction (optional)
class Rectangle : Shape
{
	public double Width { get; set; }
	public double Height { get; set; }

	public Rectangle(IColor color, double width, double height)
		: base(color, width * height, 4, nameof(Rectangle))
	{
		Width = width;
		Height = height;
	}

}



// Refined abstraction (optional)
class Circle : Shape
{
	public double Radius { get; set; }

	public Circle(IColor color, double radius)
		: base(color, 3.14 * Math.Pow(radius, 2), 0, nameof(Circle))
	{
		Radius = radius;
	}
}



class Program
{
	static void Main()
	{
		#region Example

		// IColor color = new Red();
		// // color = new Blue();
		// 
		// Shape shape = new Rectangle(color, 10, 7);
		// // shape = new Circle(color, 10);
		// 
		// 
		// Console.WriteLine(shape.Name);
		// Console.WriteLine(shape.Area);
		// Console.WriteLine(shape.Corner);
		// Console.WriteLine(shape.Color.Name);
		// Console.WriteLine(shape.Color.GetRGB());

		#endregion


		#region Example_2

		IDevice device = new Radio();
		device.Volume = 50;
		device.Channel = 22;

		Remote remote = new AdvancedRemote(device);
		remote.ChannnelUp();
		remote.VolumeDown();

		Console.WriteLine(device);


		device = new TV();
		device.Volume = 30;
		device.Channel = 45;

		remote = new AdvancedRemote(device);
		remote.TogglePower();
		remote.VolumeUp();
		remote.ChannnelUp();

		Console.WriteLine();
		Console.WriteLine(device);

		#endregion
	}
}

