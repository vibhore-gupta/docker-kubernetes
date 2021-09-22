# docker-kubernetes
How to run dotnet webapi in kubernetes cluster using docker images.
This project has two services
1. PlatformService
2. CommandService

Following are the steps to get these running in a kubernetes cluster

1. Build docker images from dockerfile for both the services. Make sure that docker desktop is running with kubernetes enabled on the development machine.
    - Go the `/PlatformService` folder and run the following command
      (Dont forget the period in the below command. It provides the build context)
      This will a create a image `<docker-hub-id>/platformservice`
      ```
      docker build -t <docker-hub-id>/platformservice .
      ```      
    - Go the `/CommandService` folder and run the following command
      (Dont forget the period in the below command. It provides the build context)
      This will a create a image `<docker-hub-id>/commandservice`
      ```
      docker build -t <docker-hub-id>/commandservice .
      ```      
2. Now that we have images, we will create running containers by running the below command
    ```
    docker run -d -p 8080:80 <docker-hub-id>/platformservice
    docker run -d -p 8080:80 <docker-hub-id>/commandservice
    ```
    Test each service by hitting below endpoints by using Postman
    ```
    (platformservice)  GET http://localhost:8080/api/platforms
    (commandservice) POST http://localhost:8080/api/c/platforms
    ```
    If successful response is received, we have running conatiners in docker.
3. Push these docker images to `hub.docker.com` by running below commands. These images will be used by kubernetes cluster later.
    ```
    docker push <docker-hub-id>/platformservice
    docker push <docker-hub-id>/commandservice
    ```
4. Now we will run these images inside a kubernetes cluster. 
    Go the `/K8S` folder and run the following commands. This will create pods for `platformservice` and `commandservice` and will create CLusterIp services to enable interaction for outside world.
    ```
    kubectl apply -f platforms-depl.yaml
    kubectl apply -f commands-depl.yaml 
    ```
    To see the deployments
    ```
    kubectl get deployments    
    ```
    To get the pods 
    ```
    kubectl get pods    
    ```
    To get the services (clusterIp services)
    ```
    kubectl get services   
    ```
5. Pods are ephemeral in nature, so direct access to pods is not allowed that is why we created clusterIp services to enable their interaction to outside world. One way for us to interact with pod is to make use of nodeport service. To start this service, go to `K8S` folder and run the below command
    ```
    kubectl apply -f platforms-np-srv.yaml
    ```
    To get the port from which we can access platformservice run the below command and tlook for servicetype ClusterIp ake note of the port
    ```
    kubectl get services
    ```
    Test platformservice by hitting below endpoints by using Postman
    ```
    GET http://localhost:<30xxx>/api/platforms
    ```
    Successful reponse indicates that we are now able to interact with the platformservice pod through a nodeport service.

