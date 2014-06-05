using System;
using NUnit.Framework;
using Babylon.UI;
using System.Threading;

namespace Babylon.Test
{
	public class StateMachine_AwaitingInManual_Test
	{
		class PhrasesPresenterMock : PhrasesPresenter
		{

			public int MoveNextCounter = 0;
			public int MovePreviousCounter = 0;
			public int PlaySoundStartCounter = 0;
			public int PlaySoundStopCounter = 0;
			public int EnterAutoModeCounter = 0;
			public int EnterManualModeCounter = 0;

			public void MoveNext ()
			{
				MoveNextCounter++;
			}

			public void MovePrevious ()
			{
				MovePreviousCounter++;
			}

			public void PlaySoundStart ()
			{
				PlaySoundStartCounter++;
			}

			public void PlaySoundStop ()
			{
				PlaySoundStopCounter++;
			}

			public void EnterAutoMode ()
			{
				EnterAutoModeCounter++;
			}

			public void EnterManualMode ()
			{
				EnterManualModeCounter++;
			}

			public void DelayAndRaseNextEvent ()
			{
				throw new NotImplementedException ();
			}


			#region PhrasesPresenter implementation
			public void HandleNextEvent ()
			{
				throw new NotImplementedException ();
			}
			public void HandlePreviousEvent ()
			{
				throw new NotImplementedException ();
			}
			public void HandlePlaySoundStartEvent ()
			{
				throw new NotImplementedException ();
			}
			public void HandlePlaySoundStopEvent ()
			{
				throw new NotImplementedException ();
			}
			public void HandleEnterAutoModeEvent ()
			{
				throw new NotImplementedException ();
			}
			public void HandleEnterManualModeEvent ()
			{
				throw new NotImplementedException ();
			}
			#endregion
		}

		PhrasesPresenterMock presenter;
		StateMachine stateMachine;

		[TestFixtureSetUp ()]
		public void SetUpOnce ()
		{
			Logger.Instance = new LoggerIml ();
		}

		[SetUp ()]
		public void SetUpEach ()
		{
			presenter = new PhrasesPresenterMock ();
			stateMachine = new StateMachine (presenter);
		}

		bool IsAwaitingInAutoState ()
		{
			return stateMachine.State == AwaitingInAutoState.Instance;
		}

		bool IsAwaitingInManualState ()
		{
			return stateMachine.State == AwaitingInManualState.Instance;
		}

		bool IsPlayingInAutoState ()
		{
			return stateMachine.State == PlayingInAutoState.Instance;
		}

		bool IsPlayingInManualState ()
		{
			return stateMachine.State == PlayingInManualState.Instance;
		}


		//***********************************

		[Test ()]
		public void InitialStateTest()
		{
			Assert.AreNotSame(AwaitingInAutoState.Instance, stateMachine.State);
			Assert.AreSame(AwaitingInManualState.Instance, stateMachine.State);
			Assert.AreNotSame(PlayingInAutoState.Instance, stateMachine.State);
			Assert.AreNotSame(PlayingInManualState.Instance, stateMachine.State);
		}


		//***********************************

		[Test ()]
		public void SetAwaitingInAutoStateTest()
		{
			stateMachine.State = AwaitingInAutoState.Instance;
			Assert.IsTrue(IsAwaitingInAutoState ());
		}

		[Test ()]
		public void SetPlayingInAutoStateTest()
		{
			stateMachine.State = PlayingInAutoState.Instance;
			Assert.IsTrue(IsPlayingInAutoState ());
		}

		[Test ()]
		public void SetPlayingInManualStateTest()
		{
			stateMachine.State = PlayingInManualState.Instance;
			Assert.IsTrue(IsPlayingInManualState ());
		}


		//*** AwaitingInManual

		[Test ()]
		public void MoveNext_In_AwaitingInManualTest()
		{
			Assert.AreEqual (0, presenter.MoveNextCounter);
			Assert.AreEqual (0, presenter.PlaySoundStartCounter);
			stateMachine.RaseNextEvent ();
			Assert.AreEqual (1, presenter.MoveNextCounter);
			Assert.AreEqual (1, presenter.PlaySoundStartCounter);
			Assert.IsTrue(IsPlayingInManualState ());
		}

		[Test ()]
		public void MovePrevious_In_AwaitingInManualTest()
		{
			Assert.AreEqual (0, presenter.MovePreviousCounter);
			Assert.AreEqual (0, presenter.PlaySoundStartCounter);
			stateMachine.RasePreviousEvent ();
			Assert.AreEqual (1, presenter.MovePreviousCounter);
			Assert.AreEqual (1, presenter.PlaySoundStartCounter);
			Assert.IsTrue(IsPlayingInManualState ());
		}

