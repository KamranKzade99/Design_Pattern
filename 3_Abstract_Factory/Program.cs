﻿abstract class AbstractWater { }

abstract class AbstractBottle
{
	public abstract void Interact(AbstractWater water);
	public abstract void Interact(AbstractCover cover);
}

abstract class AbstractCover { }

abstract class AbstractFactory
{
	public abstract AbstractWater CreateWater();
	public abstract AbstractBottle CreateBottle();
	public abstract AbstractCover CreateCover();
}




class PepsiWater : AbstractWater { }
class CocaColaWater : AbstractWater { }



class PepsiBottle : AbstractBottle
{
	public override void Interact(AbstractWater water)
	{
		Console.WriteLine(this + " interacts with " + water);
	}

	public override void Interact(AbstractCover cover)
	{
		Console.WriteLine(this + " interacts with " + cover);
	}
}
class CocaColaBottle : AbstractBottle
{
	public override void Interact(AbstractWater water)
	{
		Console.WriteLine(this + " interacts with " + water);
	}

	public override void Interact(AbstractCover cover)
	{
		Console.WriteLine(this + " interacts with " + cover);
	}
}


class PepsiCover : AbstractCover { }
class CocaColaCover : AbstractCover { }




class CocaColaFactory : AbstractFactory
{
	public override AbstractWater CreateWater() => new CocaColaWater();
	public override AbstractBottle CreateBottle() => new CocaColaBottle();
	public override AbstractCover CreateCover() => new CocaColaCover();
}

class PepsiFactory : AbstractFactory
{
	public override AbstractWater CreateWater() => new PepsiWater();
	public override AbstractBottle CreateBottle() => new PepsiBottle();
	public override AbstractCover CreateCover() => new PepsiCover();
}






class Client
{
	private readonly AbstractWater _water = null;
	private readonly AbstractBottle _bottle = null;
	private readonly AbstractCover _cover = null;

	public Client(AbstractFactory factory)
	{
		_water = factory.CreateWater();
		_bottle = factory.CreateBottle();
		_cover = factory.CreateCover();
	}


	public void Run()
	{
		_bottle.Interact(_water);
		_bottle.Interact(_cover);
	}
}




class Program
{
	static void Main()
	{
		Client client;

		client = new Client(new CocaColaFactory());
		client.Run();


		client = new Client(new PepsiFactory());
		client.Run();
	}
}