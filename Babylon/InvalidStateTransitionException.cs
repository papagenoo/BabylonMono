using System;

namespace Babylon
{
	/// <summary>
	/// Throws when rases illegal event in the State Machine
	/// </summary>
	public class InvalidStateTransitionException : InvalidOperationException
	{
		public InvalidStateTransitionException ()
			: base ("Invalid state transition") 
		{

		}
	}
}