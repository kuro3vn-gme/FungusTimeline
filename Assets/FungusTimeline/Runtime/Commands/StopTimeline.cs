using UnityEngine;
using Fungus;

namespace FungusExtensions.Playables
{
	[CommandInfo("Timeline",
				 "Stop Timeline",
				 "Stop timeline.")]
	[AddComponentMenu("")]
	public class StopTimeline : Command
	{
		[Tooltip("Playable Director")]
		[SerializeField] protected PlayableDirectorData playableDirector = new PlayableDirectorData();

		#region Public members

		public override void OnEnter()
		{
			if (playableDirector.Value == null)
			{
				Continue();
				return;
			}

			playableDirector.Value.Stop();
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
				(playableDirector.playableDirectorRef == variable);
		}

		#endregion
	}
}