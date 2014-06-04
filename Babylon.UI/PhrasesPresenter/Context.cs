using System;

namespace Babylon.UI
{
	public class PhrasesPresenter_Context : PhrasesPresenter_Actions
	{
		PhrasesPresenter_State state;

		public PhrasesPresenter_Context (PhrasesPresenter initialState)
		{
			state = initialState;
		}

		#region PhrasesPresenter_Actions implementation
		public void MoveNext ()
		{
			state.MoveNext ();
		}
		public void MovePrevious ()
		{
			state.MovePrevious ();
		}
		public void PlaySound ()
		{
			state.PlaySound ();
		}
		public void EnterAutoMode ()
		{
			state.EnterAutoMode ();
		}
		public void ExitAutoMode ()
		{
			state.ExitAutoMode ();
		}
		#endregion
	}
}