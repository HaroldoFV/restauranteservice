# Projeto de APIs em .NET 8 com RabbitMQ e Kubernetes
Este projeto consiste em duas APIs desenvolvidas utilizando .NET 8. 
Um serviço é focado no cadastro de restaurantes e o outro é chamado de ItemService, responsável por gerenciar itens de forma simples.
As duas APIs comunicam-se de forma assíncrona utilizando RabbitMQ. A implantação do projeto é feita na AWS utilizando Kubernetes para criar pods para cada um dos serviços.
Como banco de dados, este projeto utiliza MySQL no RDS na AWS.

## Pré-requisitos
.NET 8
Docker e Docker Compose
kubectl e Minikube (ou similar) para Kubernetes local
