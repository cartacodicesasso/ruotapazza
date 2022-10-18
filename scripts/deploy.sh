# Create images
docker compose -f ./docker/docker-compose.yml build

# Export images
makedir -p ./dist
docker save -o ./dist/ruotapazza_be.img.tar ruotapazza_be.img

# Push to server
scp ./dist/ruotapazza_be.img.tar mconst@46.101.53.207:/home/mconst/docker-projects/ruotapazza
scp ./docker/docker-compose.yml mconst@46.101.53.207:/home/mconst/docker-projects/ruotapazza

# Run on server
ssh mconst@46.101.53.207 docker load -i /home/mconst/docker-projects/ruotapazza/ruotapazza_be.img.tar
ssh mconst@46.101.53.207 docker compose -f /home/mconst/docker-projects/ruotapazza/docker-compose.yml -p ruotapazza up -d