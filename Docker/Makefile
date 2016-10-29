.PHONY: build app clean ps

build:
	docker-compose up build

app: build
	docker-compose up -d app

clean:
	docker-compose down -v --remove-orphans
	docker rmi $$(docker images | grep "^sync-async-comp" | awk '{print $$3}')

ps:
	docker-compose ps 