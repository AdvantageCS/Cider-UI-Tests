set testroot=%~dp0test
git pull
call dnvm use default
pushd "%testroot%\2015.9" && dnx test && popd
pushd "%testroot%\2015.10" && dnx test && popd
pause
