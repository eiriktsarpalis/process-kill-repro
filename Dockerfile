ARG SDK_VERSION=5.0
FROM mcr.microsoft.com/dotnet/sdk:$SDK_VERSION

WORKDIR /app
COPY . .

ENV SDK_VERSION=$SDK_VERSION
CMD dotnet run -c Release
