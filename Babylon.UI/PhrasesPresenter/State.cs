using System;

namespace Babylon.UI
{
	public abstract class State
	{
		public virtual void EnterState (StateMachine context)
		{
			// Empty default implementation
		}

		public virtual void ExitState (StateMachine context)
		{
			// Empty default implementation
		}

		public abstract void HandlePreviousEvent (StateMachine context);
		public abstract void HandleNextEvent (StateMachine context);
		public abstract void HandlePlaySoundStartEvent (StateMachine context);
		public abstract void HandlePlaySoundStopEvent (StateMachine context);
		public abstract void HandleEnterAutoModeEvent (StateMachine context);
		public abstract void HandleEnterManualModeEvent (StateMachine context);
		public abstract void HandleTimeoutEvent (StateMachine stateMachine);
	}
}