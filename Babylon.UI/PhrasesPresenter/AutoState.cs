using System;

namespace Babylon.UI
{
	public abstract class AutoState : State
	{
		public override void EnterState (StateMachine context)
		{
			context.EnterAutoMode ();
		}

		public override void HandleEnterAutoModeEvent (StateMachine context)
		{
			// Empty default implementation
		}
	}
}