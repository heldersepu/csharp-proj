!define PRODUCT_NAME "BCReader"
!define PRODUCT_VERSION "1.3.1.0"
!define PRODUCT_WEB_SITE "http://www.pizzamenus.com/"
!include nsDialogs.nsh

Name "${PRODUCT_NAME}"
OutFile "${PRODUCT_NAME}-${PRODUCT_VERSION}.exe"
SetCompressor /FINAL /SOLID lzma
SetCompressorDictSize 32

; The default installation directory
InstallDir "C:\${PRODUCT_NAME}"
InstallDirRegKey HKLM "Software\${PRODUCT_NAME}" "Install_Dir"
RequestExecutionLevel admin

;--------------------------------
;Version Information
VIProductVersion "${PRODUCT_VERSION}"
VIAddVersionKey "ProductName" "${PRODUCT_NAME}"
VIAddVersionKey "Comments" "Read BigCommerce API for new orders."
VIAddVersionKey "LegalCopyright" "${PRODUCT_WEB_SITE}"
VIAddVersionKey "FileDescription" "Read BigCommerce API for new orders."
VIAddVersionKey "FileVersion" "${PRODUCT_VERSION}"

;--------------------------------
; Pages
Page components
Page instfiles

UninstPage uninstConfirm
UninstPage instfiles

ShowInstDetails show
ShowUninstDetails show

Function .onInstSuccess
    Exec "$INSTDIR\${PRODUCT_NAME}.exe"
FunctionEnd

;--------------------------------
; The stuff to install
Section "${PRODUCT_NAME} (required)"
    SectionIn RO
    SetOutPath $INSTDIR

    ; Put files here
    File /r "C:\${PRODUCT_NAME}\${PRODUCT_NAME}.exe"
    File /r "C:\${PRODUCT_NAME}\*.xml"
    File /r "C:\${PRODUCT_NAME}\*.dll"
    File /r "C:\${PRODUCT_NAME}\*.nsi"

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
    CreateShortCut "$SMPROGRAMS\${PRODUCT_NAME}\${PRODUCT_NAME}.lnk" "$INSTDIR\${PRODUCT_NAME}.exe"
    CreateShortCut "$SMPROGRAMS\${PRODUCT_NAME}\Uninstall ${PRODUCT_NAME}.lnk" "$INSTDIR\uninstall.exe"
    ; Create a shortcut to the project Homepage
    WriteIniStr "$INSTDIR\${PRODUCT_NAME}.url" "InternetShortcut" "URL" "${PRODUCT_WEB_SITE}"
    CreateShortCut "$SMPROGRAMS\${PRODUCT_NAME}\${PRODUCT_NAME} Website.lnk" "$INSTDIR\${PRODUCT_NAME}.url"
    ; Create a shortcut to the .net page (easier to install framework)
    WriteIniStr "$INSTDIR\netms.url" "InternetShortcut" "URL" "http://www.microsoft.com/net"
    CreateShortCut "$SMPROGRAMS\${PRODUCT_NAME}\Microsoft .NET.lnk" "$INSTDIR\netms.url"
    ; Create a shortcut to the installation folder
    CreateShortCut "$SMPROGRAMS\${PRODUCT_NAME}\Stores.lnk" "$INSTDIR\Stores"
SectionEnd

;--------------------------------
; Uninstaller
Section "Uninstall"
    ; Remove registry keys
    DeleteRegKey HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\${PRODUCT_NAME}"
    DeleteRegKey HKLM "SOFTWARE\${PRODUCT_NAME}"

    ; Remove directories used
    RMDir /r "$SMPROGRAMS\${PRODUCT_NAME}"
    RMDir /r "$INSTDIR"
SectionEnd
