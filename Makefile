IMAGE_NAME = process-kill-repro
SDK_VERSION ?= 3.1

build:
	docker build -t $(IMAGE_NAME) --build-arg SDK_VERSION=$(SDK_VERSION) .

run: build
	docker run $(IMAGE_NAME)

.DEFAULT_GOAL = run
