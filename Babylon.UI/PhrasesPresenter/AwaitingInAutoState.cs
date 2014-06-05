using System;

namespace Babylon.UI
{
	public class AwaitingInAutoState : AutoState
	{
		#region implemented abstract members of State

		public override void MovePrevious (StateMachine context)
		{
			context.SetPlayingInAutoState ();
			context.DoMovePrevious ();
			context.DoPlaySoundStart ();
		}

		public override void MoveNext (StateMachine context)
		{
			context.SetPlayingInAutoState ();
			context.DoMoveNext ();
			context.DoPlaySoundStart ();
			//context.ResetTimer ();
		}

		public override void PlaySoundStart (StateMachine context)
		{
			context.SetPlayingInAutoState ();
			context.DoPlaySoundStart ();		
		}

		public override void PlaySoundStop (StateMachine context)
		{
			throw new InvalidStateTransitionException ();
		}

		public override void EnterAutoMode (StateMachine context)
		{
			throw new InvalidStateTransitionException ();
		}

		public override void ExitAutoMode (StateMachine context)
		{

		}

		#endregion
		
	}
}