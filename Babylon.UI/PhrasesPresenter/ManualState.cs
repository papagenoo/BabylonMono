using System;

namespace Babylon.UI
{
	public abstract class ManualState : State
	{
		public override void ExitAutoMode (StateMachine context)
		{
			throw new InvalidStateTransitionException ();
		}
	}
}