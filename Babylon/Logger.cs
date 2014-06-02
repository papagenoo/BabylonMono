using System;

namespace Babylon
{
	/// <summary>
	/// Абстрактный класс логгера
	/// Должен быть реализован во всех не-pcl проектах
	/// </summary>
	public abstract class Logger
	{
		public static Logger Instance {
			get; set;
		}

		protected abstract void Log (string str);

		public static void Write(string str)
		{
			if (Instance != null) {
				Instance.Log (str);
			}
		}
	}
}