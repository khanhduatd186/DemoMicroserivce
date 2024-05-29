mkcert "demotuan6.dev" "*.demotuan6.dev" 
kubectl create namespace demotuan6
kubectl create secret tls -n demotuan6 demotuan6-tls --cert=./demotuan6.dev+1.pem  --key=./demotuan6.dev+1-key.pem