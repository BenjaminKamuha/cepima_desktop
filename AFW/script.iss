[Setup]
AppName=AppSchool
AppVersion=1.0
DefaultDirName={pf}\School_Management
OutputDir=.\Output
OutputBaseFilename=Gestion_Scolaire
Compression=lzma
SolidCompression=yes
SetupIconFile=Composants\icone.ico

[Files]
Source: "F:\GestionEcole\Gestion_ecole\Gestion_ecole\bin\Release\Gestion_ecole.exe"; DestDir: "{app}";
Source: "F:\GestionEcole\Gestion_ecole\Gestion_ecole\bin\Release\Microsoft.ReportViewer.Common.dll"; DestDir: "{app}";
Source: "F:\GestionEcole\Gestion_ecole\Gestion_ecole\bin\Release\Microsoft.ReportViewer.WinForms.DLL"; DestDir: "{app}";
Source: "F:\GestionEcole\Gestion_ecole\Gestion_ecole\bin\Release\Microsoft.ReportViewer.ProcessingObjectModel.DLL"; DestDir: "{app}";
Source: "F:\GestionEcole\Gestion_ecole\Gestion_ecole\bin\Release\Microsoft.SqlServer.Types.dll"; DestDir: "{app}";
Source: "F:\Projet_2025\Deployement\composant\vcredist_x64-12.exe"; DestDir: "{tmp}"; Flags: deleteafterinstall
Source: "F:\Projet_2025\Deployement\composant\vcredist_x86-12.exe"; DestDir: "{tmp}"; Flags: deleteafterinstall
Source: "F:\Projet_2025\Deployement\composant\vcredist_x64-10.exe"; DestDir: "{tmp}"; Flags: deleteafterinstall
Source: "F:\Projet_2025\Deployement\composant\vcredist_x86-10.exe"; DestDir: "{tmp}"; Flags: deleteafterinstall
Source: "F:\Projet_2025\Deployement\composant\Wampserver2.4-x64.exe"; DestDir: "{tmp}"; Flags: deleteafterinstall 
Source: "F:\Projet_2025\Deployement\composant\init_db_file.bat"; DestDir: "{app}"; Flags: deleteafterinstall
Source: "F:\Projet_2025\Deployement\composant\init_ecole.sql"; DestDir: "{app}"; Flags: deleteafterinstall    
Source: "F:\Projet_2025\Deployement\composant\mysql-connector-net-6.6.5.msi"; DestDir: "{tmp}"; Flags: deleteafterinstall
Source: "F:\Projet_2025\Deployement\composant\icone.ico"; DestDir: "{app}";
Source: "F:\GestionEcole\Gestion_ecole\Gestion_ecole\App.config"; DestDir: "{app}";

[Run]
Filename: "{tmp}\vcredist_x64-12.exe"; Parameters: "/quiet /norestart"; Flags: waituntilterminated
Filename: "{tmp}\vcredist_x86-12.exe"; Parameters: "/quiet /norestart"; Flags: waituntilterminated
Filename: "{tmp}\vcredist_x64-10.exe"; Parameters: "/quiet /norestart"; Flags: waituntilterminated
Filename: "{tmp}\vcredist_x86-10.exe"; Parameters: "/quiet /norestart"; Flags: waituntilterminated
Filename: "{tmp}\Wampserver2.4-x64.exe"; Parameters: "/VERYSILENT /SUPPRESSMSGBOXES /NORESTART /SP-"; Flags: waituntilterminated

Filename: "{cmd}"; Parameters: "/C timeout /T 5 /NOBREAK"; Flags: runhidden
Filename: "c:\wamp\bin\mysql\mysql5.6.12\bin\mysqld.exe"; Parameters: "--install wampmysqld"; Flags: waituntilterminated
Filename: "{cmd}"; Parameters: "/C sc config wampmysqld start= auto"; Flags: runhidden
Filename: "{cmd}"; Parameters: "/C net start wampmysqld"; Flags: runhidden waituntilterminated
Filename: "{app}\init_db_file.bat"; Flags: runhidden waituntilterminated
Filename: "msiexec"; Parameters: "/i ""{tmp}\mysql-connector-net-6.6.5.msi"" /qn /norestart"; Description: "Installation du connecteur mysql"; Flags: waituntilterminated
Filename: "{app}\Gestion_ecole.exe"; Flags: postinstall

[Icons]
Name:"{commondesktop}\Gestion_ecole"; Filename: "{app}\Gestion_ecole.exe"; WorkingDir: "{app}"; Comment: "Lancer Gestion_Ecole"; IconFilename: "{app}\icone.ico";