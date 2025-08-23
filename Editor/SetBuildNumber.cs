
using UcbEnvironment.Editor;
using UnityEditor;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;
using UnityEngine;


namespace UcbBuildNumber.Editor
{
    internal sealed class SetBuildNumber : IPreprocessBuildWithReport
    {
        public int callbackOrder => -1000;

        public void OnPreprocessBuild(BuildReport report)
        {
            if (bool.TryParse(
                    UnityCloudBuildEnvironment.IsBuilder,
                    out var isBuilder)
                && isBuilder)
            {
                SetUcbBuildNumber();
            }
        }

        private void SetUcbBuildNumber()
        {
            if (!int.TryParse(
                    UnityCloudBuildEnvironment.UcbBuildNumber,
                    out var ucbBuildNumber))
            {
                Debug.LogError(
                    "Building with UCB, but UCB build number " +
                    "could not be parsed.");

                return;
            }

            PlayerSettings.iOS.buildNumber = ucbBuildNumber.ToString();
            PlayerSettings.Android.bundleVersionCode = ucbBuildNumber;
        }
    }
}
