REM You must first manually install dnx beta 8 from:
REM   http://www.microsoft.com/en-us/download/details.aspx?id=49442
REM The files to download and install are:
REM   * DotNetVersionManager-x64.msi
REM   * WebToolsExtensionsVS14.msi
REM Once the manual steps are complete, run this script "as Administrator"

set testroot=%~dp0test
set utilroot=%~dp0utils
copy /y %utilroot%\chromedriver.exe %windir%\
call dnvm setup
call dnvm upgrade
pushd "%testroot%\2015.9" && call dnu restore && popd
pushd "%testroot%\2015.10" && call dnu restore && popd
pause
