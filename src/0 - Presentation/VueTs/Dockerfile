FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["0 - Presentation/VueTs/VueTs.csproj", "0 - Presentation/VueTs/"]
COPY ["04 - Infra/04.1 - CrossCutting/Infra.CrossCutting.IoC/Ddd.Infra.CrossCutting.IoC.csproj", "04 - Infra/04.1 - CrossCutting/Infra.CrossCutting.IoC/"]
COPY ["04 - Infra/04.1 - CrossCutting/Infra.CrossCutting.Identity/Ddd.Infra.CrossCutting.Identity.csproj", "04 - Infra/04.1 - CrossCutting/Infra.CrossCutting.Identity/"]
COPY ["03 - Domain/Ddd_Domain/Ddd.Domain.csproj", "03 - Domain/Ddd_Domain/"]
COPY ["04 - Infra/04.1 - CrossCutting/Infra.Data.CrossCutting.Resources/Ddd.Infra.Data.CrossCutting.Resources.csproj", "04 - Infra/04.1 - CrossCutting/Infra.Data.CrossCutting.Resources/"]
COPY ["02 - Application/Ddd_Application/Ddd.Application.csproj", "02 - Application/Ddd_Application/"]
COPY ["04 - Infra/04.2 - Infra.Data/Infra.Data/Ddd.Infra.Data.csproj", "04 - Infra/04.2 - Infra.Data/Infra.Data/"]
RUN dotnet restore "0 - Presentation/VueTs/VueTs.csproj"
COPY . .
WORKDIR "/src/0 - Presentation/VueTs"
RUN dotnet build "VueTs.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "VueTs.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "VueTs.dll"]