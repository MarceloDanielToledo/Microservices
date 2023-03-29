# Microservicios - Service Discovery con API Gateway
 Este ejemplo se utilizó para demostrar la comunicación entre microservicios y balanceo de cargas utilizando Consul como componente de Service Discovery y Ocelot como API Gateway. 
 
 ### Tecnologías 
 - [Consul](https://www.consul.io/) 
 - [Ocelot](https://github.com/ThreeMammals/Ocelot) (Ya no recibe actualizaciones, se recomienda buscar alternativas para entornos de producción)
 - [Docker](https://docs.docker.com/get-docker/)

### Cómo iniciar el ejemplo
Ejecutar el archivo docker-compose.yml dentro del repositorio.
```bash
docker-compose up -d
```
Con esto vamos a crear y correr los containers que contendran a Consul, Ocelot y 3 replicas de la API Service.
![Captura_Docker](https://i.ibb.co/54w3vbp/Screenshot-2023-03-29-100019.png)

Ahora se pueden chequear el estado de los servicios dentro de Consul abriendo en el navegador la siguiente URL:
```bash
http://localhost:8500
```
![Captura_Consul](https://i.ibb.co/fQKbDTf/Screenshot-2023-03-29-100242.png)

Se puede visualizar el estado del mismo Consul, y el de "Service" con las 3 instancias.

![Services](https://i.ibb.co/G2HMbNm/services.png)

El servicio de Ocelot está configurado en el puerto 8080, podemos realizar la consulta hacia los "Service" viendo como cambia la respuesta.

![Ocelot_Get](https://i.ibb.co/QHg8vCr/ocelot-get.png)

Se puede probar el balanceo del mismo deteniendo algunas de las instancias de la API "Service".

### Material recomendado
 - [Documentación de Consul](https://developer.hashicorp.com/consul/docs)
 - [Load Balancer](https://reactiveprogramming.io/blog/es/patrones-arquitectonicos/load-balancer)
 - [Service Registry](https://reactiveprogramming.io/blog/es/patrones-arquitectonicos/service-registry)
 - [Service Discovery](https://reactiveprogramming.io/blog/es/patrones-arquitectonicos/service-discovery)
 - [Centraliza las ubicaciones con Consul](https://www.youtube.com/watch?v=UuXD8HVvucY)
