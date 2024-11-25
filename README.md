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
    