		[Test ()]
		public void PlaySoundStart_In_AwaitingInManualTest()
		{
			Assert.AreEqual (0, presenter.PlaySoundStartCounter);
			stateMachine.RasePlaySoundStartEvent ();
			Assert.AreEqual (1, presenter.PlaySoundStartCounter);
			Assert.IsTrue(IsPlayingInManualState ());
		}

		[Test ()]
		[ExpectedException( typeof( InvalidStateTransitionException ) )]
		public void PlaySoundStop_In_AwaitingInManualTest()
		{
			stateMachine.RasePlaySoundStopEvent ();
		}

		[Test ()]
		public void EnterAutoMode_In_AwaitingInManualTest()
		{
			Assert.AreEqual (0, presenter.EnterAutoModeCounter);
			stateMachine.RaseEnterAutoModeEvent ();
			Assert.AreEqual (1, presenter.EnterAutoModeCounter);
			Assert.IsTrue(IsAwaitingInAutoState ());
		}

		[Test ()]
		public void EnterManualMode_In_AwaitingInManualTest()
		{
			Assert.AreEqual (0, presenter.EnterManualModeCounter);
			stateMachine.RaseEnterManualModeEvent ();
			Assert.AreEqual (0, presenter.EnterManualModeCounter);
			Assert.IsTrue(IsAwaitingInManualState ());
		}


		//*** PlayingInManual

		[Test ()]
		public void MoveNext_In_PlayingInManualTest()
		{
			stateMachine.State = PlayingInManualState.Instance;
			Assert.AreEqual (0, presenter.MoveNextCounter);
			Assert.AreEqual (0, presenter.PlaySoundStartCounter);
			stateMachine.RaseNextEvent ();
			Assert.AreEqual (1, presenter.MoveNextCounter);
			Assert.AreEqual (1, presenter.PlaySoundStartCounter);
			Assert.IsTrue(IsPlayingInManualState ());
		}

		[Test ()]
		public void MovePrevious_In_PlayingInManualTest()
		{
			stateMachine.State = PlayingInManualState.Instance;
			Assert.AreEqual (0, presenter.MovePreviousCounter);
			Assert.AreEqual (0, presenter.PlaySoundStartCounter);
			stateMachine.RasePreviousEvent ();
			Assert.AreEqual (1, presenter.MovePreviousCounter);
			Assert.AreEqual (1, presenter.PlaySoundStartCounter);
			Assert.IsTrue(IsPlayingInManualState ());
		}

		[Test ()]
		public void PlaySoundStart_In_PlayingInManualTest()
		{
			stateMachine.State = PlayingInManualState.Instance;
			Assert.AreEqual (0, presenter.PlaySoundStartCounter);
			stateMachine.RasePlaySoundStartEvent ();
			Assert.AreEqual (1, presenter.PlaySoundStartCounter);
			Assert.IsTrue(IsPlayingInManualState ());
		}

		[Test ()]
		public void PlaySoundStop_In_PlayingInManualTest()
		{
			stateMachine.State = PlayingInManualState.Instance;
			stateMachine.RasePlaySoundStopEvent ();
			Assert.IsTrue(IsAwaitingInManualState ());
		}

		[Test ()]
		public void EnterAutoMode_In_PlayingInManualTest()
		{
			stateMachine.State = PlayingInManualState.Instance;
			Assert.AreEqual (0, presenter.EnterAutoModeCounter);
			stateMachine.RaseEnterAutoModeEvent ();
			Assert.AreEqual (1, presenter.EnterAutoModeCounter);
			Assert.IsTrue(IsPlayingInAutoState ());
		}

		[Test ()]
		public void EnterManualMode_In_PlayingInManualTest()
		{
			stateMachine.State = PlayingInManualState.Instance;
			Assert.AreEqual (0, presenter.EnterManualModeCounter);
			stateMachine.RaseEnterManualModeEvent ();
			Assert.AreEqual (0, presenter.EnterManualModeCounter);
			Assert.IsTrue(IsPlayingInManualState ());
		}


		//*** AwaitingInAuto

		[Test ()]
		public void MoveNext_In_AwaitingInAutoTest()
		{
			stateMachine.State = AwaitingInAutoState.Instance;
			Assert.AreEqual (0, presenter.MoveNextCounter);
			Assert.AreEqual (0, presenter.PlaySoundStartCounter);
			stateMachine.RaseNextEvent ();
			Assert.AreEqual (1, presenter.MoveNextCounter);
			Assert.AreEqual (1, presenter.PlaySoundStartCounter);
			Assert.IsTrue(IsPlayingInAutoState ());
		}

