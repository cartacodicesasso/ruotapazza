# Create images
bash ./scripts/build.sh --amd

# Export images
mkdir -p ./dist
rm -rf ./dist/*
docker save -o ./dist/ruotapazza_be.img.tar ruotapazza_be.img

# Push to server
ssh mconst@46.101.53.207 mkdir -p /home/mconst/docker-projects/ruotapazza
ssh mconst@46.101.53.207 rm -rf /home/mconst/docker-projects/ruotapazza/*
scp ./dist/ruotapazza_be.img.tar mconst@46.101.53.207:/home/mconst/docker-projects/ruotapazza/ruotapazza_be.img.tar
scp ./docker/docker-compose.yml mconst@46.101.53.207:/home/mconst/docker-projects/ruotapazza/docker-compose.yml

# Run on server
ssh mconst@46.101.53.207 docker load -i /home/mconst/docker-projects/ruotapazza/ruotapazza_be.img.tar
ssh mconst@46.101.53.207 docker compose -f /home/mconst/docker-projects/ruotapazza/docker-compose.yml -p ruotapazza up -d

ssh mconst@46.101.53.207 rm -rf /home/mconst/docker-projects/ruotapazza
rm -rf ./dist