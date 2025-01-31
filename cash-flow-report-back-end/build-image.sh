#!/bin/bash

docker login

docker build -t cash-flow-report-api:alpha-v0 .

docker tag cash-flow-report-api:alpha-v0 [IMAGE-REPOSITORY]/cash-flow-report-api:alpha-v0
docker tag cash-flow-report-api:alpha-v0 [IMAGE-REPOSITORY]/cash-flow-report-api:latest

docker push [IMAGE-REPOSITORY]/cash-flow-report-api:alpha-v0
docker push [IMAGE-REPOSITORY]/cash-flow-report-api:latest

echo "Imagens Docker construídas e tagueadas com sucesso: cash-flow-report-api:alpha-v0 e cash-flow-report-api:latest"

kubectl create namespace cash-flow-report
kubectl apply -f .k8s -n cash-flow-report
kubectl rollout restart deploy cash-flow-report-api -n cash-flow-report