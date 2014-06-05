using System;

namespace Babylon.UI
{
	public class AwaitingInManualState : ManualState
	{
		#region implemented abstract members of State

		public override void MovePrevious (StateMachine context)
		{
			context.SetPlayingInManualState ();
			context.DoMovePrevious ();
			context.DoPlaySoundStart ();
		}

		public override void MoveNext (StateMachine context)
		{
			context.SetPlayingInManualState ();
			context.DoMoveNext ();
			context.DoPlaySoundStart ();
		}

		public override void PlaySoundStart (StateMachine context)
		{
			context.SetPlayingInManualState ();
			context.DoPlaySoundStart ();
		}

		public override void PlaySoundStop (StateMachine context)
		{
			throw new InvalidStateTransitionException ();
		}

		public override void EnterAutoMode (StateMachine context)
		{
			context.SetAwaitingInAutoState ();
			context.DoEnterAutoMode ();
		}

		#endregion		
	}
}