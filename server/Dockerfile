# Use an official Node.js runtime as the base image for the client build
FROM --platform=linux/amd64 node:20-slim AS client-builder
# Set the working directory in the client builder container
WORKDIR /app/client
# Copy the client application source code to the client builder container
COPY client ./
# Install client application dependencies
RUN npm install
# Build the client-side code
RUN npm run build

# The dotnet version should match the version of your application
FROM mcr.microsoft.com/dotnet/sdk:8.0-alpine-amd64 AS build-env
# Set the working directory in the build environment
WORKDIR /app/server
# Copy the server application source code to the build environment
COPY server ./
# Restore as distinct layers
RUN dotnet restore
# Copy the built client files from the client builder container
# into the server's www directory
COPY --from=client-builder /app/client/dist /app/server/wwwroot
# Build and publish a release
RUN dotnet publish -c Release -o out

# Start runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build-env /app/server/out .
CMD ASPNETCORE_URLS=http://*:$PORT dotnet <APP_NAME>.dll