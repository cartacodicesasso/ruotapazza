# Create images
if [ "$1" == "--arm" ]
then
    ARCH="linux/arm64"
elif [ "$1" == "--amd" ]
then
    ARCH="linux/amd64"
else
    echo "Please specify an architecture (--amd | --arm)"
    exit
fi

docker buildx build --platform "$ARCH" --no-cache -t ruotapazza_be.img -f ./docker/Backend.dockerfile .