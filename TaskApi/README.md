# Julian Lavrin (63322)

## Jak odpalić? 

### 1. Seedning
```bash
# Check if donet ef is installed
dotnet ef

# Install dotnet ef
dotnet tool install --global dotnet-ef

# Add migration
dotnet ef migrations add InitialCreate
dotnet ef database update
```

### 2. Uruchomienie
```bash
#docker composer
docker-compose up -d
```

Uruchomi się baza danych na porcie 5432 oraz aplikacja backendowa na http://localshot:5298 wraz z aplikacją frontową

### 3. Przydatne adresy
```bash
# Swagger
http://localhost:5298/swagger/index.html

# Frontend
http://localhost:5298/app/index.html

# Backend
http://localhost:5298/api
```

