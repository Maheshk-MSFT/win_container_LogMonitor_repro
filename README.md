# win_container_LogMonitor_repro
----
for local docker: 
> docker build -t mikkywinsvc1 .
-----
to AKS 
    ```
    mikkyacr1.azurecr.io
    az acr login --name mikkyacr1.azurecr.io
    docker image tag mikkywinsvc1:latest mikkyacr1.azurecr.io/mikkywinsvc1:latest
    docker push mikkyacr1.azurecr.io/mikkywinsvc1:latest
    kubectl exec -it mikkywinsvc-798dc868f7-p8g7s -- cmd 
    ```
    
<img width="1047" alt="image" src="https://github.com/user-attachments/assets/6f4a1e18-5c1b-4b34-bed3-6524d1d7a586">

<img width="823" alt="image" src="https://github.com/user-attachments/assets/4c1bbef1-7b1e-47d9-ae6e-ddca09661718">
<img width="814" alt="image" src="https://github.com/user-attachments/assets/4b70803f-bef0-4c49-931b-42324aec934b">
