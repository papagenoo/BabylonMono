using System;

namespace Babylon.Test
{
	/// <summary>
	/// Реализация Logger
	/// </summary>
	public class LoggerIml : Logger
	{
		protected override void Log (string str)
		{
			Console.WriteLine(str);
		}
	}
}