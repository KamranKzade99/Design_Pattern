namespace _1_Factory_Method.Example_1;

/*

Factory Design Pattern Musbet ve Menfi terefleri:

Musbet terefleri:

1. Classlar arasinda six elaqeleri azaldir.
2. Single Responsibility prinsipini destekleyir.
3. Open Closed prinsipini destekleyir.
4. Dependency inversion principini destekleyir.

Menfi terefleri:

1. Kod coxalir.

*/

interface IProduct
{
	string ShipFrom();
}


class ProductA : IProduct
{
	public string ShipFrom()
	{
		return " from South Africa";
	}
}

class ProductB : IProduct
{
	public string ShipFrom()
	{
		return " from Spain";
	}
}

class DefaultProduct : IProduct
{
	public string ShipFrom()
	{
		return "not available";
	}
}


class Creator
{
	public IProduct FactoryMethod(int month)
		=> month switch
		{
			>= 4 and <= 11 => new ProductA(),
			1 or 2 or 12 => new ProductB(),
			_ => new DefaultProduct()
		};
}



class Client
{
	private IProduct product;
	private Creator c = new Creator();

	public void Run()
	{
		for (int m = 1; m <= 12; m++)
		{
			product = c.FactoryMethod(m);
			Console.WriteLine("Avocados " + product.ShipFrom());
		}
	}
}



class Avocado
{
	static void Main(string[] args)
	{
		var client = new Client();
		client.Run();
	}
}
