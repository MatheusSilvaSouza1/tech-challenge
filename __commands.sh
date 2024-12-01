kubectl apply --namespace tech-challenge -f .\namespace.yml
kubectl apply --namespace tech-challenge -f .\postgres.yml
kubectl apply --namespace tech-challenge -f .\rabbitmq.yml
kubectl apply --namespace tech-challenge -f .\grafana.yml
kubectl apply --namespace tech-challenge -f .\prometheus_service.yml
kubectl apply --namespace tech-challenge -f .\worker.yml
kubectl apply --namespace tech-challenge -f .\webapi.yml
