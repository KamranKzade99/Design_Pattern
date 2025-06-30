namespace _8_Bridge.Task;

public abstract class Remote
{
	protected readonly IDevice _device;
	public Remote(IDevice device)
	{
		_device = device;
	}


	public void TogglePower()
		=> _device.IsEnabled = !_device.IsEnabled;

	public void VolumeDown() => --_device.Volume;
	public void VolumeUp() => ++_device.Volume;

	public void ChannelDown() => --_device.Channel;
	public void ChannnelUp() => ++_device.Channel;
}

public class AdvancedRemote : Remote
{
	public AdvancedRemote(IDevice device)
		: base(device) { }

	public void Mute()
	{
		_device.Volume = 0;
	}
}

public interface IDevice
{
	bool IsEnabled { get; set; }
	int Volume { get; set; }
	int Channel { get; set; }

	void Enable();
	void Disable();
}

public class Radio : IDevice
{
	public int Volume { get; set; }
	public int Channel { get; set; }
	public bool IsEnabled { get; set; }

	public void Disable() => IsEnabled = false;
	public void Enable() => IsEnabled = true;





	public override string ToString() =>
$"Device {nameof(Radio)},\n" +
$"Is Enabled - {IsEnabled},\n" +
$"Volume - {Volume},\n" +
$"Channel - {Channel}";
}


public class TV : IDevice
{
	public int Volume { get; set; }
	public int Channel { get; set; }
	public bool IsEnabled { get; set; }

	public void Disable() => IsEnabled = false;
	public void Enable() => IsEnabled = true;


	public override string ToString() =>
$"Device {nameof(TV)},\n" +
$"Is Enabled - {IsEnabled},\n" +
$"Volume - {Volume},\n" +
$"Channel - {Channel}";
}


class Program
{
	//static void Main()
	//{
	//	IDevice device = new Radio();
	//	device.Volume = 50;
	//	device.Channel = 22;

	//	Remote remote = new AdvancedRemote(device);
	//	remote.ChannnelUp();
	//	remote.VolumeDown();

	//	Console.WriteLine(device);


	//	device = new TV();
	//	device.Volume = 30;
	//	device.Channel = 45;

	//	remote = new AdvancedRemote(device);
	//	remote.TogglePower();
	//	remote.VolumeUp();
	//	remote.ChannnelUp();

	//	Console.WriteLine();
	//	Console.WriteLine(device);
	//}
}
