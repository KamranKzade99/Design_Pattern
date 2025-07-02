using ClosedXML.Excel;
using System.Data;


namespace _14_Command;


#nullable disable
// Nuget: ClosedXML




public class Product
{
	public int Id { get; set; }
	public string Name { get; set; }
	public decimal Price { get; set; }
	public int Stock { get; set; }
}


// Receiver (emri icra etmir, Icrani Invoker edir)
public class ExcelFile<T>
{
	private readonly List<T> _list;
	public string FileName => $"{typeof(T).Name}.xlsx";


	public ExcelFile(List<T> list)
	{
		_list = list;
	}

	public MemoryStream Create()
	{
		var wb = new XLWorkbook();
		var ds = new DataSet();

		ds.Tables.Add(GetTable());

		wb.Worksheets.Add(ds);

		var excelMemory = new MemoryStream();
		wb.SaveAs(excelMemory);

		return excelMemory;
	}

	// Table-i aliram
	private DataTable GetTable()
	{
		var table = new DataTable();

		var type = typeof(T); // Product

		// Columns
		type.GetProperties()
			.ToList()
			.ForEach(x => table.Columns.Add(x.Name, x.PropertyType));

		// Rows 
		_list.ForEach(x =>
		{
			var values = type.GetProperties()
								.Select(properyInfo => properyInfo
								.GetValue(x, null))
								.ToArray();

			table.Rows.Add(values);
		});

		return table;
	}
}




public interface ITableActionCommand
{
	void Execute();
}



public class CreateExcelTableActionCommand<T> : ITableActionCommand
{
	// Receiver-i saxliyiram ( isi goreni saxlayiram )
	private readonly ExcelFile<T> _excelFile;

	public CreateExcelTableActionCommand(ExcelFile<T> excelFile)
		=> _excelFile = excelFile;

	// Gelen melumatlari file-a yazacaq
	public void Execute()
	{
		MemoryStream excelMemoryStream = _excelFile.Create();
		File.WriteAllBytes(_excelFile.FileName, excelMemoryStream.ToArray());
	}
}


// Invoker
class FileCreateInvoker
{
	private ITableActionCommand _tableActionCommand;
	private List<ITableActionCommand> _tableActionCommands = new();

	public void SetCommand(ITableActionCommand tableActionCommand)
	{
		_tableActionCommand = tableActionCommand;
	}


	public void AddCommand(ITableActionCommand tableActionCommand)
	{
		_tableActionCommands.Add(tableActionCommand);
	}

	public void CreateFile()
	{
		_tableActionCommand.Execute();
	}

	public void CreateFiles()
	{
		_tableActionCommands.ForEach(cmd => cmd.Execute());
	}

}


class Program
{
	static void Main()
	{

		List<Product> products = Enumerable.Range(1, 30).Select(index =>
			new Product
			{
				Id = index,
				Name = $"Product {index}",
				Price = index + 100,
				Stock = index
			}
		).ToList();



		// Problemli hal: Excel-e gore veriya
		ExcelFile<Product> receiverExcel = new(products);
		ITableActionCommand commandExcel = new CreateExcelTableActionCommand<Product>(receiverExcel);
		commandExcel.Execute();



		FileCreateInvoker invoker = new();
		// AddCommand ile istediyim commandlari elave ede bilerem
		invoker.AddCommand(new CreateExcelTableActionCommand<Product>(receiverExcel));
		invoker.CreateFiles();
	}
}