ECHO off
set /p userName=<username.txt
:: echo %userName%
set /p passwd=<password.txt
:: echo %passwd%
plink %userName%@10.250.0.120 -pw %passwd% -m test.sh
PAUSE