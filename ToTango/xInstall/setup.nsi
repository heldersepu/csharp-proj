!define PRODUCT_NAME "ToTangoXport"
!define PRODUCT_VERSION "1.0.0.6"
!include nsDialogs.nsh

; The name of the installer
Name "${PRODUCT_NAME}"
OutFile "${PRODUCT_NAME}-${PRODUCT_VERSION}.exe"

; Set the compression algorithm
SetCompressor /FINAL /SOLID lzma
SetCompressorDictSize 32

InstallDir "$PROGRAMFILES\${PRODUCT_NAME}"
InstallDirRegKey HKLM "Software\${PRODUCT_NAME}" "Install_Dir"
RequestExecutionLevel admin

;--------------------------------
;Version Information
VIProductVersion "${PRODUCT_VERSION}"
VIAddVersionKey "ProductName" "${PRODUCT_NAME}"
VIAddVersionKey "Comments" ""
VIAddVersionKey "LegalCopyright" ""
VIAddVersionKey "FileDescription" ""
VIAddVersionKey "FileVersion" "${PRODUCT_VERSION}"

;--------------------------------
; Pages
Page components
Page directory
Page instfiles

UninstPage uninstConfirm
UninstPage instfiles

ShowInstDetails show
ShowUninstDetails show

Function .onInstSuccess
	Exec "$INSTDIR\ToTangoXport.exe"
FunctionEnd

;--------------------------------
; The stuff to install
Section "${PRODUCT_NAME} (required)"
    SetAutoClose true
    SectionIn RO
    SetOutPath $INSTDIR

    ; Put files here
    File /r "ToTangoXport\ToTangoXport\bin\Debug\*.*"

    ; Write the installation path into the registry
    WriteRegStr HKLM "SOFTWARE\${PRODUCT_NAME}" "Install_Dir" "$INSTDIR"

    ; Write the uninstall keys for Windows
    WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\${PRODUCT_NAME}" "DisplayName" "${PRODUCT_NAME}"
    WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\${PRODUCT_NAME}" "UninstallString" '"$INSTDIR\uninstall.exe"'
    WriteRegDWORD HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\${PRODUCT_NAME}" "NoModify" 1
    WriteRegDWORD HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\${PRODUCT_NAME}" "NoRepair" 1
    WriteUninstaller "uninstall.exe"
SectionEnd

; Optional Shortcuts sections (can be disabled by the user)
Section "Start Menu Shortcuts"
    CreateDirectory "$SMPROGRAMS\${PRODUCT_NAME}"
    CreateShortCut "$SMPROGRAMS\${PRODUCT_NAME}\${PRODUCT_NAME}.lnk" "$INSTDIR\ToTangoXport.exe"
    CreateShortCut "$SMPROGRAMS\${PRODUCT_NAME}\Uninstall ${PRODUCT_NAME}.lnk" "$INSTDIR\uninstall.exe"
SectionEnd

Section "Desktop Shortcut"
    CreateShortCut "$DESKTOP\${PRODUCT_NAME}.lnk" "$INSTDIR\ToTangoXport.exe"
SectionEnd

Section "Quick Launch Shortcut"
    CreateShortCut "$QUICKLAUNCH\${PRODUCT_NAME}.lnk" "$INSTDIR\ToTangoXport.exe"
SectionEnd

;--------------------------------
; Uninstaller
Section "Uninstall"
    SetAutoClose true
    ; Remove registry keys
    DeleteRegKey HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\${PRODUCT_NAME}"
    DeleteRegKey HKLM "SOFTWARE\${PRODUCT_NAME}"

    ; Remove directories used
    RMDir /r "$SMPROGRAMS\${PRODUCT_NAME}"
    RMDir /r "$INSTDIR"

    ; Delete Shortcuts
    Delete "$DESKTOP\${PRODUCT_NAME}.lnk"
    Delete "$QUICKLAUNCH\${PRODUCT_NAME}.lnk"
SectionEnd
