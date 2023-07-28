# Use the .NET SDK 7.0 image as the build environment
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

# Set the working directory inside the container
WORKDIR /app

# Copy the application project files into the container
COPY *.csproj ./

# Restore NuGet packages
RUN dotnet restore

# Copy everything else
COPY . ./

# Publish the application
RUN dotnet publish -c Release -o out

# Switch to the runtime environment
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime

# Set the working directory inside the container
WORKDIR /app

# Copy the published application from the build stage
COPY --from=build /app/out .

# Set the command to be executed when the container starts
CMD ["dotnet", "AuthenticationDemo.dll"]
