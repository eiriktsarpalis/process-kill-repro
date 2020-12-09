ARG SDK_VERSION=5.0
FROM mcr.microsoft.com/dotnet/sdk:$SDK_VERSION

WORKDIR /app
COPY . .

RUN dotnet publish -c Release -o /output
ENTRYPOINT [ "/output/repro" ]
