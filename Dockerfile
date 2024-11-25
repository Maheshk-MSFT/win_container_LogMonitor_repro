# Use the official Microsoft Windows Server Core image for Windows Server 2022
FROM mcr.microsoft.com/dotnet/framework/runtime:4.8-windowsservercore-ltsc2022

# Set the working directory
WORKDIR /app

# Copy the service executable and other necessary files
COPY bin/Release/ /app

RUN mkdir C:\LogMonitor
RUN copy C:\app\LogMonitor.exe C:\LogMonitor
RUN copy C:\app\LogMonitorConfig.json C:\LogMonitor


# Install the service
RUN powershell -Command \
    New-Service -Name "Service1" -BinaryPathName "C:\app\WindowsService1.exe" -DisplayName "Service1" -StartupType Automatic; \
        Start-Service -Name "Service1"


# SHELL ["C:/LogMonitor/LogMonitor.exe", "cmd", "/S", "/C"]
# Define the entry point for the container
ENTRYPOINT ["C:/LogMonitor/LogMonitor.exe", "powershell", "-Command", "Start-Service -Name Service1; Wait-Event -Timeout 2147483647"]

 # CMD ["cmd", "/c", "sc create Service1 binPath= \"C:\\app\\WindowsService1.exe\" DisplayName= \"Service1\" start= auto && sc start Service1 && timeout /t -1 /nobreak"]
