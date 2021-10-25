using System.Collections;
using UnityEngine;
using UnityEngine.Playables;
using Fungus;

namespace FungusExtensions.Playables
{
	[CommandInfo("Timeline",
				 "Play Timeline",
				 "Play timeline.")]
	[AddComponentMenu("")]
	public class PlayTimeline : Command
	{
		[Tooltip("Playable Director")]
		[SerializeField] protected PlayableDirectorData playableDirector = new PlayableDirectorData();

		[Tooltip("Wait Until Finished")]
		[SerializeField] protected BooleanData waitUntilFinished = new BooleanData(true);

		#region Public members

		public override void OnEnter()
		{
			if (playableDirector.Value == null)
			{
				Continue();
				return;
			}

			playableDirector.Value.Play();
			if (waitUntilFinished.Value)
			{
				StartCoroutine(WaitTimeline());
			}
			else
			{
				Continue();
			}
		}

		private IEnumerator WaitTimeline()
		{
			while (playableDirector.Value.state == PlayState.Playing) yield return null;
			Continue();
		}

		public override string GetSummary()
		{
			if (playableDirector.Value == null)
			{
				return "Error: No PlayableDirector selected";
			}
			return playableDirector.Value.name;
		}

		public override Color GetButtonColor()
		{
			return new Color32(235, 191, 217, 255);
		}

		public override bool HasReference(Variable variable)
		{
			return base.HasReference(variable) ||
				(playableDirector.playableDirectorRef == variable) ||
				(waitUntilFinished.booleanRef == variable);
		}

		#endregion
	}
}