#define MyAppName "CEPIMA"
#define MyAppVersion "1.0.0"
#define MyAppPublisher "CEPIMA"
#define MyAppExeName "Cepima.exe"

[Setup]

; =========================================================
; INFORMATIONS APPLICATION
; =========================================================

AppId={{CEPIMA-SOFTWARE-2026}}

AppName={#MyAppName}
AppVersion={#MyAppVersion}
AppPublisher={#MyAppPublisher}

DefaultDirName={pf}\CEPIMA_SOFTWARE

OutputDir=.\Output
OutputBaseFilename=CEPIMA-Setup-{#MyAppVersion}

Compression=lzma
SolidCompression=yes

PrivilegesRequired=admin

Uninstallable=yes
CreateUninstallRegKey=yes

; =========================================================
; ICONE DE L'INSTALLATEUR
; =========================================================

SetupIconFile=D:\2026\CEPIMA\cepima_desktop\AFW\composant\cepima.ico


[Files]

; =========================================================
; CEPIMA
; =========================================================

Source: "D:\2026\CEPIMA\cepima_desktop\AFW\Cepima\Cepima\bin\Release\*"; \
    DestDir: "{app}"; \
    Flags: ignoreversion recursesubdirs createallsubdirs


; =========================================================
; ICONE
; =========================================================

Source: "D:\2026\CEPIMA\cepima_desktop\AFW\composant\cepima.ico"; \
    DestDir: "{app}"; \
    Flags: ignoreversion


; =========================================================
; VISUAL C++ REDISTRIBUTABLES
; =========================================================

Source: "D:\2026\CEPIMA\cepima_desktop\AFW\composant\vcredist_x64-12.exe"; \
    DestDir: "{tmp}"; \
    Flags: deleteafterinstall

Source: "D:\2026\CEPIMA\cepima_desktop\AFW\composant\vcredist_x86-12.exe"; \
    DestDir: "{tmp}"; \
    Flags: deleteafterinstall

Source: "D:\2026\CEPIMA\cepima_desktop\AFW\composant\vcredist_x64-10.exe"; \
    DestDir: "{tmp}"; \
    Flags: deleteafterinstall

Source: "D:\2026\CEPIMA\cepima_desktop\AFW\composant\vcredist_x86-10.exe"; \
    DestDir: "{tmp}"; \
    Flags: deleteafterinstall


[Run]

; =========================================================
; VISUAL C++ 2013
; =========================================================

Filename: "{tmp}\vcredist_x64-12.exe"; \
    Parameters: "/quiet /norestart"; \
    Flags: waituntilterminated

Filename: "{tmp}\vcredist_x86-12.exe"; \
    Parameters: "/quiet /norestart"; \
    Flags: waituntilterminated


; =========================================================
; VISUAL C++ 2010
; =========================================================

Filename: "{tmp}\vcredist_x64-10.exe"; \
    Parameters: "/quiet /norestart"; \
    Flags: waituntilterminated

Filename: "{tmp}\vcredist_x86-10.exe"; \
    Parameters: "/quiet /norestart"; \
    Flags: waituntilterminated


; =========================================================
; LANCER CEPIMA APRES INSTALLATION
; =========================================================

Filename: "{app}\Cepima.exe"; \
    Description: "Lancer CEPIMA"; \
    Flags: postinstall nowait


[Icons]

; =========================================================
; RACCOURCI BUREAU
; =========================================================

Name: "{commondesktop}\CEPIMA"; \
    Filename: "{app}\Cepima.exe"; \
    WorkingDir: "{app}"; \
    IconFilename: "{app}\cepima.ico"; \
    Comment: "Lancer CEPIMA"


; =========================================================
; MENU DEMARRER
; =========================================================

Name: "{group}\CEPIMA"; \
    Filename: "{app}\Cepima.exe"; \
    WorkingDir: "{app}"; \
    IconFilename: "{app}\cepima.ico"; \
    Comment: "Lancer CEPIMA"