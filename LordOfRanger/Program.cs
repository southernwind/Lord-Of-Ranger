﻿using System;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace LordOfRanger {
	static class Program {
		/// <summary>
		/// アプリケーションのメイン エントリ ポイントです。
		/// </summary>
		[STAThread]
		private static void Main() {
			if( Properties.Settings.Default.newFileFlag ) {
				Properties.Settings.Default.Upgrade();
				Properties.Settings.Default.newFileFlag = true;
				Properties.Settings.Default.Save();
			}

			// 多重起動対策 
			using( var mutex = new System.Threading.Mutex( false, Application.ProductName ) ) {
				if( mutex.WaitOne( 0, false ) ) {
					Application.EnableVisualStyles();
					Application.SetCompatibleTextRenderingDefault( false );
					var mainForm = new MainForm();
					if( (Options.StartupState)Properties.Settings.Default.startupState == Options.StartupState.NORMAL ) {
						Application.Run( mainForm );
					} else {
						Application.Run();
					}
				} else {
					var hThisProcess = Process.GetCurrentProcess();
					var hProcesses = Process.GetProcessesByName( hThisProcess.ProcessName );
					var iThisProcessId = hThisProcess.Id;

					foreach( var hProcess in hProcesses.Where( hProcess => hProcess.Id != iThisProcessId ) ) {
						Win32.Window.ShowWindow( hProcess.MainWindowHandle, Win32.Window.SW_NORMAL );
						Win32.Window.SetForegroundWindow( hProcess.MainWindowHandle );
						break;
					}
					MessageBox.Show( "既にLordOfRangerが起動されています。" );
				}
			}
		}
	}
}
