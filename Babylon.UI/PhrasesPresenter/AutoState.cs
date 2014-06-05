using System;

namespace Babylon.UI
{
	public abstract class AutoState : State
	{
		public override void EnterAutoMode (StateMachine context)
		{
			throw new InvalidStateTransitionException ();
		}
	}
}