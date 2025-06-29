namespace _1_Factory_Method.Example_2_Logistics;

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

public interface ITransport
{
	void Deliver();
}

public class Truck : ITransport
{
	public void Deliver() => Console.WriteLine("Delivered By Road in a box");
}

public class Ship : ITransport
{
	public void Deliver() => Console.WriteLine("Delivered By Sea in a container");
}

public class Airplane : ITransport
{
	public void Deliver() => Console.WriteLine("Delivered By Air in a box");
}




public abstract class Logistics
{
	public void PlanDelivery()
	{
		ITransport transport = CreateTranport();
		transport.Deliver();
	}

	public abstract ITransport CreateTranport();
}


public class RoadLogistics : Logistics
{
	public override ITransport CreateTranport() => new Truck();
}

public class SeaLogistics : Logistics
{
	public override ITransport CreateTranport() => new Ship();
}

public class AirLogistics : Logistics
{
	public override ITransport CreateTranport() => new Airplane();
}


class Program
{
	static void Main()
	{
		Logistics? logistics = null;

		while (true)
		{
			Console.Clear();
			Console.WriteLine(@"
                        1: Road
                        2: Sea
                        3: Air
                        Any: Exit");

			Console.Write("\n\tEnter choice: ");


			logistics = Console.ReadLine() switch
			{
				"1" => new RoadLogistics(),
				"2" => new SeaLogistics(),
				"3" => new AirLogistics(),
				_ => null
			};

			if (logistics == null)
				break;


			logistics?.PlanDelivery();

			Console.ReadKey();
		}
	}
}
