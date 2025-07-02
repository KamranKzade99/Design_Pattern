namespace _17_Memento;

// Saxlamaq istədiyimiz dəyərlərin tanımlandığı yerdir.
class TextMemento
{
	public string Text { get; set; }
	public int CursorPosition { get; set; }
}

// Memento'ların referansının tutulduğu yerdir.
class TextUndoCareTaker
{
	private readonly Stack<TextMemento> _mementos;

	public TextUndoCareTaker()
	{
		_mementos = new();
	}

	// Çağrılma işlemi yapıldığında yığının en üstündeki Memento örneği silinir ve geriye döndürülür.
	// Ekleme işlemi yapıldığında yığının en üstüne Memento örneği eklenir.
	// Klasik Stack.
	public TextMemento TextMemento
	{
		get
		{
			return _mementos.Pop();
		}
		set
		{
			_mementos.Push(value);
		}
	}
}


// Değerleri tutulacak olan ve önceki dəyərlərine geri dönəbilən sinifdir.
// Geriyə dönəbilmə özelliyi olduğundan öncəki vəziyyətləri tutan CareTaker referansını tutur.
class TextOriginator
{
	public string Text { get; set; }
	public int CursorPosition { get; set; }

	private readonly TextUndoCareTaker _textCareTaker;

	public TextOriginator()
	{
		_textCareTaker = new();
	}

	// Anlıq rekord dəyərlərini 
	public void Save()
	{
		_textCareTaker.TextMemento = new TextMemento
		{
			CursorPosition = this.CursorPosition,
			Text = this.Text
		};
	}

	// Geri qaytarma baş verdikdə, UML diaqramında CareTaker-dən yığının ən yüksək dəyərini alır.
	// Dəyər alma prosesindən sonra sinfin cari dəyərlərinə təyin edilir.
	public void Undo()
	{
		TextMemento previousTextMemento = _textCareTaker.TextMemento;

		CursorPosition = previousTextMemento.CursorPosition;
		Text = previousTextMemento.Text;
	}


	public override string ToString()
		=> $"text: {Text}, cursor position: {CursorPosition}";
}



class Program
{
	static void Main()
	{
		TextOriginator textOriginator = new TextOriginator();

		textOriginator.Text = "asm";
		textOriginator.CursorPosition = 3;

		// Anlıq vəziyyət yığına əlavə edilir.
		textOriginator.Save();


		textOriginator.Text = "asmi";
		textOriginator.CursorPosition = 4;

		// Anlıq vəziyyət yığına əlavə edilir.
		textOriginator.Save();

		textOriginator.Text = "asmin";
		textOriginator.CursorPosition = 5;

		// Anlıq vəziyyət yığına əlavə edilir.
		textOriginator.Save();


		// Yığındaki bir öncəki vəziyyətə keçir.
		textOriginator.Undo();
		Console.WriteLine(textOriginator.ToString());

		// Yığındaki bir öncəki vəziyyətə keçir.
		textOriginator.Undo();
		Console.WriteLine(textOriginator.ToString());

		// Yığındaki bir öncəki vəziyyətə keçir.
		textOriginator.Undo();
		Console.WriteLine(textOriginator.ToString());

	}
}