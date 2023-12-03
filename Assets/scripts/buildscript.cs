using UnityEditor;

public class BuildScript
{
    public static void BuildGame()

    {
        BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions();
        buildPlayerOptions.scenes = new[] { "Assets/Scenes/MainScene.unity" };
        buildPlayerOptions.locationPathName = "builds/wordle.exe";
        buildPlayerOptions.target = BuildTarget.StandaloneWindows64; 
        buildPlayerOptions.options = BuildOptions.None;

        BuildPipeline.BuildPlayer(buildPlayerOptions);
        
    }
}