#!/bin/bash

docker login

docker build -t cash-flow-inputs-api:alpha-v0 .

docker tag cash-flow-inputs-api:alpha-v0 [IMAGE-REPOSITORY]/cash-flow-inputs-api:alpha-v0
docker tag cash-flow-inputs-api:alpha-v0 [IMAGE-REPOSITORY]/cash-flow-inputs-api:latest

docker push [IMAGE-REPOSITORY]/cash-flow-inputs-api:alpha-v0
docker push [IMAGE-REPOSITORY]/cash-flow-inputs-api:latest

echo "Imagens Docker construídas e tagueadas com sucesso: cash-flow-inputs-api:alpha-v0 e cash-flow-inputs-api:latest"

kubectl create namespace cash-flow-inputs
kubectl apply -f .k8s -n cash-flow-inputs
kubectl rollout restart deploy cash-flow-inputs-api -n cash-flow-inputs