using System;

namespace Babylon
{
	public class Phrase
	{
		public Phrase(string text, string audioFileName)
		{
			Text = text;
			AudioFileName = audioFileName;
		}

		public string Text { get; private set; }

		public string AudioFileName { get; private set; }
	}
}

