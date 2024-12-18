using MelonLoader;
using UnityEngine;
using Il2CppInterop;
using Il2CppInterop.Runtime.Injection; 
using System.Collections;
using MelonLoader.Utils;

namespace Milestones
{
	
	public class MilestonesMod : MelonMod
	{
		public static string MilestonesDir = $"{MelonEnvironment.ModsDirectory}/milestones";

        public override void OnInitializeMelon()
		{           
			if(!Directory.Exists(MilestonesDir))
			{
				Directory.CreateDirectory(MilestonesDir);
			}
			else
			{

			}
        }

		public override void OnSceneWasLoaded(int buildIndex, string sceneName)
		{
			
        }

        public override void OnUpdate()
		{

		}
    }
}