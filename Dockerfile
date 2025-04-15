# Use the official .NET runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app

# Copy the build output from the workflow
COPY ./publish/ .

# Expose the port the application runs on
EXPOSE 80
EXPOSE 443

# Set the entry point for the application
ENTRYPOINT ["dotnet", "DemoCopilot04.dll"]
