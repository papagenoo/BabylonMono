using System;

namespace Babylon.UI
{
	public abstract class ManualState : State
	{
		public override void EnterState (StateMachine context)
		{
			context.EnterManualMode ();
		}

		public override void HandleEnterManualModeEvent (StateMachine context)
		{
			// Empty default implementation
		}

		public override void HandleTimeoutEvent (StateMachine stateMachine)
		{
			// Empty default implementation
		}
	}
}