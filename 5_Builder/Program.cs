using System.Text;

namespace _5_Builder;


// Product
// IBuilder
// ConcreteBuilder1, ConcreteBuilder2
// Director (Optional)


class House // Product
{
	public string? Name { get; set; }
	public int Walls { get; set; }
	public int Doors { get; set; }
	public int Windows { get; set; }
	public bool HasRoof { get; set; }
	public bool HasGarage { get; set; }
	public bool HasGarden { get; set; }
	public bool HasPool { get; set; }

	public override string ToString()
	=> @$"
        Name {Name}
        Walls {Walls}
        Doors {Doors}
        Windows {Windows}
        HasRoof {HasRoof}
        HasGarage {HasGarage}
        HasGarden {HasGarden}
        HasPool {HasPool}";
}


interface IHouseBuilder
{
	House House { get; set; }

	IHouseBuilder BuildWalls(int count);
	IHouseBuilder BuildDoors(int count);
	IHouseBuilder BuildWindows(int count);
	IHouseBuilder BuildRoof();
	IHouseBuilder BuildGarage();
	IHouseBuilder BuildGarden();
	IHouseBuilder BuildPool();

	void Reset();
	House Build();
}


class WoodHouseBuilder : IHouseBuilder
{
	public House House { get; set; } = new House { Name = "WoodHouse" };

	public IHouseBuilder BuildDoors(int count)
	{
		House.Doors = count;
		return this;
	}
	public IHouseBuilder BuildGarage()
	{
		House.HasGarage = true;
		return this;
	}
	public IHouseBuilder BuildGarden()
	{
		House.HasGarden = true;
		return this;
	}
	public IHouseBuilder BuildPool()
	{
		House.HasPool = true;
		return this;
	}
	public IHouseBuilder BuildRoof()
	{
		House.HasRoof = true;
		return this;
	}
	public IHouseBuilder BuildWalls(int count)
	{
		House.Walls = count;
		return this;
	}
	public IHouseBuilder BuildWindows(int count)
	{
		House.Windows = count;
		return this;
	}

	public House Build()
	{
		var result = House;

		Reset();
		House.Name = "WoodHouse";

		return result;
	}

	public void Reset() => House = new House();
}

class StoneHouseBuilder : IHouseBuilder
{
	public House House { get; set; } = new House { Name = "StoneHouse" };

	public IHouseBuilder BuildDoors(int count)
	{
		House.Doors = count;
		return this;
	}
	public IHouseBuilder BuildGarage()
	{
		House.HasGarage = true;
		return this;
	}
	public IHouseBuilder BuildGarden()
	{
		House.HasGarden = true;
		return this;
	}
	public IHouseBuilder BuildPool()
	{
		House.HasPool = true;
		return this;
	}
	public IHouseBuilder BuildRoof()
	{
		House.HasRoof = true;
		return this;
	}
	public IHouseBuilder BuildWalls(int count)
	{
		House.Walls = count;
		return this;
	}
	public IHouseBuilder BuildWindows(int count)
	{
		House.Windows = count;
		return this;
	}
	public House Build()
	{
		var result = House;

		Reset();
		House.Name = "StoneHouse";

		return result;
	}

	public void Reset() => House = new House();
}



class Director
{

	private IHouseBuilder _builder;

	public Director(IHouseBuilder builder)
	{
		_builder = builder;
	}


	public void ChangeBuilder(IHouseBuilder builder)
	{
		_builder = builder;
	}

	public IHouseBuilder BuildMinimalHouse() // Fluent
		=> _builder
			   .BuildWalls(4)
			   .BuildDoors(1)
			   .BuildWindows(2)
			   .BuildRoof();

	public IHouseBuilder BuildFullFeaturedHouse() // Fluent
		=> _builder
			   .BuildWalls(12)
			   .BuildDoors(3)
			   .BuildWindows(7)
			   .BuildRoof()
			   .BuildGarage()
			   .BuildGarden()
			   .BuildPool();

}


class Program
{
	static void Main()
	{
		IHouseBuilder builder = new StoneHouseBuilder();

		Director director = new(builder);
		House house = director.BuildFullFeaturedHouse().Build();

        Console.WriteLine(house);



        // FluentValidation 

        // StringBuilder sb = new StringBuilder();
        // 
        // string fullname = sb
        //         .Append("Kamran")
        //         .Append(" ")
        //         .Append("Karimzada")
        //         .ToString();
        // 
        // Console.WriteLine(fullname);

    }
}