		[Test ()]
		public void MovePrevious_In_AwaitingInAutoTest()
		{
			stateMachine.State = AwaitingInAutoState.Instance;
			Assert.AreEqual (0, presenter.MovePreviousCounter);
			Assert.AreEqual (0, presenter.PlaySoundStartCounter);
			stateMachine.RasePreviousEvent ();
			Assert.AreEqual (1, presenter.MovePreviousCounter);
			Assert.AreEqual (1, presenter.PlaySoundStartCounter);
			Assert.IsTrue(IsPlayingInAutoState ());
		}

		[Test ()]
		public void PlaySoundStart_In_AwaitingInAutoTest()
		{
			stateMachine.State = AwaitingInAutoState.Instance;
			Assert.AreEqual (0, presenter.PlaySoundStartCounter);
			stateMachine.RasePlaySoundStartEvent ();
			Assert.AreEqual (1, presenter.PlaySoundStartCounter);
			Assert.IsTrue(IsPlayingInAutoState ());
		}

		[Test ()]
		[ExpectedException( typeof( InvalidStateTransitionException ) )]
		public void PlaySoundStop_In_AwaitingInAutoTest()
		{
			stateMachine.State = AwaitingInAutoState.Instance;
			stateMachine.RasePlaySoundStopEvent ();
		}

		[Test ()]
		public void EnterAutoMode_In_AwaitingInAutoTest()
		{
			stateMachine.State = AwaitingInAutoState.Instance;
			Assert.AreEqual (0, presenter.EnterManualModeCounter);
			stateMachine.RaseEnterAutoModeEvent ();
			Assert.AreEqual (0, presenter.EnterManualModeCounter);
			Assert.IsTrue (IsAwaitingInAutoState ());
		}

		[Test ()]
		public void EnterManualMode_In_AwaitingInAutoTest()
		{
			stateMachine.State = AwaitingInAutoState.Instance;
			Assert.AreEqual (0, presenter.EnterManualModeCounter);
			stateMachine.RaseEnterManualModeEvent ();
			Assert.AreEqual (1, presenter.EnterManualModeCounter);
			Assert.IsTrue(IsAwaitingInManualState ());
		}


		//*** PlayingInAuto

		[Test ()]
		public void MoveNext_In_PlayingInAutoTest()
		{
			stateMachine.State = PlayingInAutoState.Instance;
			Assert.AreEqual (0, presenter.MoveNextCounter);
			Assert.AreEqual (0, presenter.PlaySoundStartCounter);
			stateMachine.RaseNextEvent ();
			Assert.AreEqual (1, presenter.MoveNextCounter);
			Assert.AreEqual (1, presenter.PlaySoundStartCounter);
			Assert.IsTrue(IsPlayingInAutoState ());
		}

		[Test ()]
		public void MovePrevious_In_PlayingInAutoTest()
		{
			stateMachine.State = PlayingInAutoState.Instance;
			Assert.AreEqual (0, presenter.MovePreviousCounter);
			Assert.AreEqual (0, presenter.PlaySoundStartCounter);
			stateMachine.RasePreviousEvent ();
			Assert.AreEqual (1, presenter.MovePreviousCounter);
			Assert.AreEqual (1, presenter.PlaySoundStartCounter);
			Assert.IsTrue(IsPlayingInAutoState ());
		}

		[Test ()]
		public void PlaySoundStart_In_PlayingInAutoTest()
		{
			stateMachine.State = PlayingInAutoState.Instance;
			Assert.AreEqual (0, presenter.PlaySoundStartCounter);
			stateMachine.RasePlaySoundStartEvent ();
			Assert.AreEqual (1, presenter.PlaySoundStartCounter);
			Assert.IsTrue(IsPlayingInAutoState ());
		}

		[Test ()]
		//[ExpectedException( typeof( InvalidStateTransitionException ) )]
		public void PlaySoundStop_In_PlayingInAutoTest()
		{
			stateMachine.State = PlayingInAutoState.Instance;
			stateMachine.RasePlaySoundStopEvent ();
			Assert.IsTrue(IsAwaitingInAutoState ());
		}

		[Test ()]
		public void EnterAutoMode_In_PlayingInAutoTest()
		{
			stateMachine.State = PlayingInAutoState.Instance;
			stateMachine.RaseEnterAutoModeEvent ();
			Assert.IsTrue(IsPlayingInAutoState ());
		}

		[Test ()]
		public void EnterManualMode_In_PlayingInAutoTest()
		{
			stateMachine.State = PlayingInAutoState.Instance;
			Assert.AreEqual (0, presenter.EnterManualModeCounter);
			stateMachine.RaseEnterManualModeEvent ();
			Assert.AreEqual (1, presenter.EnterManualModeCounter);
			Assert.IsTrue(IsPlayingInManualState ());
		}


	}
}

