Echo off
set /p user=<username.txt
set /p passwd=<password.txt
set /p adminUser=<adminUser.txt
set /p adminPass=<adminPass.txt
pscp -pw %adminPass% password.txt %adminUser%@10.250.0.120:password.txt
pscp -pw %adminPass% username.txt %adminUser%@10.250.0.120:username.txt
pscp -pw %adminPass% adminPass.txt %adminUser%@10.250.0.120:adminPass.txt
plink -pw %adminPass% %adminUser%@10.250.0.120 -m "commands.txt"
cd /
ssh-keygen -q -t rsa -N "" -f Users\%USERNAME%\.ssh/id_rsa
pscp -pw %passwd% Users\%USERNAME%\.ssh/id_rsa.pub %user%@10.250.0.120:authorized_keys
cd C:\Users\tdill\Desktop\Thesis\Simple-UI\Simple UI\bin\Debug\netcoreapp2.0
plink -pw %adminPass% %adminUser%@10.250.0.120 -m "sshkey.txt"
ssh -o StrictHostKeyChecking=no %user%@10.250.0.120 'exit'
del username.txt
del password.txt