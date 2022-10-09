@ECHO OFF
ECHO Demo Automation Executed Started.


//set testcategory= ForLogin_Bat


set dllpath=C:\Users\kc\source\repos\PriceOye\PriceOye\bin\Debug\PriceOye.dll
set trxerpath=C:\Users\kc\source\repos\PriceOye\PriceOye\bin\Debug\
set SummaryReportPath=C:\Users\kc\source\repos\PriceOye\PriceOye\TestSummary\



call "C:\Program Files\Microsoft Visual Studio\2022\Community\Common7\Tools\VsDevCmd.bat"


VSTest.Console.exe  %dllpath% /Logger:"trx;LogFileName=%SummaryReportPath%\Sharoon.trx"

cd %trxerpath%

TrxToHTML %SummaryReportPath%

PAUSE