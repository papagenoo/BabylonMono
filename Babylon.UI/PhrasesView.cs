using System;

namespace Babylon.UI
{
	public interface PhrasesView
	{
		string LectionTitle { set; }
		string Text { set; }
		string Translation { set; }
		void DisableManualModeButton ();
		void EnableManualModeButton ();
		void DisableAutoModeButton ();
		void EnableAutoModeButton ();

		void EnableNextButton ();
		void DisableNextButton ();
		void EnablePreviousButton ();
		void DisablePreviousButton ();
	}
}