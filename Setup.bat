@echo off
title This is your first batch script!
echo Welcome to batch scripting!

echo Current Directry
%cd% 

cd client

echo Current Directry
%cd% 

del package-lock.json

echo package lock deleted

call npm install && (
    echo node js installed
    call composer install && (
       echo Composer installed
    ) || echo composer install failed
) || echo Nodejs install failed

call npm build
echo Current Directry
%cd% 
cd..

dotnet restore

echo  packages restored successfully 

dotnet build
echo  packages build successfully 

dotnet ef --help

dotnet tool install dotnet-ef -g

dotnet ef --help

dotnet ef database update

dotnet run

echo  browse Application in browser : http://localhost:5000/