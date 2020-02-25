
FROM debian:latest

LABEL maintainer="psapi"

RUN apt-get update && apt-get upgrade -y

RUN apt-get install nginx -y

EXPOSE 80

CMD ["api", "-g", "daemon off;"]