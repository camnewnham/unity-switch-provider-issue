using UnityEditor;
using UnityEditor.XR.Management;
using UnityEditor.XR.Management.Metadata;
using UnityEngine.XR.Management;

public class SwitchXRPlugin
{

    [MenuItem("TEST/Enable OpenXR")]
    public static void EnableOpenXR()
    {
        SetPackage((typeof(UnityEngine.XR.OpenXR.OpenXRLoader)).FullName, true);

    }
    [MenuItem("TEST/Disable OpenXR")]
    public static void DisableOpenXR()
    {
        SetPackage((typeof(UnityEngine.XR.OpenXR.OpenXRLoader)).FullName, false);

    }
    [MenuItem("TEST/Enable ARCore")]
    public static void EnableARCore()
    {
        SetPackage((typeof(UnityEngine.XR.ARCore.ARCoreLoader)).FullName, true);
    }
    [MenuItem("TEST/Disable ARCore")]
    public static void DisableARCore()
    {
        SetPackage((typeof(UnityEngine.XR.ARCore.ARCoreLoader)).FullName, false);
    }

    public static void SetPackage(string fullName, bool enabled)
    {
        EditorBuildSettings.TryGetConfigObject(XRGeneralSettings.k_SettingsKey, out XRGeneralSettingsPerBuildTarget buildTargetSettings);
        XRGeneralSettings settings = buildTargetSettings.SettingsForBuildTarget(BuildTargetGroup.Android);

        if (enabled)
        {
            XRPackageMetadataStore.AssignLoader(settings.Manager, fullName, BuildTargetGroup.Android);
        }
        else
        {
            XRPackageMetadataStore.RemoveLoader(settings.Manager, fullName, BuildTargetGroup.Android);
        }
    }
}
