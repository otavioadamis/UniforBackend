@echo off
set BASE_DIR=%~dp0
echo Iniciando build.
cd %BASE_DIR%
docker-compose up --build
echo Build concluída.