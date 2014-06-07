using System;
using System.Threading;

namespace Babylon
{
	public class DelayedAction
	{
		Timer timer;

		public DelayedAction (Action action, int timeout)
		{
			timer = new Timer ((o) => {
				action.Invoke ();
				timer.Dispose();
			}, null, 0, timeout); 
		}
	}
}