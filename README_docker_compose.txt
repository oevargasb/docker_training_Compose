docker pull mysql
docker volume create mydbvol
docker-compose up

(this was just to test db connectivity isolated, please don't take into account for dcker compose steps process) docker run --name dblocal -e MYSQL_RANDOM_ROOT_PASSWORD=yes -e MYSQL_DATABASE=fooddb -e MYSQL_USER=test -e MYSQL_PASSWORD=123456 -v session7_1:/var/lib/mysql -p 3311:3306 -d mysql
