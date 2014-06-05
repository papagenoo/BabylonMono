using System;

namespace Babylon.UI
{
	public abstract class State
	{
		#region Events implementation

		public abstract void MovePrevious (StateMachine context);
		public abstract void MoveNext (StateMachine context);
		public abstract void PlaySoundStart (StateMachine context);
		public abstract void PlaySoundStop (StateMachine context);
		public abstract void EnterAutoMode (StateMachine context);
		public abstract void ExitAutoMode (StateMachine context);

		#endregion
	}
}