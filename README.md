# ﻿H1 How to monitor AKS WindowsContainer - windows service (eventlog,custom log files) redirected to K8s logs - Streamed out as a docker log so that we can monitor using Azure Monitor

## H2 This is based on this repo - LogMonitor tools > https://github.com/microsoft/windows-container-tools/tree/main/LogMonitor
----
> for local docker: 
> docker build -t mikkywinsvc1 .
-----
useful commands - AKS 
 ```
   docker build -t mikkywinsvc1 .
    mikkyacr1.azurecr.io
    az acr login --name mikkyacr1.azurecr.io
    docker image tag mikkywinsvc1:latest mikkyacr1.azurecr.io/mikkywinsvc1:latest
    docker push mikkyacr1.azurecr.io/mikkywinsvc1:latest
    kubectl exec -it mikkywinsvc-798dc868f7-jfc5v -- cmd 
```
<img width="743" alt="image" src="https://github.com/user-attachments/assets/266e8d39-4b7e-4725-9b99-3053ea1a41ad">
    
<img width="722" alt="image" src="https://github.com/user-attachments/assets/d61d80bf-d8fb-4112-a02d-86b948daf52b">

<img width="817" alt="image" src="https://github.com/user-attachments/assets/de1ae144-eb86-43e9-8be1-5cce856acf05">

<img width="847" alt="image" src="https://github.com/user-attachments/assets/17baf09b-5e81-4336-aadc-0b56ed3e5127">

<img width="1162" alt="image" src="https://github.com/user-attachments/assets/c4c3d41e-8d59-478c-8b2a-c67421ba5b59">

