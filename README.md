# topology_api

this was alot of work and so out of my comfort zone.  
first time using c#, .net, docker, swagger, mongodb, ...etc and first time making an api.

 i tested it on the fpllowing link just for case it didn't work as expected.  
testing it https://youtu.be/X6uWyTAUuds

you can test it your self by first creating a mongodb image by running the following docker comand.  
 >>   docker run -d --rm --name mongo -p 27017:27017 -v mongodbdata:/data/db -e MONGO_INITDB_ROOT_USERNAME=admin -e MONGO_INITDB_ROOT_PASSWORD=12345 --network=topology mongo

or by pulling the following docker image from dockerhub
https://hub.docker.com/repository/docker/alonethegreat/topology_api


and a special thanks to this 6 hour video course it was amazing  https://www.youtube.com/watch?v=ZXdFisA_hOY
