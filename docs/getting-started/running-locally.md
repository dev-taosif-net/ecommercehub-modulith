# Running Locally

## 1. Clone the Repository

```bash
git clone https://github.com/your-org/ecommercehub-modulith.git
cd ecommercehub-modulith
```

## 2. Restore Dependencies

```powershell
dotnet restore src/ecommercehub-modulith.slnx
```

## 3. Run the API

```powershell
dotnet run --project src/Bootstrapper/Api/Api.csproj
```

The API will start at `https://localhost:5001` (or `http://localhost:5000`).

## 4. Verify

Navigate to `http://localhost:5000/` — you should see:

```
Api is working.
```

## Running from Rider

1. Open `src/ecommercehub-modulith.slnx` in Rider.
2. Set `Api` as the startup project.
3. Press **Run** (Shift+F10).

## Configuration

See [configuration.md](configuration.md) for environment-specific settings.

