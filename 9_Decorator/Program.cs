﻿namespace _9_Decorator;

// Ilk once

interface INotifier
{
	void Send(string message);
}


class Email : INotifier
{
	public void Send(string message)
	{
		Console.WriteLine("Message sent with Email"); ;
	}
}



class Application
{
	private readonly INotifier _notifier;
	public Application(INotifier notifier)
	{
		_notifier = notifier;
	}

	public void SendMessage(string message)
	{
		_notifier.Send(message);
	}
}










// Decorators
abstract class BaseDecorator : INotifier
{
	protected INotifier _notifier { get; set; }

	public BaseDecorator(INotifier notifier)
	{
		_notifier = notifier;
	}

	// Virtual yaziriqki, Derived-ler override edib yaza bilsinler.
	public virtual void Send(string message)
	{
		_notifier?.Send(message);
	}
}


class TelegramDecorator : BaseDecorator
{
	public TelegramDecorator(INotifier notifier)
		: base(notifier) { }

	public override void Send(string message)
	{
		// Evvelki olan Notification-i gonderirik, elave sonrada ozumuzkunu gonderirik
		base.Send(message);
		// hard code
		Console.WriteLine("Message sent with Telegram");
	}
}


class FacebookDecorator : BaseDecorator
{
	public FacebookDecorator(INotifier notifier) : base(notifier) { }

	public override void Send(string message)
	{
		// Evvelki olan Notification-i gonderirik, elave sonrada ozumuzkunu gonderirik
		base.Send(message);
		// hard code
		Console.WriteLine("Message sent with Facebook");
	}
}


class SlackDecorator : BaseDecorator
{
	public SlackDecorator(INotifier notifier) : base(notifier) { }

	public override void Send(string message)
	{
		// Evvelki olan Notification-i gonderirik, elave sonrada ozumuzkunu gonderirik
		base.Send(message);
		// hard code
		Console.WriteLine("Message sent with Slack");
	}
}



class Program
{
	static void Main()
	{

		INotifier notifier = new Email();


		// Daha sonradan istenileni elave ede bilerem 
		notifier = new TelegramDecorator(notifier);
		notifier = new SlackDecorator(notifier);
		notifier = new FacebookDecorator(notifier);



		Application client = new(notifier);
		client.SendMessage("Discount 50%");
	}
}