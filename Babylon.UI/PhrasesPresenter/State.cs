using System;

namespace Babylon.UI
{
	public abstract class State
	{
		public virtual void EnterState ()
		{
			// Empty default implementation
		}

		public virtual void ExitState ()
		{
			// Empty default implementation
		}

		public abstract void MovePrevious (StateMachine context);
		public abstract void MoveNext (StateMachine context);
		public abstract void PlaySoundStart (StateMachine context);
		public abstract void PlaySoundStop (StateMachine context);
		public abstract void EnterAutoMode (StateMachine context);
		public abstract void EnterManualMode (StateMachine context);
	}
}