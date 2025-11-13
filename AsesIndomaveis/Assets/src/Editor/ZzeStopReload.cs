using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Hypercasual.Editor
{
	/// <summary>
	/// Parar de compilar quando cria ou deleta um script
	/// </summary>
	public static class StopReload
	{
		// [MenuItem("Sklapps/Editor/Auto Refresh")]
		[MenuItem("Zze/Auto Refresh")]
        private static void AutoRefreshToggle()
        {
            var status = EditorPrefs.GetInt("kAutoRefresh");
 
            EditorPrefs.SetInt("kAutoRefresh", status == 1 ? 0 : 1);
        }
 
        //[MenuItem("Sklapps/Editor/Auto Refresh", true)]
		[MenuItem("Zze/Auto Refresh", true)]
        private static bool AutoRefreshToggleValidation()
        {
            var status = EditorPrefs.GetInt("kAutoRefresh");
 
            Menu.SetChecked("Sklapps/Editor/Auto Refresh", status == 1);
 
            return true;
        }
 
        //[MenuItem("Sklapps/Editor/Refresh %r")]
		[MenuItem("Zze/Refresh %r")]
        private static void Refresh()
        {
            Debug.Log("Request script reload.");
 
            EditorApplication.UnlockReloadAssemblies();
           
            AssetDatabase.Refresh();
 
            EditorUtility.RequestScriptReload();
        }
 
        [InitializeOnLoadMethod]
        private static void Initialize()
        {
            Debug.Log("Script realoded!");
           
            AssetDatabase.SaveAssets();
 
		// Zzê EditorApplication.LockReloadAssemblies();
        }
		
		// Eu criei um botão para desbloquear quando necessário
		//[MenuItem("Sklapps/Editor/Desbloquear Reload %e")]
		[MenuItem("Zze/Desbloquear Reload %e")]
		private static void UnlockReload()
		{
			EditorApplication.UnlockReloadAssemblies();
			// AssetDatabase.Refresh();
			AssetDatabase.SaveAssets();
			Debug.Log("Reload Desbloqueado");
		}
		
		//[MenuItem("Sklapps/Editor/Bloquear Reload %q")]
		[MenuItem("Zze/Bloquear Reload %q")]
		private static void UnlockReloadA()
		{
			EditorApplication.LockReloadAssemblies();
			// AssetDatabase.Refresh();
			AssetDatabase.SaveAssets();
			Debug.Log("Reload Bloqueado");
		}
	}
}
